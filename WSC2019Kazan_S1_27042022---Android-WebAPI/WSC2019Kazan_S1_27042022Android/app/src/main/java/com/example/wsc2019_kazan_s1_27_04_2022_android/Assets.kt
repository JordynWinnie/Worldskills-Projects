package com.example.wsc2019_kazan_s1_27_04_2022_android

import com.google.gson.annotations.SerializedName
import java.time.LocalDateTime

data class Assets(
    val assetSn: String,
    val assetName: String,
    val departmentName: String,
    val locationName: String,
    val warrantyDate: String?,
    var parsedDate: LocalDateTime?,
    val assetGroupName: String,
    val description: String,
    val accountableParty: String,
    val assetPhoto1: String?,
    val id: Int = 0,
)

data class AssetPhoto(
    val assetId: Int,
    @SerializedName("assetPhoto1")
    val AssetPhoto: String
)

data class Department(
    val id: Int,
    val name: String
)

data class Location(
    val id: Int,
    val name: String
)

data class DepartmentLocations(
    val id: Int,
    val department_name: String,
    val location_name: String
)

data class AccountableParties(
    val id: Int,
    @SerializedName("firstName")
    val firstname: String,
    @SerializedName("lastName")
    val lastname: String,
    var fullname: String
)

data class AssetGroup(
    val id: Int,
    val name: String
)

data class AssetLogs(
    val id: Int,
    val assetId: Int,
    val transferDate: String,
    var parsedDate: LocalDateTime,
    val fromAssetSn: String,
    val toAssetSn: String,
    val fromDepartment: String,
    val toDepartment: String,
    val fromLocation: String,
    val toLocation: String
)