using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        Publisher GetById(int UserId);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
