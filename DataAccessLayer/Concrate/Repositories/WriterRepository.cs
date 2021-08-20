using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate.Repositories
{
    public class WriterRepository : IWriterDal
    {
        Context c = new Context();
        DbSet<WriterUser> _object;
        public void Delete(WriterUser p)
        {
            throw new NotImplementedException();
        }

        public WriterUser Get(Expression<Func<WriterUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(WriterUser p)
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> List()
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> List(Expression<Func<WriterUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(WriterUser p)
        {
            throw new NotImplementedException();
        }
    }
}
