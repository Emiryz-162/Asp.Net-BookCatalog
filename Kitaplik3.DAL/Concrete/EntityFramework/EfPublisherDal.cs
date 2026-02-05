using Kitaplik3.DAL.Abstract;
using Kitaplik3.DAL.Repositories;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.DAL.Concrete.EntityFramework
{
    public class EfPublisherDal : GenericRepository<Publisher>, IPublisherDal
    {
        
    }
}
