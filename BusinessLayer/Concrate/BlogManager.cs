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
    public class BlogManager : IBlogService
    {
        IBlogDal _BlogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _BlogDal = blogDal;
        }

        public void BlogAdd(Blog blog)
        {
            _BlogDal.Insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _BlogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _BlogDal.Update(blog);
        }

        public Blog GetByID(int id)
        {
            return _BlogDal.Get(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _BlogDal.List();
        }
        public List<Blog> GetListByBlogID(int id)
        {
            return _BlogDal.List(x => x.BlogID == id);
        }
       
    }
}
