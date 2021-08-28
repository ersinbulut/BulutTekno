using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.ViewModels
{
    public class ProfilePasswordViewModel
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public ChangePasswordViewModel changePasswordView { get; set; }
    }
}