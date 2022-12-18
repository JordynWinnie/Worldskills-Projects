package com.example.wsc2019_kazan_s1_27_04_2022_android

import retrofit2.Response
import retrofit2.http.*

interface AssetsApi {
    @GET("/assets")
    suspend fun getAssets(
        @Query("id")
        id: Int?
    ): Response<List<Assets>>

    @GET("/departments")
    suspend fun getDepartments(): Response<List<Department>>

    @GET("/assetgroups")
    suspend fun getAssetGroup(): Response<List<AssetGroup>>

    @GET("/locations")
    suspend fun getLocation(): Response<List<Location>>

    @GET("/departmentlocations")
    suspend fun getDepartmentLocations(): Response<List<DepartmentLocations>>

    @GET("/accountableparties")
    suspend fun getAccountableParties(): Response<List<AccountableParties>>

    @POST("/postasset")
    suspend fun postAsset(@Body assets: Assets): Response<String>

    @PUT("/updateAsset")
    suspend fun putAsset(@Query("id") id: Int?, @Body assets: Assets): Response<Void>

    @POST("/addphoto")
    suspend fun postPhoto(@Body photo: AssetPhoto): Response<Void>

    @DELETE("/deletePhoto")
    suspend fun deletePhoto(@Query("id") id: Int?) : Response<Void>

    @GET("/assetTransferLogs")
    suspend fun getTransferLogs() : Response<List<AssetLogs>>

    @POST("/addAssetTransfer")
    suspend fun addTransferLog(
        @Body
        transferLog: AssetLogs
    ): Response<Void>

    @GET("/getPhotos")
    suspend fun getPhotos(
        @Query("id")
        id: Int?
    ) : Response<List<AssetPhoto>>
}