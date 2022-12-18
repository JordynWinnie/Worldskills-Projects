package com.example.wsc2019kazan_s3_05052022_android

import android.util.Log
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.compose.ui.graphics.Color
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import kotlinx.coroutines.launch
import java.time.LocalDate
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

class AppViewModel : ViewModel(){
    private val retrofitObject = RetroFitObject.getInstance()
    private val apiInstance: ApiClass = retrofitObject.create(ApiClass::class.java)

    private val pmTaskList = mutableStateListOf<PMTasks>()
    val taskList = mutableStateListOf<Tasks>()
    val assetList = mutableStateListOf<Asset>()

    var selectedDate: LocalDate by mutableStateOf(LocalDate.now())

    var scheduleModels = mutableStateListOf<ScheduleModel>()

    var selectedAssetName by mutableStateOf("")
    var selectedTask by mutableStateOf("")

    init {
        viewModelScope.launch {
            refreshData()
        }
    }

    suspend fun refreshData() {
        pmTaskList.clear()
        pmTaskList.addAll(apiInstance.getPMTasks().body()!!)
        pmTaskList.map {
            if (it.scheduleDate != null){
                it.parsedScheduleDate = LocalDateTime.parse(it.scheduleDate).toLocalDate()
            }
        }

        taskList.clear()
        taskList.addAll( apiInstance.getTasks().body()!!)

        assetList.clear()
        assetList.addAll(apiInstance.getAssets().body()!!)

        scheduleModels.clear()
        scheduleModels.addAll(apiInstance.getScheduleModel().body()!!)
    }
    fun updatePmList(asset: PMTasks, checked: Boolean){
        Log.d("Checked", "$checked")
        val temp = pmTaskList.find {
            it == asset
        }

        viewModelScope.launch {
            apiInstance.putPmTask(asset.id, checked)
        }

        val index = pmTaskList.indexOf(temp)
        temp?.taskDone = checked

        pmTaskList[index] = temp!!
    }

    fun getPmListWithFilter(localDateTime: LocalDate, asset: String, task: String): MutableList<PMTasks> {

        val runBasedNotProcessed = pmTaskList.filter {
            !it.taskDone && it.scheduleType == "By Milage"
        }

        runBasedNotProcessed.map {
            it.color = Color.Black
        }

        val runBasedProcessed = pmTaskList.filter {
            it.taskDone && it.scheduleType == "By Milage"
        }

        runBasedProcessed.map {
            it.color = Color.Gray
        }

        val timeBasedList = pmTaskList.filter {
            it.scheduleType != "By Milage"
        }


        val dueOnSameDayNotProcessed = timeBasedList.filter {
            !it.taskDone && it.parsedScheduleDate == localDateTime
        }

        dueOnSameDayNotProcessed.map {
            it.color = Color.Black
        }


        val dueOnSameDayProcessed = timeBasedList.filter {
            it.taskDone && it.parsedScheduleDate == localDateTime
        }

        dueOnSameDayProcessed.map {
            it.color = Color.Green
        }

        val dueIn4DaysNotProcessed = timeBasedList.filter {
            !it.taskDone && (localDateTime.plusDays(4) > it.parsedScheduleDate && localDateTime < it.parsedScheduleDate)
        }

        dueIn4DaysNotProcessed.map {
            it.color = Color.Magenta
        }

        val dueIn4DaysProcessed = timeBasedList.filter {
            it.taskDone && (localDateTime.plusDays(4) > it.parsedScheduleDate && localDateTime < it.parsedScheduleDate)
        }

        dueIn4DaysProcessed.map {
            it.color = Color.Black
        }

        val overDueNotProcessed = timeBasedList.filter {
            (it.parsedScheduleDate!! < localDateTime) && !it.taskDone
        }

        overDueNotProcessed.map {
            it.color = Color.Red
        }

        val overDueProcessed = timeBasedList.filter {
            (it.parsedScheduleDate!! < localDateTime ) && it.taskDone
        }

        overDueProcessed.map {
            it.color = Color.Yellow
        }

        var list: MutableList<PMTasks> = mutableListOf()

        list.addAll(runBasedNotProcessed)
        list.addAll(overDueNotProcessed)
        list.addAll(dueOnSameDayNotProcessed)
        list.addAll(dueIn4DaysNotProcessed)

        list.addAll(runBasedProcessed)
        list.addAll(overDueProcessed)
        list.addAll(dueIn4DaysProcessed)
        list.addAll(dueOnSameDayProcessed)

        if (asset != "None") {
            list = list.filter { it.assetName == asset } as MutableList<PMTasks>
        }

        if (task != "None"){
            list = list.filter { it.taskName == task } as MutableList<PMTasks>
        }


        return list
    }

    suspend fun findAssetLimit(
        startingKm: Int,
        endingKm: Int,
        step: Int,
        tempAssetList: List<Asset>,
        selectedTask: String
    ): List<Int> {
        val intList = mutableListOf<Int>()
        tempAssetList.forEach {
            asset ->
            var assetList = pmTaskList.filter {
                it.assetName == asset.assetName && it.scheduleKilometer != null
            }

            assetList = assetList.sortedBy {
                it.scheduleKilometer
            }

            for (i in assetList.indices - 1) {
                Log.d("MinMax", "findAssetLimit: ${assetList[i].scheduleKilometer!!}")
                if (startingKm >= assetList[i].scheduleKilometer!! && startingKm <= assetList[i+1].scheduleKilometer!!) {
                    return listOf()
                }

                if (endingKm >= assetList[i].scheduleKilometer!! && endingKm <= assetList[i+1].scheduleKilometer!!) {
                    return listOf()
                }
            }
        }
        val taskId = taskList.first {
            it.name == selectedTask
        }
        for (i in startingKm..endingKm step step){
            intList.add(i)
        }

        tempAssetList.forEach {
                asset ->
            intList.forEach {
                    kilometer ->
                val newPmTask = PostPmTask(asset.id, taskId.id, 1, null, kilometer)
                apiInstance.postPmTask(newPmTask)
            }
        }

        return intList
    }


    suspend fun calculateTimePeriod(
        calculationType: String,
        gapInDays: Int,
        startDateTime: LocalDate,
        endDateTime: LocalDate,
        tempAssetList: List<Asset>,
        selectedTask: String,
        ) : List<LocalDate> {

        val dateTimeList = mutableListOf<LocalDate>()
        var tempDateTime = startDateTime

        dateTimeList.add(startDateTime)

        while (tempDateTime < endDateTime) {
            when (calculationType) {
                "Daily" -> tempDateTime = tempDateTime.plusDays(gapInDays.toLong())
                "Weekly" -> tempDateTime = tempDateTime.plusWeeks(gapInDays.toLong())
                "Monthly" -> tempDateTime = tempDateTime.plusMonths(gapInDays.toLong())
            }
            if (tempDateTime <= endDateTime) {
                dateTimeList.add(tempDateTime)
            }
        }
        val taskName = taskList.first {
            it.name == selectedTask
        }

        tempAssetList.forEach {
                asset ->
            dateTimeList.forEach {
                    localDate ->
                val newPmTask = PostPmTask(asset.id, taskName.id, 2, localDate.format(
                    DateTimeFormatter.ISO_DATE), null)
                Log.d("Posted:", "$newPmTask")
                apiInstance.postPmTask(newPmTask)
            }
        }

        return dateTimeList
    }
}