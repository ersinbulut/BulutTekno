using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsService
    {
        List<News> GetList();

        void NewsAdd(News news);
        //id ye göre işlem yapıcak
        News GetByID(int id);
        void NewsDelete(News news);
        void NewsUpdate(News news);
    }
}
