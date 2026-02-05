using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author GetById(int authorId);
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
