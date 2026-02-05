using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(int bookId);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
