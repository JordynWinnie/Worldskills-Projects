package com.example.wsc2019_kazan_s1_27_04_2022_android.screens

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.LocationOn
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.example.wsc2019_kazan_s1_27_04_2022_android.AppViewModel
import com.example.wsc2019_kazan_s1_27_04_2022_android.AssetLogs
import java.time.format.DateTimeFormatter

@Composable
fun TransferHistory(appViewModel: AppViewModel, assetId: Int, navController: NavController) {
    Scaffold(topBar = {
        TopAppBar(title = { Text(text = "Transfer History") } ) 
    }
    ) {
        Column(Modifier.padding(8.dp)) {
            val assetTransfers = appViewModel.assetTransfers.filter {
                it.assetId == assetId
            }.sortedByDescending {
                it.parsedDate
            }

            if (assetTransfers.isNotEmpty()){
                LazyColumn(Modifier.weight(1f)){
                    items(assetTransfers) {
                        TransferRow(it)
                    }
                }
            }else
            {
                Text(text = "There is no transfer History", Modifier.weight(1f))
            }

            Button(onClick = {navController.popBackStack() }, Modifier.fillMaxWidth()) {
                Text(text = "Back")
            }
        }

    }   
}



@Composable
fun TransferRow(assetLogs: AssetLogs){
    Row(
        Modifier
            .fillMaxWidth()
            .padding(8.dp), verticalAlignment = Alignment.CenterVertically, ) {
        Icon(Icons.Default.LocationOn, contentDescription = null, Modifier.size(64.dp))
        Spacer(Modifier.padding(horizontal = 8.dp))
        Column {
            Text(text = "Relocation Date: ${assetLogs.parsedDate.format(DateTimeFormatter.ofPattern("dd/MM/y"))}")
            Row {
                Text(text = assetLogs.fromDepartment)
                Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                Text(text = assetLogs.fromAssetSn, color = Color.Red)
            }

            Row {
                Text(text = assetLogs.toDepartment)
                Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                Text(text = assetLogs.toAssetSn, color = Color.Red)
            }

        }
    }
}