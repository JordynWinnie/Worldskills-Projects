package com.example.wsc2019_kazan_s1_27_04_2022_android

import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.util.Log
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.launch
import java.io.ByteArrayOutputStream
import java.time.LocalDateTime
import java.util.*

class AppViewModel: ViewModel() {

    var bitmapImageStorage = mutableStateListOf<Bitmap?>()

    var isDataReady by mutableStateOf(false)

    var searchTerm by mutableStateOf("")
    var selectedDepartment by mutableStateOf("All")
    var selectedAssetGroup by mutableStateOf("All")

    var departmentList = mutableStateListOf<Department>()
    var assetGroupList = mutableStateListOf<AssetGroup>()

    var assetTransfers = mutableStateListOf<AssetLogs>()

    var departmentLocationList = mutableStateListOf<DepartmentLocations>()
    var accountablePartiesList = mutableStateListOf<AccountableParties>()

    var startDate by mutableStateOf<LocalDateTime?>(null)
    var endDate by mutableStateOf<LocalDateTime?>(null)

    var assetList = mutableStateListOf<Assets>()

    fun refreshData() {
        isDataReady = false
        viewModelScope.launch {
            val retroFit = RetrofitClient.getInstance()
            val apiInt = retroFit.create(AssetsApi::class.java)

            val assetResponse = apiInt.getAssets(null)
            if (assetResponse.isSuccessful){
                assetList.clear()
                assetList.addAll(assetResponse.body()!!)

                assetList.forEach {
                    it.parsedDate = if (it.warrantyDate != null) LocalDateTime.parse(it.warrantyDate) else null
                }
            }

            val departmentResponse = apiInt.getDepartments()
            if (departmentResponse.isSuccessful) {
                departmentList.clear()
                departmentList.addAll(departmentResponse.body()!!)
            }

            val accountablePartiesResponse = apiInt.getAccountableParties()
            if (accountablePartiesResponse.isSuccessful) {
                accountablePartiesList.clear()
                accountablePartiesList.addAll(accountablePartiesResponse.body()!!)

                accountablePartiesList.map {
                    it.fullname = "${it.firstname} ${it.lastname}"
                }
            }

            val assetGroupResponse = apiInt.getAssetGroup()
            if (assetGroupResponse.isSuccessful){
                assetGroupList.clear()
                assetGroupList.addAll(assetGroupResponse.body()!!)
            }

            val departmentLocationResponse = apiInt.getDepartmentLocations()
            if (departmentLocationResponse.isSuccessful){
                departmentLocationList.clear()
                departmentLocationList.addAll(departmentLocationResponse.body()!!)
            }

            val assetTransferLogsResponse = apiInt.getTransferLogs()
            if (assetTransferLogsResponse.isSuccessful){
                assetTransfers.clear()
                assetTransfers.addAll(assetTransferLogsResponse.body()!!)

                assetTransfers.map {
                    it.parsedDate = LocalDateTime.parse(it.transferDate)
                }
            }
        }
        isDataReady = true
    }

    suspend fun postAsset(assets: Assets): Int? {
        val retroFit = RetrofitClient.getInstance()
        val apiInt = retroFit.create(AssetsApi::class.java)

        return apiInt.postAsset(assets).body()!!.toInt()
    }

    suspend fun putAsset(assets: Assets, id: Int){
        val retroFit = RetrofitClient.getInstance()
        val apiInt = retroFit.create(AssetsApi::class.java)

        apiInt.putAsset(id, assets)
    }

    fun checkInputError(
        name: String,
        department: String,
        location: String,
        isEdit: Boolean,
        originalAssetId: Int
    ) : Boolean {
        Log.d("ValidateInput", "$name $department $location")
        val asset = assetList.find {
            it.id == originalAssetId
        }
        val count = assetList.filter {
            it.assetName == name && it.departmentName == department && it.locationName == location
        }

        if (isEdit) {
            Log.d("Counter", "Count: ${count.size} AssetNameFound: ${asset?.assetName} AssetNameTaken: $name")
            return asset?.assetName != name && count.isNotEmpty()
        }else {
            return count.isNotEmpty()
        }
    }
    fun getLocationByDepartment(department: String): List<String>{
        return departmentLocationList.filter {
            it.department_name == department
        }.map {
            it.location_name
        }
    }

    fun getUniqueId(department: String, assetGroup: String): String {
        Log.d("Dupe", "Duplicate Called")
        val depId = departmentList.find {
            it.name == department
        }?.id.toString().padStart(2, '0')

        val assId = assetGroupList.find {
            it.name == assetGroup
        }?.id.toString().padStart(2, '0')

        val findDupe = assetList.filter {
            it.assetSn.contains("$depId/$assId")
        }.map {
            Log.d("Dupe", "Duplicate Found: ${it.assetSn.substringAfterLast('/').toInt()}")
            it.assetSn.substringAfterLast('/').toInt()
        }
        Log.d("Dupe", findDupe.maxOrNull().toString())
        val number = ((findDupe.maxOrNull() ?: 0) + 1).toString().padStart(4, '0')

        return "$depId/$assId/$number"
    }

    fun getUniqueTransferId(assetId: Int, department: String, assetGroup: String): String
    {
        val id = assetTransfers.filter {
            it.assetId == assetId && it.fromDepartment == department
        }.maxByOrNull { it.parsedDate }

        return id?.fromAssetSn ?: getUniqueId(department = department, assetGroup = assetGroup)
    }

    fun getAssets(): List<Assets> {
        var tempAssets = assetList.filter {
            it.assetName.lowercase(Locale.getDefault()).contains(searchTerm)
        }

        if (selectedAssetGroup != "All"){
            tempAssets = tempAssets.filter {
                it.assetGroupName == selectedAssetGroup
            }
        }

        if (selectedDepartment != "All"){
            tempAssets = tempAssets.filter {
                it.departmentName == selectedDepartment
            }
        }

        if (startDate != null) {
            tempAssets = tempAssets.filter {
                if (it.parsedDate == null) false else it.parsedDate!! >= startDate
            }
        }

        if (endDate != null) {
            tempAssets = tempAssets.filter {
                if (it.parsedDate == null) false else it.parsedDate!! <= endDate
            }
        }

        tempAssets.forEach {
            Log.d("GetAssets", "getAssets: $it")
        }
        return tempAssets
    }

    suspend fun postTransferLog(assetLogs: AssetLogs){
        val retroFit = RetrofitClient.getInstance()
        val apiInt = retroFit.create(AssetsApi::class.java)
        apiInt.addTransferLog(assetLogs)
    }

    suspend fun deletePhotos(assetId: Int){
        val retroFit = RetrofitClient.getInstance()
        val apiInt = retroFit.create(AssetsApi::class.java)
        apiInt.deletePhoto(assetId)
    }

    suspend fun postPhotos(assetId: Int, bitmapPhotos: List<Bitmap?>) {
        val retroFit = RetrofitClient.getInstance()
        val apiInt = retroFit.create(AssetsApi::class.java)
        bitmapPhotos.map {
            val stream = ByteArrayOutputStream()
            it?.compress(Bitmap.CompressFormat.PNG, 100, stream)
            val encoded = Base64.getEncoder().encodeToString(stream.toByteArray())
            Log.d("PostPhoto", "postPhotos: $encoded")
            apiInt.postPhoto(AssetPhoto(assetId, encoded))
        }
    }

    fun getPhotos(id: Int){
        val retroFit = RetrofitClient.getInstance()
        val apiInt = retroFit.create(AssetsApi::class.java)

        viewModelScope.launch {
            val photoCall = apiInt.getPhotos(id).body()
            bitmapImageStorage.clear()
            photoCall?.forEach {
                val byteArray = Base64.getDecoder().decode(it.AssetPhoto)
                val bitmap = BitmapFactory.decodeByteArray(byteArray, 0, byteArray.size)
                bitmapImageStorage.add(bitmap)
            }
        }
    }

}