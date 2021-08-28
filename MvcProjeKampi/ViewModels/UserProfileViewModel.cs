using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.ViewModels
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        /*Yeni Eklenen Alanlar*/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }//dogum tarihi
        public string Gender { get; set; }//cinsiyet
        public string ProfileImageName { get; set; }
    }
}