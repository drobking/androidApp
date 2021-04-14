package com.example.nursery.network.account.dto;

public class ValidationRegisterDTO {
    private int status;
    private String title;
    private RegisterErrorDTO errors;

    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public RegisterErrorDTO getErrors() {
        return errors;
    }

    public void setError(RegisterErrorDTO errors) {
        this.errors = errors;
    }
}
