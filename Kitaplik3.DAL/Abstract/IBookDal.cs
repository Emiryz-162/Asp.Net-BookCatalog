using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.DAL.Abstract
{
    public interface IBookDal
    {
        List<Book> GetAll();
        Book GetById(int bookId);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
