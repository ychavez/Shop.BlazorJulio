﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Common.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
    }
}
