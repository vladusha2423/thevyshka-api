using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheVyshka.Data
{
    public class User: IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
