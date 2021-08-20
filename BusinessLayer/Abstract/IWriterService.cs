using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<WriterUser> GetList();
        void WriterAdd(WriterUser writer);
        void WriterDelete(WriterUser writer);
        void WriterUpdate(WriterUser writer);
        WriterUser GetByID(int id);
    }
}
