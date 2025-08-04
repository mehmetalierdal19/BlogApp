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
    public class BlogManager : IBlogServıce
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void TAdd(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> TGetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> TGetBlogsWithCategory()
        {
            return _blogDal.GetBlogsWithCategory();
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
