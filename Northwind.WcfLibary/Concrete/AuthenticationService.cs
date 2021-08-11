using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.WcfLibary.Concrete
{
   public class AuthenticationService:IAuthenticationService
   {
       private AuthanticationManager _authanticationManager = new AuthanticationManager(new EfAuthenticationDal());
        public User Authenticate(User user)
        {
           return _authanticationManager.Authenticate(user);
        }
    }
}
