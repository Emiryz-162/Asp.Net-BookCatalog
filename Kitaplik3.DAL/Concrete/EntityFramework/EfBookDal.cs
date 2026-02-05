using Kitaplik3.DAL.Abstract;
using Kitaplik3.DAL.Repositories;
using Kitaplik3.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.DAL.Concrete.EntityFramework 
{
    public class EfBookDal : GenericRepository<Book>, IBookDal
    {
        AppDbContext _context = new();

        public List<Book> GetWithAll()
        {
            return _context.Books.Where(b => b.IsDelete == false).Include(c => c.Category).Include(a => a.Author).Include(p=>p.Publisher).ToList();
        }
      
    }
}
