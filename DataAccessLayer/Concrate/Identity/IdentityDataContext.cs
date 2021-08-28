using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("IdentityConnection")
        {
            //Database.SetInitializer(new IdentityInitializer());
        }

        public System.Data.Entity.DbSet<MvcProjeKampi.Identity.ApplicationRole> IdentityRoles { get; set; }


        //public System.Data.Entity.DbSet<Eticaret.Identity.ApplicationUser> IdentityUsers { get; set; }
    }
}