using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class LoginCheck
    {
        Context c = new Context();
        public LoginCheck()
        {
            c = new Context();  
        }

        public bool IsLoginSuccess(AdminUser userModel)
        {
            var crypto= new SimpleCrypto.PBKDF2();
            var user = c.Admins.Where(x => x.AdminUserName == userModel.AdminUserName).FirstOrDefault();

            if (user!=null && user.AdminStatus == true)
            {
                if (user.AdminUserPassword == crypto.Compute(userModel.AdminUserPassword,user.Salt))
                {
                    return true;
                }
            }
            return false;
        }
    }
}