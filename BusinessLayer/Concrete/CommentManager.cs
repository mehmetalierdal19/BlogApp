using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void TAdd(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void TDelete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetAll()
        {
            return _commentDal.GetAll();
        }
        public List<Comment> TListByBlogID(int id)
        {
            return _commentDal.GetAll(x => x.BlogID == id);
        }

        public Comment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
