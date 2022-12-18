package com.example.checkinternetconnection

import android.widget.Toast
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewModelScope
import androidx.navigation.NavController
import kotlinx.coroutines.launch

@Composable
fun EditWells(appViewModel: AppViewModel, navController: NavController, wellId: Int) {
    val wellInfo = appViewModel.getWellInformation(wellId)!!
    Scaffold(
        topBar = {
            TopAppBar(
                title = {
                    Text(text = "Well Information for ${wellInfo.wellName}")
                },
                navigationIcon = {
                    IconButton(onClick = { navController.popBackStack() }) {
                        Icon(Icons.Default.ArrowBack, contentDescription = null)
                    }
                }
            )
        },
    ) {
        paddingVal ->
        var wellName by rememberSaveable { mutableStateOf(wellInfo.wellName) }
        var originalWellName by rememberSaveable() { mutableStateOf(wellInfo.wellName) }
        var depthOfGas by rememberSaveable { mutableStateOf(wellInfo.gasOilDepth.toString()) }
        var wellCapacity by rememberSaveable { mutableStateOf(wellInfo.capacity.toString()) }
        var selectedWellLayer by rememberSaveable { mutableStateOf("") }
        var fromDepth by rememberSaveable { mutableStateOf("0") }
        var toDepth by rememberSaveable { mutableStateOf("0") }
        val context = LocalContext.current

        Column(Modifier
            .padding(paddingVal)
            .padding(4.dp)) {
            Column() {
                Text(text = "Well Name")
                TextField(
                    value = wellName,
                    onValueChange = { wellName = it },
                    modifier = Modifier.fillMaxWidth()
                )
            }

            Spacer(modifier = Modifier.padding(vertical = 4.dp))
            Row() {
                Column(modifier = Modifier.weight(0.7f)) {
                    Text("Depth of Gas or Oil extraction")
                    TextField(
                        value = depthOfGas,
                        onValueChange = { depthOfGas = it },
                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number),
                    )
                }
                Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                Column(modifier = Modifier.weight(0.3f)) {
                    Text("Well Capacity")
                    TextField(
                        value = wellCapacity,
                        onValueChange = { wellCapacity = it },
                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number),

                        )
                }

            }
            Spacer(modifier = Modifier.padding(vertical = 4.dp))
            Text("Rock Layers")
            Divider(Modifier.padding(horizontal = 2.dp))
            Spacer(modifier = Modifier.padding(vertical = 4.dp))

            DropDownList(
                items = appViewModel.rockTypeList.map { it.name },
                selectedItem = selectedWellLayer,
                onItemSelected = { selectedWellLayer = it }
            )

            Spacer(modifier = Modifier.padding(vertical = 4.dp))

            Row() {
                Column(Modifier.weight(1f)) {
                    Text("From Depth")
                    TextField(
                        value = fromDepth,
                        onValueChange = { fromDepth = it },
                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number),
                    )
                }
                Column(Modifier.weight(1f)) {
                    Text("To Depth")
                    TextField(
                        value = toDepth,
                        onValueChange = { toDepth = it },
                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number),
                    )
                }

                Button(
                    onClick = {
                        val result = appViewModel.verifyLayerAddition(selectedWellLayer, fromDepth.toInt(), toDepth.toInt(), depthOfGas.toInt())
                        if (result != "") Toast.makeText(context, result, Toast.LENGTH_SHORT).show()
                    },
                    modifier = Modifier.weight(1f)
                ) { Text("Add Layer") }
            }

            LazyColumn(
                Modifier
                    .fillMaxWidth()
                    .weight(1f)){
                items(appViewModel.addedWellLayers, itemContent = { layer -> WellLayerRow(
                    wellLayer = layer,
                    wellName = appViewModel.getRockInformation(layer.rockTypeId).name,
                    onRemove = { appViewModel.addedWellLayers.remove(it) },
                )
                })
            }

            Button(
                onClick = {
                    appViewModel.viewModelScope.launch {
                        val result = appViewModel.verifySubmitWelldata(wellName, depthOfGas.toInt(), wellCapacity.toInt(), originalWellName)
                        if (result != "")
                            Toast.makeText(context, result, Toast.LENGTH_SHORT).show()
                        else
                            navController.popBackStack()
                    }
                },
                Modifier.fillMaxWidth()
            ) {
                Text(text = "Submit")
            }
        }
    }
}