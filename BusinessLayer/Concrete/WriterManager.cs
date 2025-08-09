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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void TAdd(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void TDelete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public List<Writer> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer entity)
        {
            throw new NotImplementedException();
        }
    }
}
