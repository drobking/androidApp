package com.example.nursery.network.profile;

import com.example.nursery.network.profile.dto.ProfileResultDTO;

import retrofit2.Call;
import retrofit2.http.GET;

public interface ApiWebRequest {
    @GET("/api/Users/profile")
    public Call<ProfileResultDTO> profile();
}
