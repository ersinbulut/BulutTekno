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
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public News GetByID(int id)
        {
            return _newsDal.Get(x => x.NewsID == id);
        }


        public List<News> GetNewsList(int id)
        {
            return _newsDal.List(x => x.NewsID == id);
        }

        public List<News> GetListByWriterID(int id)
        {
            return _newsDal.List(x => x.WriterID == id);
        }

        public List<News> GetList()
        {
            return _newsDal.List();
        }

        public void NewsAdd(News news)
        {
            _newsDal.Insert(news);
        }

        public void NewsDelete(News news)
        {
            _newsDal.Delete(news);
        }

        public void NewsUpdate(News news)
        {
            _newsDal.Update(news);
        }
    }
}
