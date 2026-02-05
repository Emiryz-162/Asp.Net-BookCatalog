using Kitaplik3.Business.Abstract;
using Kitaplik3.DAL.Concrete.EntityFramework;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Concrete
{
    public class BookManager : IBookService
    {
        EfBookDal _efBookDal = new();
        public void Add(Book book)
        {
            _efBookDal.Add(book);
        }

        public void Delete(Book book)
        {
            _efBookDal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _efBookDal.GetAll();
        }

        public Book GetById(int bookId)
        {
            return _efBookDal.GetById(bookId);
        }

        public void Update(Book book)
        {
            _efBookDal.Update(book);
        }

        public List<Book> GetWithAll()
        {
            return _efBookDal.GetWithAll();
        }
    }
}
