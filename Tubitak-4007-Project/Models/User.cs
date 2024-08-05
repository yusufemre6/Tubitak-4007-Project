using System;
using System.ComponentModel.DataAnnotations;

namespace Tubitak_4007_Project.Models
{
	public class User
	{
        [Required(ErrorMessage = "E-posta gerekli.")]
        public string userEmail { get; set; }
        [Required(ErrorMessage = "Şifre gerekli.")]
        public string userPassword { get; set; }
    }
}

