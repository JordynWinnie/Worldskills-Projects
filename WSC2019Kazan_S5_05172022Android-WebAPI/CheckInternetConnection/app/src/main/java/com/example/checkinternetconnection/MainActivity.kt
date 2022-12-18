package com.example.checkinternetconnection

import android.graphics.Color
import android.net.ConnectivityManager
import android.net.Network
import android.net.NetworkCapabilities
import android.net.NetworkRequest
import android.os.Bundle
import android.util.Log
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.background
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.*
import androidx.compose.ui.unit.dp
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.KeyboardArrowDown
import androidx.compose.material.icons.filled.KeyboardArrowUp
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Alignment.Companion.Center
import androidx.compose.ui.Alignment.Companion.TopEnd
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color as composeColor
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.text.style.TextOverflow
import androidx.core.content.ContextCompat
import androidx.navigation.*
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.checkinternetconnection.ui.theme.CheckInternetConnectionTheme
import java.lang.Exception
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class MainActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        val appViewModel = AppViewModel()
        val networkRequest = NetworkRequest.Builder()
            .addCapability(NetworkCapabilities.NET_CAPABILITY_INTERNET)
            .addTransportType(NetworkCapabilities.TRANSPORT_WIFI)
            .addTransportType(NetworkCapabilities.TRANSPORT_CELLULAR)
            .build()

        val networkCallback = object : ConnectivityManager.NetworkCallback() {
            override fun onAvailable(network: Network) {
                super.onAvailable(network)
                Log.d("ConnectionStatus", "onAvailable")
                appViewModel.networkStatus = true
                appViewModel.refreshData()

            }

            override fun onLost(network: Network) {
                super.onLost(network)
                Log.d("ConnectionStatus", "onLost")
                appViewModel.networkStatus = false
                appViewModel.lastUpdatedTime = LocalDateTime.now()
            }
        }


        setContent {
            val connectivityManager = ContextCompat.getSystemService(
                LocalContext.current,
                ConnectivityManager::class.java
            ) as ConnectivityManager
            connectivityManager.requestNetwork(networkRequest, networkCallback)

            val navHostController = rememberNavController()
            CheckInternetConnectionTheme {
                // A surface container using the 'background' color from the theme
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colors.background
                ) {
                    NavHost(navController = navHostController, startDestination = "home"){
                        composable("home") {
                            MyApp(appViewModel, navHostController)
                        }

                        composable("addWell") {
                            NewWell(appViewModel = appViewModel, navController = navHostController)
                        }

                        composable(
                            "editWell/{id}",
                            listOf( navArgument("id") {
                                type = NavType.IntType
                            })
                        ) {
                            var wellId = 0
                            try {
                                wellId = it.arguments?.getInt("id")!!
                            }
                            catch (e: Exception) {}

                            EditWells(appViewModel = appViewModel, navController = navHostController, wellId = wellId)
                        }
                    }

                }
            }
        }
    }


}
@Composable
private fun MyApp(appViewModel: AppViewModel, navHostController: NavHostController) {
    Column() {
        Row(verticalAlignment = Alignment.CenterVertically) {
            Text(text = "Well Name:", Modifier.weight(1f))
            DropDownList(
                items = appViewModel.wellList.map { it.wellName },
                selectedItem = appViewModel.selectedWell,
                onItemSelected = { appViewModel.selectedWell = it },
                Modifier.weight(1f),
            )
            Button(
                onClick = {
                    appViewModel.addedWellLayers.clear()
                    appViewModel.addWellInformation(appViewModel.getWellInformation(appViewModel.selectedWell)?.id!!)
                    navHostController.navigate(
                        "editWell/${
                            appViewModel.getWellInformation(appViewModel.selectedWell)?.id
                        }",
                    )
                },
                Modifier.weight(1f), enabled = appViewModel.networkStatus,
            ) {
                Text(text = "Edit")
            }
        }
        if (appViewModel.getLayers(appViewModel.selectedWell).isEmpty()) {
            Box(modifier = Modifier.weight(1f).fillMaxSize()) {
                Text(text = "Fetching Data...")
            }
        }else{
            WellGraph(
                wellLayers = appViewModel.getLayers(appViewModel.selectedWell),
                appViewModel,
                Modifier.weight(1f)
            )
        }
        
        val wellInfo = appViewModel.getWellInformation(appViewModel.selectedWell)
        Row(verticalAlignment = Alignment.CenterVertically) {
            Text("Well Capacity: ${wellInfo?.capacity} m^3", Modifier.weight(1f))
            Button(
                onClick = {
                    appViewModel.addedWellLayers.clear()
                    navHostController.navigate("addWell")
                },
                Modifier.weight(1f),
                enabled = appViewModel.networkStatus
            ) {
                Text(text = "Add Asset")
            }
        }
        
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(if (appViewModel.networkStatus) composeColor.Green else composeColor.Red)
                .padding(vertical = 8.dp),
            contentAlignment = Center
        ){
            if (appViewModel.networkStatus)
                Text(text = "Connected", textAlign = TextAlign.Center)
            else
                Text(text = "Disconnected. Last Update: ${appViewModel.lastUpdatedTime.format(
                    DateTimeFormatter.ofLocalizedDateTime(FormatStyle.SHORT))}", textAlign = TextAlign.Center)
        }
    }
}

@Composable
fun WellGraph(wellLayers: List<WellLayer>, appViewModel: AppViewModel,modifier: Modifier = Modifier)
{
    if (wellLayers.isEmpty()) return
    val lastLayer = wellLayers.last().endPoint
    Column(modifier = modifier) {
        wellLayers.forEachIndexed {
            idx, it ->
            val rock = appViewModel.getRockInformation(it.rockTypeId)
            val color = Color.parseColor(rock.backgroundColor)

            if (idx == wellLayers.size - 1) {
                Box(
                    modifier = Modifier
                        .weight(((it.endPoint - it.startPoint).toFloat() / lastLayer))
                        .background(color = composeColor.Black)
                        .fillMaxWidth()
                        .border(1.dp, composeColor.Black),
                ){
                    Text(
                        text = "Oil / Gas",
                        modifier = Modifier.align(Center),
                        color = composeColor.White
                    )
                    Text(
                        text = "${it.startPoint} m",
                        color = composeColor.White,
                        modifier = Modifier
                            .align(TopEnd)
                            .padding(horizontal = 4.dp),
                    )
                }
            }else {
                Box(
                    modifier = Modifier
                        .weight(((it.endPoint - it.startPoint).toFloat() / lastLayer))
                        .background(color = composeColor(color))
                        .fillMaxWidth()
                        .border(1.dp, composeColor.Black),
                ){
                    Text(text = rock.name, modifier = Modifier.align(Center))
                    Text(text = "${it.startPoint} m", modifier = Modifier
                        .align(TopEnd)
                        .padding(horizontal = 4.dp))
                }
            }


        }
    }
}

@Composable
fun DropDownList(
    items: List<String>,
    selectedItem: String,
    onItemSelected: (String) -> Unit,
    modifier: Modifier = Modifier
) {
    if (items.isEmpty()) return
    if (selectedItem.isBlank()){
        onItemSelected(items[0])
        return
    }

    if (!items.contains(selectedItem)) {
        onItemSelected(items[0])
        return
    }
    var expanded by rememberSaveable() { mutableStateOf(false) }

    Column(modifier = modifier) {
        OutlinedButton(onClick = { expanded = true }, Modifier.fillMaxWidth()) {
            Text(text = selectedItem, overflow = TextOverflow.Ellipsis,modifier= Modifier.weight(1f))
            Icon(if (expanded) Icons.Default.KeyboardArrowUp else Icons.Default.KeyboardArrowDown, contentDescription = null)
        }

        DropdownMenu(expanded = expanded, onDismissRequest = { expanded = false }) {
            items.forEach {
                    item ->
                DropdownMenuItem(onClick = {
                    onItemSelected(item)
                    expanded = false
                }) {
                    Text(text = item)
                }
            }
        }
    }
}
