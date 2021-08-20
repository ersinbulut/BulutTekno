using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class AdminManager: IAdminService
    {
        IAdminDal _AdminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _AdminDal = adminDal;
        }



        public void AdminAdd(AdminUser admin)
        {
            _AdminDal.Insert(admin);
        }

        public void AdminDelete(AdminUser admin)
        {
            _AdminDal.Delete(admin);
        }

        public void AdminUpdate(AdminUser admin)
        {
            _AdminDal.Update(admin);
        }

        public AdminUser GetByID(int id)
        {
            return _AdminDal.Get(x => x.AdminID == id);
        }

        public List<AdminUser> GetList()
        {
            return _AdminDal.List();
        }
    }
}
