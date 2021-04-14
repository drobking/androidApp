package com.example.nursery;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

import com.android.volley.toolbox.NetworkImageView;
import com.example.nursery.application.HomeApplication;
import com.example.nursery.constants.Urls;
import com.example.nursery.network.ImageRequester;
import com.example.nursery.network.account.AccountService;
import com.example.nursery.network.account.dto.LoginDTO;
import com.example.nursery.network.account.dto.LoginResultDTO;
import com.example.nursery.security.JwtSecurityService;
import com.example.nursery.utils.CommonUtils;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    private ImageRequester imageRequester;
    private NetworkImageView myImage;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        String url = Urls.BASE_URL+"/images/1.jpg";
        //String url = "https://img.webmd.com/dtmcms/live/webmd/consumer_assets/site_images/article_thumbnails/other/cat_relaxing_on_patio_other/1800x1200_cat_relaxing_on_patio_other.jpg?resize=750px:*";
        imageRequester = ImageRequester.getInstance();
        myImage = findViewById(R.id.myImage);
        imageRequester.setImageFromUrl(myImage, url);
    }

    public void onClickLogin(View view) {
        final TextInputLayout emailLayout = findViewById(R.id.inputLayoutEmail);
        final TextInputEditText email = findViewById(R.id.textFieldEmail);
        final TextInputLayout emailPassword = findViewById(R.id.inputLayoutPassword);
        final TextInputEditText password = findViewById(R.id.textFieldPassword);
        //Log.d("clickLogin", email.getText().toString());
        //emailLayout.setError("У нас проблеми");
        CommonUtils.showLoading(this);
        LoginDTO model = new LoginDTO(
                email.getText().toString(),
                password.getText().toString()
        );
        AccountService.getInstance()
                .getJSONApi()
                .login(model)
                .enqueue(new Callback<LoginResultDTO>() {
                    @Override
                    public void onResponse(Call<LoginResultDTO> call, Response<LoginResultDTO> response) {
                        CommonUtils.hideLoading();
                        if(response.isSuccessful()) {
                            LoginResultDTO result = response.body();
                            JwtSecurityService jwtService = (JwtSecurityService) HomeApplication.getInstance();
                            jwtService.saveJwtToken(result.getToken());
                            Intent profileIntent = new Intent(MainActivity.this,
                                    ProfileActivity.class);
                            startActivity(profileIntent);
                            //result.getToken();
                            Log.d("Good Request", result.getToken());
                        }
                    }

                    @Override
                    public void onFailure(Call<LoginResultDTO> call, Throwable t) {

                    }
                });
    }
    public void onClickRegister(View view) {
        Intent profileIntent = new Intent(MainActivity.this, MainActivity.class);
        startActivity(profileIntent);
    }
}