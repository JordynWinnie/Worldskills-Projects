package com.example.wsc2019kazan_s3_05052022_android


import androidx.compose.ui.graphics.Color
import java.time.LocalDate

data class PMTasks(
    val scheduleDate: String?,
    val id: Int,
    val assetName: String,
    val assetSn: String,
    val taskName: String,
    val scheduleType: String,
    var parsedScheduleDate: LocalDate?,
    val scheduleKilometer: Int?,
    var taskDone: Boolean,
    var color: Color
)

data class Tasks(
    val id: Int,
    val name: String
)

data class Asset(
    val id: Int,
    val assetSn: String,
    val assetName: String,
    val departmentLocationId: Int,
    val employeeId: Int,
    val assetGroupId: Int,
    val description: String,
)

data class ScheduleModel(
    val id: Int,
    val name: String,
    val pmscheduleTypeId: Int
)

data class PostPmTask(
    val assetID: Int,
    val taskID: Int,
    val PMScheduleTypeID: Int,
    val scheduleDate: String?,
    val scheduleKilometer: Int?
)