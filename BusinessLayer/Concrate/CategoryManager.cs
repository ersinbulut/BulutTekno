using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    /*CategoryManager üzerine gelip ctr + . yapılıp generate constractor seçilir*/
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {//IRepositorden gelen içerisi GenericRepository ile dolu olan delete methodu
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {//id den gelen değerin eşitliği kontrol edilir
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }




    }
}
