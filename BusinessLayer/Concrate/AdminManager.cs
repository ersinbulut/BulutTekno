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



        public void AdminAdd(Admin admin)
        {
            _AdminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _AdminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _AdminDal.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _AdminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _AdminDal.List();
        }
    }
}
