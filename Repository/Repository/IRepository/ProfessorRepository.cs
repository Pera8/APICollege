using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext appDbContext;

        public ProfessorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Professor> AddProfessorFromSubjectInDB(Professor professor)
        {
            try
            {
                
                await appDbContext.SaveChangesAsync();
                return professor;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
            
        }

        public async Task<Subject> AddSubjectFromProfessorInDB(Subject subject)
        {           
            await appDbContext.SaveChangesAsync();
            return subject;           
          
        }
    }
}
