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
    public class NewsLetterManager : INewsLettersService
    {
        INewsLetterDal _newsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void TAdd(NewsLetter entity)
        {
            _newsLetterDal.Add(entity);
        }

        public void TDelete(NewsLetter entity)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> TGetAll()
        {
            throw new NotImplementedException();
        }

        public NewsLetter TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(NewsLetter entity)
        {
            throw new NotImplementedException();
        }
    }
}
