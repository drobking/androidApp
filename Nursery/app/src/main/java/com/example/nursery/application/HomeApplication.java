package com.example.nursery.application;

import android.app.Application;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;

import androidx.appcompat.app.AppCompatDelegate;

import com.example.nursery.security.JwtSecurityService;

public class HomeApplication extends Application
        implements JwtSecurityService {
    private static HomeApplication instance;
    private static Context appContext;

    public static HomeApplication getInstance() {
        return instance;
    }

    public static Context getAppContext() {
        return appContext;
    }

    public void setAppContext(Context mAppContext) {
        this.appContext = mAppContext;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        instance = this;
        Log.d("Init app", "Get instance init application");
        this.setAppContext(getApplicationContext());
        AppCompatDelegate.setCompatVectorFromResourcesEnabled(true);
    }

    @Override
    public void saveJwtToken(String token) {
        SharedPreferences prefs;
        SharedPreferences.Editor edit;
        prefs =  instance.getSharedPreferences("jwtStore", MODE_PRIVATE);
        edit=prefs.edit();
        try {
            edit.putString("token",token);
            edit.commit();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    @Override
    public String getToken() {
        SharedPreferences prefs=instance.getSharedPreferences("jwtStore", Context.MODE_PRIVATE);
        String token = prefs.getString("token","");
        return token;
    }

    @Override
    public void deleteToken() {
        SharedPreferences prefs;
        SharedPreferences.Editor edit;
        prefs=instance.getSharedPreferences("jwtStore", Context.MODE_PRIVATE);
        edit=prefs.edit();
        try {
            edit.remove("token");
            edit.apply();
            edit.commit();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
