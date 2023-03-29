using Microsoft.AspNetCore.Identity;
using System;

namespace CoworkingApp.Data.Models
{
    public class User : IdentityUser
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
    }
}