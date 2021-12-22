using Models.View.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUserService 
    {
        string Login(LoginRequest request);
    }
}
