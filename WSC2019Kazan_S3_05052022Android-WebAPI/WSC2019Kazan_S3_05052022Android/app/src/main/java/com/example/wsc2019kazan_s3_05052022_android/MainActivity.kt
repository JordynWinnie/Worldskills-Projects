package com.example.wsc2019kazan_s3_05052022_android

import android.app.DatePickerDialog
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.itemsIndexed
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.*
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.wsc2019kazan_s3_05052022_android.ui.theme.WSC2019Kazan_S3_05052022AndroidTheme
import java.time.LocalDate
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContent {
            WSC2019Kazan_S3_05052022AndroidTheme {
                // A surface container using the 'background' color from the theme
                val appViewModel: AppViewModel = viewModel()
                val navController: NavHostController = rememberNavController()

                NavHost(navController = navController, startDestination = "home") {

                    composable("home"){
                        MyApp(appViewModel, navController)
                    }

                    composable("addAsset"){
                        MaintenanceTasks(appViewModel, navController)
                    }
                }

            }
        }
    }
}

@Composable
fun MyApp(appViewModel: AppViewModel, navHostController: NavHostController) {
    Scaffold(
        topBar = {
            TopAppBar(title = {
                Text(text = "PM List")
            })
        }, bottomBar = {
            BottomAppBar {

                val assetListDisplay = appViewModel.assetList.map { it.assetName }.toMutableList()
                assetListDisplay.add(0, "None")

                val taskListDisplay = appViewModel.taskList.map { it.name }.toMutableList()
                taskListDisplay.add(0, "None")
                JetpackSpinner(items = assetListDisplay, selectedItem = appViewModel.selectedAssetName, onItemSelected = { appViewModel.selectedAssetName = it },
                    modifier = Modifier.weight(0.4f)
                )
                JetpackSpinner(items = taskListDisplay, selectedItem = appViewModel.selectedTask, onItemSelected = {  appViewModel.selectedTask = it },
                    modifier = Modifier.weight(0.4f)
                )
                IconButton(
                    onClick = {
                        appViewModel.selectedTask = "None"
                        appViewModel.selectedAssetName = "None"
                    },
                    modifier = Modifier.weight(0.2f),
                ) {
                    Icon(Icons.Default.Delete, contentDescription = null)
                }
            }
        },
        floatingActionButtonPosition = FabPosition.End,
        floatingActionButton = {
            FloatingActionButton(onClick = { navHostController.navigate("addAsset") }) {
                Icon(Icons.Default.Add, contentDescription = null )
            }
        }
    ) {
        paddingValues ->
        Column(
            Modifier
                .padding(paddingValues)
                .padding(4.dp)
                .fillMaxWidth()) {
            Row(verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.Center) {
                Text(text = "Active Date", Modifier.weight(0.3f))
                DateSelector(selectedDate = appViewModel.selectedDate, onClick = { appViewModel.selectedDate = it },
                    Modifier.weight(0.7f))
            }
            
            Spacer(modifier = Modifier.padding(vertical = 8.dp))
            
            LazyColumn(Modifier.padding(vertical = 4.dp)){
                itemsIndexed(appViewModel.getPmListWithFilter(appViewModel.selectedDate, appViewModel.selectedAssetName, appViewModel.selectedTask)) {
                    idx, pmTask ->
                    PMTaskRow(pmTask) { appViewModel.updatePmList(pmTask, it) }
                }
            }
        }
    }
}



@Composable
fun PMTaskRow(pmTasks: PMTasks, onCheckChanged: (checked: Boolean) -> Unit){
    Row(verticalAlignment = Alignment.CenterVertically, modifier = Modifier.padding(vertical = 4.dp)) {
        Image(Icons.Default.Place, contentDescription = null,
            Modifier
                .size(48.dp)
                .background(color = pmTasks.color))
        Spacer(modifier = Modifier.padding(horizontal = 4.dp))
        Column(Modifier.weight(1f)) {
            Text(text = "${pmTasks.assetName} ** SN: ${pmTasks.assetSn}", maxLines = 1, overflow = TextOverflow.Ellipsis)
            Text(text = pmTasks.taskName, overflow = TextOverflow.Ellipsis)
            Text(text = "${pmTasks.scheduleType} - at ${pmTasks.scheduleKilometer ?: LocalDateTime.parse(pmTasks.scheduleDate).format(
                DateTimeFormatter.ISO_DATE)}", overflow = TextOverflow.Ellipsis)
        }
        Checkbox(checked = pmTasks.taskDone, onCheckedChange = onCheckChanged)
    }
}

@Composable
fun DateSelector(selectedDate: LocalDate, onClick: (LocalDate) -> Unit, modifier: Modifier = Modifier){
    val context = LocalContext.current
    val dateSelector = DatePickerDialog(context)

    dateSelector.updateDate(selectedDate.year, selectedDate.monthValue - 1, selectedDate.dayOfMonth)
    dateSelector.setOnDateSetListener {
        _, year, month, day -> onClick(LocalDate.of(year, month + 1, day))
    }

    Button(onClick = { dateSelector.show() }, modifier = modifier) {
        Icon(Icons.Default.DateRange, contentDescription = null)
        Spacer(modifier = Modifier.padding(horizontal = 4.dp))
        Text(text = selectedDate.format(DateTimeFormatter.ISO_DATE))
    }
}

@Composable
fun JetpackSpinner(modifier: Modifier = Modifier, items: List<String>, selectedItem: String?, onItemSelected: (String) -> Unit) {
    var expanded by rememberSaveable {
        mutableStateOf(false)
    }
    OutlinedButton(
        onClick = { expanded = true },
        modifier = modifier
    ) {
        Row {
            if (items.contains(selectedItem)){
                Text(modifier= Modifier.weight(1f), text = selectedItem!!, maxLines = 1, overflow = TextOverflow.Ellipsis)
            } else {
                if (items.isEmpty()){
                    onItemSelected("")
                }else{
                    onItemSelected(items[0])
                }

            }
            Icon(if (expanded) Icons.Default.KeyboardArrowUp else Icons.Default.KeyboardArrowDown, contentDescription = null)
        }

        DropdownMenu(expanded = expanded, onDismissRequest = { expanded = false }) {
            items.forEach {
                DropdownMenuItem(
                    onClick = {
                        onItemSelected(it)
                        expanded = false
                    },
                ) {
                    Text(text = it)
                }
            }
        }
    }


}