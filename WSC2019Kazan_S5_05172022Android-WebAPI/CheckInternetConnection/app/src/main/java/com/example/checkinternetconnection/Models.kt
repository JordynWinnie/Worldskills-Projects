package com.example.checkinternetconnection

data class Wells(
    val id: Int,
    val wellTypeId: Int,
    val wellName: String,
    val gasOilDepth: Int,
    val capacity: Int
)

data class WellLayer(
    var id: Int,
    val wellId: Int,
    val rockTypeId: Int,
    val startPoint: Int,
    val endPoint: Int,
    val layerName: String?
)

data class RockTypes(
    val id: Int,
    val name: String,
    val backgroundColor : String,
)