﻿using Microsoft.AspNetCore.Identity;

namespace ApplicationForTest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int CourseID { get; set; }
    }
}