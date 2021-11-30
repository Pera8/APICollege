using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IProfessorRepository
    {
        Task<Subject> AddSubjectFromProfessorInDB(Subject subject);
        Task<Professor> AddProfessorFromSubjectInDB(Professor professor);
    }
}
