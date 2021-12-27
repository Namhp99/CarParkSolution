using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base()
        {
        }
        public AppRole(string roleName) : base(roleName)
        {
            
        }

        public string Description { get; set; }
    }
}
