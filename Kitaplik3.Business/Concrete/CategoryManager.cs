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
    public class CategoryManager : ICategoryService
    {
        EfCategoryDal _categoryDal = new();
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.GetById(categoryId);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
