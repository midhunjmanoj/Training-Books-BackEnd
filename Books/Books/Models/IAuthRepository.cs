using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public interface IAuthRepository
    {
        Auth RegisterUser(Auth auth);
        Auth ValidateUser(string user,string passwd);
    }
}
