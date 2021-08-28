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
    public class VideoManager : IVideoService
    {
        IVideoDal _videoDal;

        public VideoManager(IVideoDal videoDal)
        {
            _videoDal = videoDal;
        }

        public Video GetByID(int id)
        {
            return _videoDal.Get(x => x.VideoID == id);
        }

        public List<Video> GetList(string p)
        {
            return _videoDal.List(x => x.VideoTitle.Contains(p));
        }

        public List<Video> GetListByWriterID(int id)
        {
            return _videoDal.List(x => x.WriterID == id);
        }

        public List<Video> GetVideoList(int id)
        {
            return _videoDal.List(x => x.VideoID == id);
        }

        public List<Video> GetList()
        {
            return _videoDal.List();
        }

        public void VideoAdd(Video video)
        {
            _videoDal.Insert(video);
        }

        public void VideoDelete(Video video)
        {
            _videoDal.Delete(video);
        }

        public void VideoUpdate(Video video)
        {
            _videoDal.Update(video);
        }
    }
}
