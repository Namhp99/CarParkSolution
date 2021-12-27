using Models.Authentication;
using Models.View.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUserService 
    {
        Task<string> Login(LoginModel request);
        Task<int> RegisterHRM(RegisterModel request);
        Task<int> RegisterAdmin(RegisterModel request);
    }
}
