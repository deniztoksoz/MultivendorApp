using MultivendorAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorAPP.Services
{
   public interface IAuth
    {
        Task<Token> Login(string email, string password);
        Task<bool> Register(Users user);
    }
}
