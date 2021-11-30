using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class College : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set; }
    }
}
