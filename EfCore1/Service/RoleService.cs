using EfCore1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore1.Service
{
    public class RoleService
    {
        public void Add(User user)
        {
            var _user = new User
            {
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
            };
        }
    }
}
