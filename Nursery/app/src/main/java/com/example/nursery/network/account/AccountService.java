package com.example.nursery.network.account;

import com.example.nursery.constants.Urls;

import java.util.concurrent.TimeUnit;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class AccountService {
    private static AccountService mInstance;
    private static final String BASE_URL = Urls.BASE_URL;
    private Retrofit retrofit;

    public AccountService() {
        OkHttpClient.Builder client = new OkHttpClient
                .Builder()
                .readTimeout(60, TimeUnit.SECONDS)
                .connectTimeout(60, TimeUnit.SECONDS);
        this.retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .client(client.build())
                .build();
    }

    public static AccountService getInstance() {
        if(mInstance == null)
            mInstance = new AccountService();
        return mInstance;
    }
    public AccountApi getJSONApi() {
        return retrofit.create(AccountApi.class);
    }
}
