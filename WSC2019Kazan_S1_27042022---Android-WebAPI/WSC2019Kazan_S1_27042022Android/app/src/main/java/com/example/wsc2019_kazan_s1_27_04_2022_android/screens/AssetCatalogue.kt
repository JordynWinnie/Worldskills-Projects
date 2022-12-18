package com.example.wsc2019_kazan_s1_27_04_2022_android.screens

import android.content.res.Configuration
import android.graphics.BitmapFactory
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.asImageBitmap
import androidx.compose.ui.platform.LocalConfiguration
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.example.wsc2019_kazan_s1_27_04_2022_android.AppViewModel
import com.example.wsc2019_kazan_s1_27_04_2022_android.Assets
import com.example.wsc2019_kazan_s1_27_04_2022_android.components.DateSelector
import com.example.wsc2019_kazan_s1_27_04_2022_android.components.Spinner
import java.util.*

@Composable
fun AssetCatalogue(appViewModel: AppViewModel, navController: NavController, drawable: Int){

    Scaffold(
        floatingActionButton = {
            FloatingActionButton(onClick = { navController.navigate("register") }) {
                Icon(Icons.Default.Add, contentDescription = null)
            }
        },
        floatingActionButtonPosition = FabPosition.End
    ) {
        val editHelper: (Int) -> Unit = { navController.navigate("register?id=$it") }
        val transferHelper: (Int) -> Unit = { navController.navigate("assetTransfers/$it") }
        val transferHistoryHelper: (Int) -> Unit = { navController.navigate("transferHistory/$it") }
        if (LocalConfiguration.current.orientation == Configuration.ORIENTATION_LANDSCAPE){
            MyAppLandScape(appViewModel, editHelper, drawable)
        } else {
            MyApp(appViewModel, editHelper, drawable, transferHelper, transferHistoryHelper)
        }
    }

}

@Composable
fun MyAppLandScape(
    appViewModel: AppViewModel ,
    editHelper: (Int) -> Unit,
    drawable: Int
) {
    Column {
        Text(text = "Your Assets:")
        LazyColumn {
            items(appViewModel.getAssets()) {
                    asset -> AssetItemLandscape(asset = asset, editHelper, drawable)
            }
        }
    }
}

@Composable
fun MyApp(
    appViewModel: AppViewModel,
    editHelper: (Int) -> Unit,
    drawable: Int,
    transferHelper: (Int) -> Unit,
    transferHistoryHelper: (Int) -> Unit
) {
    Column(Modifier.padding(4.dp)) {
            val department = appViewModel.departmentList.map { it.name }.toMutableList()
            department.add(0, "All")

            val assetGroup = appViewModel.assetGroupList.map { it.name }.toMutableList()
            assetGroup.add(0, "All")
            Row {
                Spinner(
                    spinnerItems = department,
                    selectedItem = appViewModel.selectedDepartment,
                    onItemSelected = { appViewModel.selectedDepartment = it},
                    modifier = Modifier.weight(1f)
                )
                Spacer(modifier = Modifier.padding(4.dp))
                Spinner(
                    spinnerItems = assetGroup,
                    selectedItem = appViewModel.selectedAssetGroup,
                    onItemSelected = { appViewModel.selectedAssetGroup = it },
                    modifier = Modifier.weight(1f)
                )

            }

            Spacer(modifier = Modifier.padding(4.dp))

            Text(text = "Warranty Date Range")

            Divider(Modifier.padding(horizontal = 4.dp, vertical = 8.dp))

            Row {
                DateSelector(
                    dateTime = appViewModel.startDate,
                    onDateSelected = { appViewModel.startDate = it },
                    labelText = "Start Date",
                    modifier = Modifier
                        .fillMaxWidth()
                        .weight(1f)
                )
                Spacer(modifier = Modifier.padding(4.dp))
                DateSelector(
                    dateTime = appViewModel.endDate,
                    onDateSelected = { appViewModel.endDate = it },
                    labelText = "End Date",
                    modifier = Modifier
                        .fillMaxWidth()
                        .weight(1f)
                )
            }

            Divider(Modifier.padding(horizontal = 4.dp, vertical = 8.dp))

            // Search Field:
            TextField(
                value = appViewModel.searchTerm,
                onValueChange = {appViewModel.searchTerm = it},
                leadingIcon = { Icon(Icons.Filled.AddCircle, contentDescription = null) },
                trailingIcon = { Icon(Icons.Filled.Search, contentDescription = null) },
                modifier = Modifier.fillMaxWidth(),
                label = { Text(text = "Search...") }
            )
            Divider(Modifier.padding(horizontal = 4.dp, vertical = 8.dp))

            Text(text = "Asset List:")

            Divider(Modifier.padding(horizontal = 4.dp, vertical = 8.dp))


            LazyColumn(Modifier
                .fillMaxHeight()
                .weight(1f)){
                items(appViewModel.getAssets()) {
                        asset -> AssetItem(asset = asset, editHelper, drawable, transferHelper, transferHistoryHelper)
                }
            }
            Text(text = "${appViewModel.getAssets().size} assets from ${appViewModel.assetList.size}")

        }
}

@Composable
fun AssetItemLandscape(asset: Assets, editHelper: (Int) -> Unit, drawable: Int) {
    Row(
        Modifier
            .fillMaxWidth()
            .padding(4.dp),
        verticalAlignment = Alignment.CenterVertically,
        horizontalArrangement = Arrangement.SpaceAround,
    ) {
        if (asset.assetPhoto1 != null){
            // Load Image
            val byeArray = Base64.getDecoder().decode(asset.assetPhoto1)
            val bitmap = BitmapFactory.decodeByteArray(byeArray, 0, byeArray.size)
            Image(
                bitmap.asImageBitmap(),
                contentDescription = null,
                modifier = Modifier.size(64.dp)
            )
        }else {
            Image(
                painterResource(id = drawable),
                contentDescription = null,
                modifier = Modifier.size(64.dp)
            )
        }
        Spacer(modifier = Modifier.padding(start = 8.dp))
        Text(text = asset.assetName, modifier = Modifier.weight(1f))
        Spacer(modifier = Modifier.padding(start = 8.dp))
        Text(text = asset.assetSn, color = Color.Red)

        IconButton(onClick = { editHelper(asset.id) }) {
            Icon(Icons.Default.Edit, contentDescription = null)
        }
    }
}

@Composable
fun AssetItem(
    asset: Assets,
    editHelper: (Int) -> Unit,
    drawable: Int,
    transferHelper: (Int) -> Unit,
    transferHistoryHelper: (Int) -> Unit
) {
    Row(
        Modifier
            .fillMaxWidth()
            .padding(vertical = 4.dp),
        verticalAlignment = Alignment.CenterVertically,
        horizontalArrangement = Arrangement.SpaceAround
    ) {
        if (asset.assetPhoto1 != null){
            // Load Image
            val byeArray = Base64.getDecoder().decode(asset.assetPhoto1)
            val bitmap = BitmapFactory.decodeByteArray(byeArray, 0, byeArray.size)
            Image(
                bitmap.asImageBitmap(),
                contentDescription = null,
                modifier = Modifier.size(64.dp)
            )
        }else {
            Image(
                painterResource(id = drawable),
                contentDescription = null,
                modifier = Modifier.size(64.dp)
            )
        }

        Spacer(modifier = Modifier.padding(start = 8.dp))
        Column(
            Modifier
                .weight(1f)
                .fillMaxWidth(),
        ) {
            Text(text = asset.assetName, maxLines = 1, overflow = TextOverflow.Ellipsis)
            Text(text = asset.departmentName)
            Text(text = asset.assetSn)
        }
        Spacer(modifier = Modifier.padding(start = 8.dp))
        Row {
            IconButton(onClick = { editHelper(asset.id) }) {
                Icon(Icons.Default.Edit, contentDescription = null)
            }
            IconButton(onClick = { transferHelper(asset.id) }) {
                Icon(Icons.Default.Share, contentDescription = null)
            }
            IconButton(onClick = { transferHistoryHelper(asset.id) }) {
                Icon(Icons.Default.List, contentDescription = null)
            }
        }
    }
}
