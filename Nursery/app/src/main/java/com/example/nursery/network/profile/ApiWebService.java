package com.example.nursery.network.profile;

import com.example.nursery.constants.Urls;
import com.example.nursery.network.interceptors.JWTInterceptor;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class ApiWebService {
    private static ApiWebService mInstance;
    private static final String BASE_URL = Urls.BASE_URL;
    private Retrofit mRetrofit;

    public ApiWebService() {

        OkHttpClient.Builder client = new OkHttpClient
                .Builder()
                .readTimeout(60, TimeUnit.SECONDS)
                .connectTimeout(60, TimeUnit.SECONDS)
                .addInterceptor(new JWTInterceptor());

        this.mRetrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .client(client.build())
                .build();
    }

    public static ApiWebService getInstance() {
        if(mInstance==null)
            mInstance=new ApiWebService();
        return mInstance;
    }

    public ApiWebRequest getJSONApi() {
        return mRetrofit.create(ApiWebRequest.class);
    }
}
