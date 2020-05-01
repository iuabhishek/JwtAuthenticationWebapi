using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Model
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EmployeeDbContext _context;
        public LoginRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public Login ValidateLogin(string UseName,string Password)
        {
            return _context.logins.Where(x => x.UserName == UseName && x.Password ==Password).FirstOrDefault();
        }
    }
}
