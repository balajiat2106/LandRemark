﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.Application.Users.Commands.CreateUser
{
    public class CreateUserModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6),MaxLength(12)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
