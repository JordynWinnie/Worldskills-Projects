package com.example.wsc2019_kazan_s1_27_04_2022_android

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitClient {
    fun getInstance(): Retrofit {
        return Retrofit.Builder()
            .baseUrl("http://10.0.2.2:5006")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    }
}