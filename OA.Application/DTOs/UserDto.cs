﻿namespace OA.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; } = default!;
    public string Phone { get; set; }
}