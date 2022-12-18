package com.example.wsc2019kazan_s3_05052022_android

import retrofit2.Response
import retrofit2.http.*

interface ApiClass {
    @GET("/getPMTasks")
    suspend fun getPMTasks(): Response<List<PMTasks>>

    @GET("/getAssets")
    suspend fun getAssets(): Response<List<Asset>>

    @GET("/getTasks")
    suspend fun getTasks(): Response<List<Tasks>>

    @PUT("/putAsset")
    suspend fun putPmTask(
        @Query("taskId")
        taskId: Int,
        @Query("status")
        status: Boolean
    )

    @GET("/getScheduleModels")
    suspend fun getScheduleModel(): Response<List<ScheduleModel>>

    @POST("/postPmTask")
    suspend fun postPmTask(@Body pmTasks: PostPmTask): Response<Void>
}