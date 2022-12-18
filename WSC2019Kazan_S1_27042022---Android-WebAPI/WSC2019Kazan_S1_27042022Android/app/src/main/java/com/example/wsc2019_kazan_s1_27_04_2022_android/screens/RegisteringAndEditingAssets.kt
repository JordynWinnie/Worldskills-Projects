package com.example.wsc2019_kazan_s1_27_04_2022_android.screens

import android.R
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.provider.MediaStore
import android.util.Log
import android.widget.Toast
import androidx.activity.compose.rememberLauncherForActivityResult
import androidx.activity.result.contract.ActivityResultContracts
import androidx.activity.result.launch
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.itemsIndexed
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.material.icons.filled.Close
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.asImageBitmap
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.core.content.ContextCompat
import androidx.lifecycle.viewModelScope
import androidx.navigation.NavHostController
import com.example.wsc2019_kazan_s1_27_04_2022_android.AppViewModel
import com.example.wsc2019_kazan_s1_27_04_2022_android.Assets
import com.example.wsc2019_kazan_s1_27_04_2022_android.components.DateSelector
import com.example.wsc2019_kazan_s1_27_04_2022_android.components.Spinner
import kotlinx.coroutines.launch
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter


@Composable
fun RegisteringAssets(appViewModel: AppViewModel, navHostController: NavHostController, assetId: Int) {
        val isEdit = assetId != -1
        var assetToEdit: Assets? = null
        var fetchEditedAssets by rememberSaveable {
            mutableStateOf(true)
        }
        if (isEdit && fetchEditedAssets)
        {
            Log.d("AssetFetching", "Fetched Assets")
            assetToEdit = appViewModel.assetList.find {
                it.id == assetId
            }
            appViewModel.getPhotos(assetToEdit!!.id)
            fetchEditedAssets = false
        }
        Scaffold(
            topBar = {
                TopAppBar(
                    title = { Text(text = "Asset Information") },
                    navigationIcon = {
                        IconButton(onClick = { navHostController.popBackStack() }) {
                            Icon(
                                Icons.Default.ArrowBack,
                                contentDescription = null)
                        }

                    }
                )
            }
        ) {
            Column(Modifier
                .fillMaxWidth()
                .padding(8.dp)) {
                var assetSN by rememberSaveable { mutableStateOf(assetToEdit?.assetSn ?: "")
                }
                var selectedDepartment by rememberSaveable { mutableStateOf(assetToEdit?.departmentName ?: "") }
                var selectedAssetGroup by rememberSaveable { mutableStateOf(assetToEdit?.assetGroupName ?: "") }
                var selectedAccountableParty by rememberSaveable { mutableStateOf(assetToEdit?.accountableParty ?: "") }
                var selectedLocation by rememberSaveable { mutableStateOf(assetToEdit?.locationName ?: "") }

                var assetName by rememberSaveable {
                    mutableStateOf(assetToEdit?.assetName ?: "")
                }

                var assetDescription by rememberSaveable { mutableStateOf(assetToEdit?.description ?: "") }
                var selectedTime by rememberSaveable { mutableStateOf<LocalDateTime?>(assetToEdit?.parsedDate) }

                Column {
                    val isError = appViewModel.checkInputError(assetName, selectedDepartment, selectedLocation, isEdit, assetId)
                    TextField(
                        value = assetName,
                        onValueChange = { assetName = it },
                        isError = isError,
                        placeholder = { Text(text = "Asset Name") },
                        modifier = Modifier.fillMaxWidth(),
                    )
                    if (isError){
                        Text(
                            color = androidx.compose.ui.graphics.Color.Red,
                            text = "Items in the same location should not have the same name",
                        )
                    }
                }

                Spacer(modifier = Modifier.padding(vertical = 4.dp))
                val departments = appViewModel.departmentLocationList.map { it.department_name }.distinct()

                val assetGroups = appViewModel.assetGroupList.map { it.name }

                val accountableParties = appViewModel.accountablePartiesList.map {
                    it.fullname
                }

                Row {
                    //Departments:
                    Spinner(
                        spinnerItems = departments,
                        selectedItem = selectedDepartment,
                        onItemSelected = { selectedDepartment = it },
                        modifier = Modifier.weight(1f),
                        !isEdit
                    )
                    Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                    val locations = appViewModel.getLocationByDepartment(selectedDepartment)
                    // Locations:
                    Spinner(
                        spinnerItems = locations,
                        selectedItem = selectedLocation,
                        onItemSelected = { selectedLocation = it },
                        modifier = Modifier.weight(1f),
                        !isEdit
                    )
                }
                Spacer(modifier = Modifier.padding(vertical = 4.dp))
                Row {
                    // AssetGroups:
                    Spinner(
                        spinnerItems = assetGroups,
                        selectedItem = selectedAssetGroup,
                        onItemSelected = {selectedAssetGroup = it },
                        modifier = Modifier.weight(1f),
                        !isEdit
                    )


                    if (!isEdit){
                        Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                        //Accountable Party:
                        Spinner(
                            spinnerItems = accountableParties,
                            selectedItem = selectedAccountableParty,
                            onItemSelected = {selectedAccountableParty = it},
                            modifier = Modifier.weight(1f)
                        )
                    }

                }
                Spacer(modifier = Modifier.padding(vertical = 4.dp))

                TextField(
                    value = assetDescription,
                    onValueChange = { assetDescription = it },
                    placeholder = { Text(text = "Asset Description") },
                    modifier = Modifier.fillMaxWidth()
                )

                Spacer(modifier = Modifier.padding(vertical = 4.dp))

                Row(verticalAlignment = Alignment.CenterVertically) {
                    DateSelector(
                        modifier = Modifier
                            .fillMaxWidth()
                            .weight(1f),
                        dateTime = selectedTime,
                        onDateSelected = { selectedTime = it }

                    )
                    Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                    assetSN = appViewModel.getUniqueId(selectedDepartment, selectedAssetGroup)
                    Text(text = "Asset SN: ${assetSN}", modifier = Modifier
                        .fillMaxWidth()
                        .weight(1f))
                }

                Spacer(modifier = Modifier.padding(vertical = 4.dp))


                val contentRes = LocalContext.current.contentResolver
                Row {
                    val perms = rememberLauncherForActivityResult(ActivityResultContracts.RequestPermission()) {
                    }

                    val cameraCapture = rememberLauncherForActivityResult(ActivityResultContracts.TakePicturePreview()){
                        if (it != null){
                            appViewModel.bitmapImageStorage.add(it)
                            Log.d("Image", "Camera Captured")
                        }
                    }

                    val getGallery = rememberLauncherForActivityResult(ActivityResultContracts.GetContent()){
                        if (it != null) {
                            val bitmap = MediaStore.Images.Media.getBitmap(contentRes, it)
                            appViewModel.bitmapImageStorage.add(bitmap)
                        }
                    }
                    val context = LocalContext.current

                    Button(
                        onClick = { when (ContextCompat.checkSelfPermission(context, android.Manifest.permission.CAMERA)){
                            PackageManager.PERMISSION_GRANTED -> {
                                cameraCapture.launch()
                            }
                            else -> perms.launch(android.Manifest.permission.CAMERA)
                        } },
                        modifier = Modifier
                            .fillMaxWidth()
                            .weight(1f)
                    ) {
                        Text(text = "Capture Image")
                    }
                    Spacer(modifier = Modifier.padding(horizontal = 4.dp))
                    Button(
                        onClick = { getGallery.launch("image/*") },
                        modifier = Modifier
                            .fillMaxWidth()
                            .weight(1f)
                    ) {
                        Text(text = "Browse for Image")
                    }
                }

                LazyColumn(Modifier
                    .fillMaxWidth()
                    .weight(1f)){
                    itemsIndexed(appViewModel.bitmapImageStorage) {
                            index, item -> ImageRow(bitmap = item!!, idx = index) {
                        appViewModel.bitmapImageStorage.remove(item)
                    }
                    }
                }

                Row {
                    val postAsset = Assets(
                        assetSN,
                        assetName,
                        selectedDepartment,
                        selectedLocation,
                        selectedTime?.format(
                            DateTimeFormatter.ISO_DATE_TIME),
                        null,
                        selectedAssetGroup,
                        assetDescription,
                        selectedAccountableParty,
                        null
                    )
                    val context = LocalContext.current
                    Button(
                        onClick = {
                            if (isEdit){
                                Log.d("PostAssetData", postAsset.toString())
                                appViewModel.viewModelScope.launch {
                                    appViewModel.putAsset(postAsset, assetId)
                                    appViewModel.deletePhotos(assetId)
                                    appViewModel.postPhotos(assetId, appViewModel.bitmapImageStorage)
                                    navHostController.popBackStack()
                                }
                            }else {
                                appViewModel.viewModelScope.launch {
                                    val newassetId = appViewModel.postAsset(assets = postAsset)

                                    Log.d("NewAsset", "$newassetId")

                                    appViewModel.postPhotos(newassetId!!, appViewModel.bitmapImageStorage)
                                    navHostController.popBackStack()
                                }
                            }
                            appViewModel.refreshData()
                            Toast.makeText(context, "Asset posted", Toast.LENGTH_SHORT).show()
                        },
                        modifier = Modifier
                            .fillMaxWidth()
                            .weight(1f)
                    ) {
                        Text(text = "Submit")
                    }
                    Spacer(modifier = Modifier.padding(horizontal = 4.dp))

                    Button(
                        onClick = { navHostController.popBackStack() },
                        modifier = Modifier
                            .fillMaxWidth()
                            .weight(1f)
                    ) {
                        Text(text = "Cancel")
                    }
                }

            }
        }
}


@Preview
@Composable
fun ImageRowPrev() {
    val resource = LocalContext.current.resources
    val bm = BitmapFactory.decodeResource(resource, R.drawable.arrow_up_float)
    ImageRow(bitmap = bm, idx = 1) {

    }
}

@Composable
fun ImageRow(bitmap: Bitmap, idx: Int, onRemoveClick: () -> Unit) {
    Row(
        Modifier.fillMaxWidth(),
        horizontalArrangement = Arrangement.SpaceBetween,
        verticalAlignment = Alignment.CenterVertically
    ) {
        Image(
            bitmap.asImageBitmap(),
            contentDescription = null,
            modifier = Modifier
                .padding(4.dp)
                .size(64.dp),
        )
        Text(text = "Image $idx", modifier = Modifier.weight(1f))
        IconButton(onClick = onRemoveClick) {
            Icon(Icons.Default.Close, contentDescription = null)
        }
    }
}