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

        public List<Blog> GetLast3Blogs()
        {
            return _blogDal.GetAll().OrderByDescending(x => x.CreateDate).Take(3).ToList();
        }

        public List<Blog> TListByID(int id)
        {
            return _blogDal.GetAll(x => x.BlogID == id);
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

        public List<Blog> TGetBlogListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterID == id);
        }

        public List<Blog> TGetBlogsWithCategoryByWriter(int id)
        {
            return _blogDal.GetBlogsWithCategoryByWriter(id);
        }
    }
}
