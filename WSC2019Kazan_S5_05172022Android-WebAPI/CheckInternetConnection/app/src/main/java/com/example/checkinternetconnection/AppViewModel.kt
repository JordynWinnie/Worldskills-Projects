package com.example.checkinternetconnection


import android.util.Log
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.launch
import java.lang.Exception
import java.time.LocalDateTime

class AppViewModel(): ViewModel()
{
    var TAG = "ViewModel"
    var networkStatus by mutableStateOf(false)
    var retrofitObject = RetrofitInstance.getInstance()
    var apiInstance = retrofitObject.create(ApiEndpoints::class.java)

    var selectedWell by mutableStateOf("")
    var wellList = mutableStateListOf<Wells>()

    var wellLayerList = mutableStateListOf<WellLayer>()
    var rockTypeList = mutableStateListOf<RockTypes>()

    var addedWellLayers = mutableStateListOf<WellLayer>()
    var lastUpdatedTime: LocalDateTime = LocalDateTime.now()

    fun refreshData() {
        viewModelScope.launch {
            try {
                wellList.clear()
                wellLayerList.clear()
                rockTypeList.clear()
                var wellRequest = apiInstance.getWell()
                var wellLayerRequest = apiInstance.getLayers()
                val rockTypeRequest = apiInstance.getRockTypes()

                if (wellRequest.isSuccessful) {
                    wellList.addAll(wellRequest.body()!!)
                }

                if (wellLayerRequest.isSuccessful){
                    wellLayerList.addAll(wellLayerRequest.body()!!)
                    Log.d(TAG, "${wellLayerRequest.body()}")
                }

                if (rockTypeRequest.isSuccessful) {
                    rockTypeList.addAll(rockTypeRequest.body()!!)
                }
            }
            catch (e: Exception) {

            }

        }
    }

    fun getWellInformation(wellName: String): Wells? {
        val wellId = wellList.find {
            it.wellName == wellName
        }
        return wellId
    }

    fun getWellInformation(wellId: Int): Wells? {
        val wellId = wellList.find {
            it.id == wellId
        }
        return wellId
    }

    fun getRockInformation(rockId: Int) : RockTypes {
        return rockTypeList.find { it.id == rockId }!!
    }

    fun getLayers(wellName: String) : List<WellLayer> {
        val wellId = getWellInformation(wellName)
        return if (wellId == null) listOf() else wellLayerList.filter { it.wellId == wellId.id }
    }



    fun getWellLayer(rockName: String, fromDepth: Int, toDepth: Int) : WellLayer {
        val rockTypeId = rockTypeList.find {
            it.name == rockName
        }

        return WellLayer(0, 0, rockTypeId!!.id, fromDepth, toDepth, rockName)
    }

    fun addWellInformation(wellId: Int) {
        addedWellLayers.addAll(
            wellLayerList.filter {
                it.wellId == wellId
            }
        )
    }

    fun verifyLayerAddition(rockName: String, fromDepth: Int, toDepth: Int, fullDepth: Int) : String {
        val rockTypeId = rockTypeList.find {
            it.name == rockName
        }!!

        if (toDepth - fromDepth < 100) return "Depth of layer cannot be less than 100"

        if (addedWellLayers.any { it.rockTypeId ==  rockTypeId.id}) return "Cannot add duplicate layer"

        if (toDepth > fullDepth) return "Cannot add beyond the full depth of the well"

        addedWellLayers.forEach {
            if (fromDepth >= it.startPoint && fromDepth < it.endPoint) return "Cannot add in the same depth"
            if (toDepth >= it.startPoint && toDepth < it.endPoint) return "Cannot add in the same depth"
        }

        addedWellLayers.add(WellLayer(0, 0, rockTypeId.id, fromDepth, toDepth, rockName))

        return ""
    }

    suspend fun verifySubmitWelldata(wellName: String, gasOilDepth: Int, capacity: Int, originalWellName: String = "") : String {
        if (wellList.filter { it.wellName != wellName }.any {wellName.trim() == it.wellName.trim()}) return "Well Names should be unique"
        if (!addedWellLayers.any { it.startPoint == 0}) return "There should be a zero starting point"
        if (addedWellLayers.any { it.endPoint > gasOilDepth }) return "Cannot add beyond the full depth of the well"

        if (originalWellName != "") {
            val wellId = wellList.find { it.wellName == originalWellName }
            val editWell = apiInstance.editWell(Wells(wellId!!.id, 1, wellName, gasOilDepth, capacity))

            if (editWell.isSuccessful) {
                addedWellLayers.forEach {
                    it.id = 0

                    apiInstance.postLayer(wellName, it)
                }
            }
        }else {
            val postWell = apiInstance.postWell(Wells(0, 1, wellName, gasOilDepth, capacity))
            if (postWell.isSuccessful) {
                addedWellLayers.forEach {
                    apiInstance.postLayer(wellName, it)
                }
            }
        }
        refreshData()
        return ""
    }
}