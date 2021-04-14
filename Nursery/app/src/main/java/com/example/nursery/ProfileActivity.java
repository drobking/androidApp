package com.example.nursery;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import com.example.nursery.application.HomeApplication;
import com.example.nursery.network.profile.ApiWebService;
import com.example.nursery.network.profile.dto.ProfileResultDTO;
import com.example.nursery.security.JwtSecurityService;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ProfileActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);
        TextView tv = findViewById(R.id.textView2);
        ApiWebService.getInstance()
                .getJSONApi()
                .profile()
                .enqueue(new Callback<ProfileResultDTO>() {
                    @Override
                    public void onResponse(Call<ProfileResultDTO> call, Response<ProfileResultDTO> response) {
                        if(response.isSuccessful())
                        {
                            ProfileResultDTO result = response.body();
                            String image = result.getImage();
                            tv.setText(image);
                        }

                    }

                    @Override
                    public void onFailure(Call<ProfileResultDTO> call, Throwable t) {
                        Log.e("problem","problem API"+ t.getMessage());
                    }
                });
    }
}