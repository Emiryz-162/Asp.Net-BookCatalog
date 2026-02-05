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
    public class AuthorManager : IAuthorService
    {
        EfAuthorDal _efAuthorDal = new();
        public void Add(Author author)
        {
            _efAuthorDal.Add(author);
        }

        public void Delete(Author author)
        {
            _efAuthorDal.Delete(author);
        }

        public List<Author> GetAll()
        {
            return _efAuthorDal.GetAll();
        }

        public Author GetById(int authorId)
        {
            return _efAuthorDal.GetById(authorId);
        }

        public void Update(Author author)
        {
            _efAuthorDal.Update(author);
        }
    }
}
