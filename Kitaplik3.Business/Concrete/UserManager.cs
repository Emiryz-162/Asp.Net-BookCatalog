using Kitaplik3.Business.Abstract;
using Kitaplik3.DAL.Abstract;
using Kitaplik3.DAL.Concrete.EntityFramework;
using Kitaplik3.Entities.Concrete;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Concrete
{
    public class UserManager
    {
        EfUserDal _userDal = new();

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetById(int userId)
        {
            return _userDal.GetById(userId);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
