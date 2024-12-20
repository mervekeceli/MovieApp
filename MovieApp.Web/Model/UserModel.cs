﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Model
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Kullanıcı adı 30 karakterden fazla olamaz!")]
        [Remote(action: "VerifyUserName", controller:"User")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage ="{0} karakter uzunluğu {2}-{1} arasında olmalıdır!", MinimumLength =3)]
        public string Name { get; set; }

        [EmailProviders]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }

        [Url]
        public string Url { get; set; }

        [BirthDate(ErrorMessage ="Doğum tarihiniz şimdiki tarih yada sonraki tarih olamaz!")]
        [DataType(DataType.Date)]
        [Display(Name ="Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
