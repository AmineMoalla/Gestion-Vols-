﻿using System.ComponentModel.DataAnnotations;

namespace GestionVols.DTO
{
    
        public class LoginDTO
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }


