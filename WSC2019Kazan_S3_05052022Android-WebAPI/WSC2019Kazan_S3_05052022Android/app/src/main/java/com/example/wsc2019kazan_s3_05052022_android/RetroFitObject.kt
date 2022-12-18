package com.example.wsc2019kazan_s3_05052022_android

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetroFitObject {
    fun getInstance(): Retrofit{
        return Retrofit.Builder()
            .baseUrl("http://10.0.2.2:5132")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    }
}