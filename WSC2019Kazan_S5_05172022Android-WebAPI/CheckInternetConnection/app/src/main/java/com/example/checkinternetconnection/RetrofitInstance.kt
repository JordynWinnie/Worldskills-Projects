package com.example.checkinternetconnection

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitInstance {
    fun getInstance() : Retrofit {
        return Retrofit
            .Builder()
            .baseUrl("http://10.0.2.2:5085")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    }

}
