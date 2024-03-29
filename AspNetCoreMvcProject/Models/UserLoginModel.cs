﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "User Name Cannot Be Empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Name Cannot Be Empty")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
