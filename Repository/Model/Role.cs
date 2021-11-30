using Microsoft.AspNetCore.Identity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Role : IdentityRole<int>, IBaseModel
    {
        public bool IsDeleted { get; set; }
        public DateTime? DataCreated { get; set; }
        public DateTime? DataModified { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
