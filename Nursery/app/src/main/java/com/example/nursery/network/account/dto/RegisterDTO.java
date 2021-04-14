package com.example.nursery.network.account.dto;

public class RegisterDTO {
    private String email;
    private String password;
    private String displayName;

    public RegisterDTO() {
    }

    public RegisterDTO(String email, String password, String dislplayName) {
        this.email = email;
        this.password = password;
        this.displayName = dislplayName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getDisplayName() {
        return displayName;
    }

    public void setDisplayName(String displayName) {
        this.displayName = displayName;
    }
}
