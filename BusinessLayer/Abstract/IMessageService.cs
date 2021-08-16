using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);//gelen mesajlar
        List<Message> GetListSendbox(string p);//gönderilen mesajlar

        void MessageAdd(Message message);
        //id ye göre işlem yapıcak
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
