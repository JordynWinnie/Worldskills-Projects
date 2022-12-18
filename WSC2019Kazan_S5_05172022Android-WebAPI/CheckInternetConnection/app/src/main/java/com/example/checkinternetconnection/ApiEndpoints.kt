package com.example.checkinternetconnection

import retrofit2.Response
import retrofit2.http.*

interface ApiEndpoints {
    @GET("/getWells")
    suspend fun getWell() : Response<List<Wells>>

    @GET("/getLayers")
    suspend fun getLayers() : Response<List<WellLayer>>

    @GET("/getRockTypes")
    suspend fun getRockTypes() : Response<List<RockTypes>>

    @POST("/postWell")
    suspend fun postWell(@Body well: Wells) : Response<Void>

    @POST("/postLayer")
    suspend fun postLayer(@Query("wellName") wellName: String, @Body wellLayer: WellLayer) : Response<Void>

    @PUT("/editWell")
    suspend fun editWell(@Body well: Wells) : Response<Void>
}