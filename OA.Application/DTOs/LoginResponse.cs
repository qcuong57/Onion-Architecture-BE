﻿namespace OA.Application.DTOs;

public class LoginResponse
{
    
    public string Token { get; set; } = default!;
    public bool Success { get; set; }
    public string Message { get; set; } = default!;

}