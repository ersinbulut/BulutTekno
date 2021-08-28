using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IVideoService
    {
        List<Video> GetList();

        void VideoAdd(Video video);
        //id ye göre işlem yapıcak
        Video GetByID(int id);
        void VideoDelete(Video video);
        void VideoUpdate(Video video);
    }
}
