using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<AdminUser> GetList();

        void AdminAdd(AdminUser admin);
        //id ye göre işlem yapıcak
        AdminUser GetByID(int id);
        void AdminDelete(AdminUser admin);
        void AdminUpdate(AdminUser admin);
    }
}
