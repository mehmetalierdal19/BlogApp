using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GeenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetBlogsWithCategory()
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(b => b.Category).ToList();
            }
        }

        public List<Blog> GetBlogsWithCategoryByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(b => b.Category).Where(x => x.WriterID == id).ToList();
            }
        }
    }
}
