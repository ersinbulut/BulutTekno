using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T p);
        //dışarıdan bir şart alıcak ama ne şartı olduğunu belirlemedik
        T Get(Expression<Func<T, bool>> filter);//id si 5 olan yazarı döndürmek için bu method
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);//yazarlar içerisinde ismi ali olan yazarları döndürmek için bu method
    }
}
