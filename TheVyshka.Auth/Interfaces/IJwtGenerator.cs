using TheVyshka.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheVyshka.Auth.Interfaces
{
    public interface IJwtGenerator
    {
        Task<object> GenerateJwt(User user);
    }

}
