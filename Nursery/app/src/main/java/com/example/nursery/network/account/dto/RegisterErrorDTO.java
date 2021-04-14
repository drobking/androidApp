package com.example.nursery.network.account.dto;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class RegisterErrorDTO {
    @SerializedName("Email")
    @Expose
    private String[] email;
    @SerializedName("Password")
    @Expose
    private String[] password;
    @SerializedName("DisplayName")
    @Expose
    private String[] displayName;

    public String[] getEmail() {
        return email;
    }

    public void setEmail(String[] email) {
        email = email;
    }

    public String[] getPassword() {
        return password;
    }

    public void setPassword(String[] password) {
        this.password = password;
    }

    public String[] getDisplayName() {
        return displayName;
    }

    public void setDisplayName(String[] displayName) {
        this.displayName = displayName;
    }
}
