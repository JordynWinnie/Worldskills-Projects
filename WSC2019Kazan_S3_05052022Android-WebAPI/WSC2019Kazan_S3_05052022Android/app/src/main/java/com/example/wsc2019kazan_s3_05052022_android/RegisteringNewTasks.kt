package com.example.wsc2019kazan_s3_05052022_android

import android.widget.Toast
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.material.icons.filled.Delete
import androidx.compose.material.icons.filled.Place
import androidx.compose.runtime.*
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewModelScope
import androidx.navigation.NavHostController
import kotlinx.coroutines.launch
import java.lang.NumberFormatException
import java.time.LocalDate

@Composable
fun MaintenanceTasks(appViewModel: AppViewModel, navHostController: NavHostController) {
    Scaffold(
        topBar = {
             TopAppBar(
                 title = {
                     Text(text = "Create PM")
                 },
                 navigationIcon = {
                     IconButton(onClick = { navHostController.popBackStack() }) {
                         Icon(Icons.Default.ArrowBack, contentDescription = null)
                     }
                 },
             )
        },
    ) { paddingValues ->
        var selectedTask by rememberSaveable {
            mutableStateOf("")
        }

        val tempAssetList = remember {
            mutableStateListOf<Asset>()
        }

        var selectedAsset by rememberSaveable {
            mutableStateOf("")
        }

        var selectedScheduleModel by rememberSaveable {
            mutableStateOf("")
        }

        var selectedStartDate by rememberSaveable {
            mutableStateOf(LocalDate.now())
        }

        var selectedEndDate by rememberSaveable {
            mutableStateOf(LocalDate.now())
        }

        val assetListDisplay = appViewModel.assetList.map { it.assetName }.toMutableList()

        val taskListDisplay = appViewModel.taskList.map { it.name }.toMutableList()

        val scheduleModelDisplay = appViewModel.scheduleModels.map { it.name }.toMutableList()

        Column(modifier = Modifier
            .padding(paddingValues)
            .padding(4.dp)) {
            JetpackSpinner(items = taskListDisplay, selectedItem = selectedTask, onItemSelected = { selectedTask = it })

            Spacer(modifier = Modifier.padding(vertical = 4.dp))

            Column(Modifier.weight(0.4f)) {
                Row {
                    JetpackSpinner(items = assetListDisplay, selectedItem = selectedAsset, onItemSelected = { selectedAsset = it }, modifier = Modifier.weight(
                        1f
                    ))
                    Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                    Button(onClick = {
                        val assetToFind = appViewModel.assetList.find { it.assetName == selectedAsset }!!
                        if (!tempAssetList.contains(assetToFind)){
                            tempAssetList.add(assetToFind)
                        }

                    }, Modifier.weight(1f)) {
                        Text(text = "Add to list")
                    }
                }

                LazyColumn(Modifier.weight(0.2f)){
                    items(tempAssetList) { it ->
                        AssetRow(it) { tempAssetList.remove(it) }
                    }
                }
            }

            var gapInDays by rememberSaveable {
                mutableStateOf("1")
            }

            var startRange by rememberSaveable {
                mutableStateOf("1")
            }

            var endRange by rememberSaveable {
                mutableStateOf("1")
            }

            var distanceBetween by rememberSaveable {
                mutableStateOf("1")
            }

            val onStartDateSelect: (LocalDate) -> Unit = { selectedStartDate = it }
            val onEndDateSelect: (LocalDate) -> Unit = { selectedEndDate = it }
            val context = LocalContext.current

            val calculateTimeOnClick: () -> Unit = {
                if (selectedEndDate < selectedStartDate) {
                    Toast.makeText(context, "End Date should not be before start date", Toast.LENGTH_SHORT).show()
                }
                else
                {
                    try {
                        val gap = gapInDays.toInt()

                        when {
                            gap <= 0 -> {
                                Toast.makeText(context, "Gap number should be more than 0", Toast.LENGTH_SHORT).show()
                            }
                            tempAssetList.isEmpty() -> {
                                Toast.makeText(context, "Asset List is Empty", Toast.LENGTH_SHORT).show()
                            }
                            else -> {
                                appViewModel.viewModelScope.launch {
                                    appViewModel.calculateTimePeriod(selectedScheduleModel, gap, selectedStartDate, selectedEndDate, tempAssetList, selectedTask)
                                    appViewModel.refreshData()
                                    navHostController.popBackStack()
                                }

                            }
                        }
                    } catch (e: NumberFormatException){
                        Toast.makeText(context, "Number is invalid", Toast.LENGTH_SHORT).show()
                    }

                }
            }

            val calculateKiloMeterOnClick: () -> Unit = {
                try {
                    val startNumber = startRange.toInt()
                    val endNumber = endRange.toInt()
                    val distBetween = distanceBetween.toInt()

                    when {
                        tempAssetList.isEmpty() -> {
                            Toast.makeText(context, "Asset list is empty", Toast.LENGTH_SHORT).show()
                        }
                        startNumber < 0 -> {
                            Toast.makeText(context, "Start Range should not be negative", Toast.LENGTH_SHORT).show()
                        }
                        endNumber <= 0 -> {
                            Toast.makeText(context, "End Range should be more than 0", Toast.LENGTH_SHORT).show()
                        }
                        distBetween <= 0 -> {
                            Toast.makeText(context, "Distance between checks should be more than 0", Toast.LENGTH_SHORT).show()
                        }

                        endNumber <= startNumber -> {
                            Toast.makeText(context, "End range should be larger than start range", Toast.LENGTH_SHORT).show()
                        }
                        else ->
                            appViewModel.viewModelScope.launch {
                                if (appViewModel.findAssetLimit(startNumber, endNumber, distBetween, tempAssetList, selectedTask).isEmpty())  {
                                    Toast.makeText(context, "Cannot add range that already exists", Toast.LENGTH_SHORT).show()
                                }else {
                                    appViewModel.refreshData()
                                    navHostController.popBackStack()
                                }
                            }

                    }
                }catch (e: NumberFormatException){
                    Toast.makeText(context, "One of the numbers is invalid", Toast.LENGTH_SHORT).show()
                }
            }

            Spacer(modifier = Modifier.padding(vertical = 4.dp))
            Column(Modifier.weight(0.6f)) {
                JetpackSpinner(
                    items = scheduleModelDisplay,
                    selectedItem = selectedScheduleModel,
                    onItemSelected = { selectedScheduleModel = it }
                )

                Spacer(modifier = Modifier.padding(vertical = 4.dp))

                when (selectedScheduleModel) {
                    "Daily" -> {
                        DateSelectors(selectedStartDate, selectedEndDate, onStartDateSelect, onEndDateSelect)
                        Spacer(modifier = Modifier.padding(vertical = 4.dp))
                        Row {
                            Text(text = "Gap In Days:", Modifier.weight(1f))
                            TextField(value = gapInDays, onValueChange = {gapInDays = it}, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = Modifier.weight(1f))
                        }
                    }
                    "Weekly" -> {
                        DateSelectors(selectedStartDate, selectedEndDate, onStartDateSelect, onEndDateSelect)
                        Spacer(modifier = Modifier.padding(vertical = 4.dp))
                        Row {
                            Text(text = "Number Of Weeks:", Modifier.weight(1f))
                            TextField(value = gapInDays, onValueChange = {gapInDays = it}, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = Modifier.weight(1f))
                        }

                    }
                    "Monthly" -> {
                        DateSelectors(selectedStartDate, selectedEndDate, onStartDateSelect, onEndDateSelect)
                        Spacer(modifier = Modifier.padding(vertical = 4.dp))
                        Row {
                            Text(text = "Number Of Months:", Modifier.weight(1f))
                            TextField(value = gapInDays, onValueChange = {gapInDays = it}, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = Modifier.weight(1f))
                        }
                    }
                    "Every X Kilometer" -> {
                        Spacer(modifier = Modifier.padding(vertical = 4.dp))
                        Row {
                            Text(text = "Start Range:", Modifier.weight(1f))
                            TextField(value = startRange, onValueChange = {startRange = it}, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = Modifier.weight(1f))
                        }

                        Row {
                            Text(text = "End Range:", Modifier.weight(1f))
                            TextField(value = endRange, onValueChange = {endRange = it}, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = Modifier.weight(1f))
                        }

                        Row {
                            Text(text = "Check Between:", Modifier.weight(1f))
                            TextField(value = distanceBetween, onValueChange = {distanceBetween = it}, keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Number), modifier = Modifier.weight(1f))
                        }


                    }
                }


            }


            Row {
                Button(onClick = if (selectedScheduleModel == "Every X Kilometer") calculateKiloMeterOnClick else calculateTimeOnClick, Modifier.weight(1f)) {
                    Text(text = "Submit")
                }
                Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                Button(onClick = { navHostController.popBackStack() }, Modifier.weight(1f)) {
                    Text(text = "Cancel")
                }
            }
        }
    }
}

@Composable
fun DateSelectors(
    selectedStartDate: LocalDate,
    selectedEndDate: LocalDate,
    onSelectStartDate: (LocalDate) -> Unit,
    onSelectEndDate: (LocalDate) -> Unit
) {
    Row {
        DateSelector(selectedDate = selectedStartDate, onClick = onSelectStartDate,
            Modifier.weight(1f))
        Spacer(modifier = Modifier.padding(horizontal = 4.dp))
        DateSelector(selectedDate = selectedEndDate, onClick = onSelectEndDate, Modifier.weight(1f))
    }
}

@Composable
fun AssetRow(asset: Asset, onRemove: (Asset) -> Unit) {
    Row(verticalAlignment = Alignment.CenterVertically, modifier = Modifier.padding(vertical = 4.dp)) {
        Image(Icons.Default.Place, contentDescription = null,
            Modifier
                .size(48.dp))
        Spacer(modifier = Modifier.padding(horizontal = 4.dp))
        Column(Modifier.weight(1f)) {
            Text(text = asset.assetName, maxLines = 1, overflow = TextOverflow.Ellipsis)
        }
        IconButton(onClick = { onRemove(asset) }){
            Icon(Icons.Default.Delete, contentDescription = null)
        }
    }
}




