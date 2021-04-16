﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Id Number")]
        public string IdCard { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

    }
}