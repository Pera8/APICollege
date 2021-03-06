using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Student : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; }
        public College College { get; set; }
        public List<Professor> Professors { get; set; }
    }
}
