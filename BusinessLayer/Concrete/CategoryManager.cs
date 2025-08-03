using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EFCategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new EFCategoryRepository();
        }
        public void TAdd(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
