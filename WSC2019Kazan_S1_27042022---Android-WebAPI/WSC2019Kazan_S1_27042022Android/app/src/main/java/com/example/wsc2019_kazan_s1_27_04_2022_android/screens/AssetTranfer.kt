package com.example.wsc2019_kazan_s1_27_04_2022_android.screens

import androidx.compose.foundation.layout.*
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewModelScope
import androidx.navigation.NavController
import com.example.wsc2019_kazan_s1_27_04_2022_android.AppViewModel
import com.example.wsc2019_kazan_s1_27_04_2022_android.AssetLogs
import com.example.wsc2019_kazan_s1_27_04_2022_android.components.Spinner
import kotlinx.coroutines.launch
import java.time.LocalDateTime

@Composable
fun AssetTransfer(navHostController: NavController, id: Int, appViewModel: AppViewModel) {
    Scaffold(
        topBar = {
            TopAppBar(
                title = {
                    Text(text = "Asset Transfer")
                },
                navigationIcon = {
                    IconButton(onClick = { navHostController.popBackStack()
                        appViewModel.refreshData()}) {
                        Icon(Icons.Filled.ArrowBack, contentDescription = null)
                    }
                }
            )
        },
    ) {
        AssetTransferMain(id, appViewModel, navHostController)
    }
}


@Composable
fun AssetTransferMain(id: Int, appViewModel: AppViewModel, navHostController: NavController) {
    val currentAsset = appViewModel.assetList.find {
        it.id == id
    }!!
    Column(Modifier.padding(8.dp)) {
        Text(text = "Selected Asset")

        Divider(Modifier.padding(horizontal = 4.dp, vertical = 8.dp))

        Row {
            Text(text = "Asset Name", Modifier.weight(1f))
            Spacer(modifier = Modifier.padding(horizontal = 8.dp))
            Text(text = "Current Department", Modifier.weight(1f))
        }

        Row {
            //Asset Name:
            TextField(value = currentAsset.assetName, onValueChange = {}, Modifier.weight(1f), singleLine = true, readOnly = true)
            Spacer(modifier = Modifier.padding(horizontal = 8.dp))
            TextField(value = currentAsset.departmentName, onValueChange = {}, Modifier.weight(1f), singleLine = true, readOnly = true)
        }
        

        Text(text = "Asset SN:")
        TextField(value = currentAsset.assetSn, onValueChange = {}, Modifier.fillMaxWidth(), singleLine = true, readOnly = true)

        Spacer(modifier = Modifier.padding(vertical = 16.dp))

        Text(text = "Destination Department:")

        Divider(Modifier.padding(horizontal = 4.dp, vertical = 8.dp))

        Row {
            Text(text = "Destination Department", Modifier.weight(1f))
            Spacer(modifier = Modifier.padding(horizontal = 8.dp))
            Text(text = "Destination Location", Modifier.weight(1f))
        }
        val departments = appViewModel.departmentLocationList.map {
            it.department_name
        }.filter {
            it != currentAsset.departmentName
        }.distinct()

        var selectedDepartment by rememberSaveable {
            mutableStateOf(departments[0])
        }

        val locations = appViewModel.getLocationByDepartment(selectedDepartment)

        var selectedLocation by rememberSaveable {
            mutableStateOf(locations[0])
        }
        Row {

            Spinner(
                spinnerItems = departments,
                selectedItem = selectedDepartment,
                onItemSelected = { selectedDepartment = it },
                Modifier.weight(1f)
            )
            Spacer(modifier = Modifier.padding(horizontal = 8.dp))
            Spinner(
                spinnerItems = locations,
                selectedItem = selectedLocation,
                onItemSelected = { selectedLocation = it },
                Modifier.weight(1f)
            )
        }


        Text(text = "Asset SN:")
        val assetSN = appViewModel.getUniqueTransferId(currentAsset.id, selectedDepartment, currentAsset.assetGroupName)
        TextField(value = assetSN, onValueChange = {}, Modifier.fillMaxWidth())

        Spacer(modifier = Modifier.padding(vertical = 16.dp))

        var assetTransferLog = AssetLogs(
            0, currentAsset.id, transferDate = LocalDateTime.now().toString(), LocalDateTime.MIN,
            currentAsset.assetSn,
            assetSN,
            currentAsset.departmentName,
            selectedDepartment,
            currentAsset.locationName,
            selectedLocation
        )

        Row {
            Button(onClick = {
                    appViewModel.viewModelScope.launch {
                        appViewModel.postTransferLog(assetTransferLog)
                        navHostController.popBackStack()
                    }
            }, Modifier.weight(1f)) {
                Text(text = "Submit")
            }

            Spacer(modifier = Modifier.padding(horizontal = 8.dp))

            Button(onClick = { navHostController.popBackStack() }, Modifier.weight(1f)) {
                Text(text = "Cancel")
            }
        }
    }

}