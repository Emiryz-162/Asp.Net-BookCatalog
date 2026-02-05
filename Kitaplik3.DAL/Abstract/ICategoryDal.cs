using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.DAL.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
