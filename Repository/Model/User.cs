using Microsoft.AspNetCore.Identity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class User : IdentityUser<int>, IBaseModel
    {    
 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
