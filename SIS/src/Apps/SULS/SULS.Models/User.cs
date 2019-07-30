﻿using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
