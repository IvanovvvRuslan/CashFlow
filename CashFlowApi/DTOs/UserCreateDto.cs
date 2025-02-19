﻿using CashFlowApi.Models;

namespace CashFlowApi.DTOs
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
    }
}
