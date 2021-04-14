package com.example.nursery.security;

public interface JwtSecurityService {
    void saveJwtToken(String token);
    String getToken();
    void deleteToken();
}