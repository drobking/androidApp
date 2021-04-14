package com.example.nursery.network.account;

import com.example.nursery.network.account.dto.LoginDTO;
import com.example.nursery.network.account.dto.LoginResultDTO;
import com.example.nursery.network.account.dto.RegisterDTO;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface AccountApi {
    @POST("/api/account/login")
    public Call<LoginResultDTO> login(@Body LoginDTO loginDTO);
    @POST("/api/account/registration")
    public Call<LoginResultDTO> register(@Body RegisterDTO registerDTO);
}
