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
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void CommentDelete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public Comment GetByID(int id)
        {
            return _commentDal.Get(x => x.ContentID == id);
        }
        public List<Comment> GetListByContent(int id)
        {
            return _commentDal.List(x => x.ContentID == id);
        }


        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

    }
}
