using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Model
{
    public interface ILoginRepository
    {
        Login ValidateLogin(string UserName,string Password);
       
    }
}
