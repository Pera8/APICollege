using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Model;
using Repository.Repository.IRepository;
using Service.Mapper;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProfessorService : IRepository<Professor> 
    {
         static ProfessorService() => MapperConfig.RegisterProfessorMapping();

        private readonly IRepository<Professor> repositoryProfessor;
        private readonly IRepository<Subject> repositorySubject;
        private readonly IProfessorRepository professorRepository;

        public ProfessorService(IRepository<Professor> repositoryProfessor, IRepository<Subject> repositorySubject, IProfessorRepository professorRepository)
        {
            this.repositoryProfessor = repositoryProfessor;
            this.repositorySubject = repositorySubject;
            this.professorRepository = professorRepository;
        }
        public async Task<Professor> AddAsync(ProfessorDTO model)
        {
            if (model == null)
            {
                throw new Exception("Professor can not be null");
            }
            var _Professor= TypeAdapter.Adapt<ProfessorDTO, Professor>(model);
            return await repositoryProfessor.AddAsync(_Professor);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryProfessor.DeleteAsync(id);
        }

        public async Task<DbSet<Professor>> GetAllAsync()
        {
            return await repositoryProfessor.GetAllAsync();
        }

        public async Task<Professor> GetAsyncById(int id)
        {
            return await repositoryProfessor.GetAsyncById(id);
        }

        public async Task<ProfessorDTO> GetAsyncProfessorDTOById(int id)
        {
            var result= await repositoryProfessor.GetAsyncById(id);
            var resultDTO= TypeAdapter.Adapt<Professor, ProfessorDTO>(result);
            return resultDTO;
        }

        public Task<Professor> AddAsync(Professor model)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> AddProfessorFromSubject(int professorId, int subjectId)
        {
            var professors = await repositoryProfessor.GetAllAsync();
            var subject = await repositorySubject.GetAsyncById(subjectId);

            var _professor = await professors
                .Include(x => x.Subjects)
                .FirstOrDefaultAsync(r => r.Id == professorId);

            _professor.Subjects.Add(subject);
            await professorRepository.AddProfessorFromSubjectInDB(_professor);
            return _professor;
        }

        public async Task<Subject> AddSubjectFromProfessor(int professorId, int subjectId)
        {
            var subjects = await repositorySubject.GetAllAsync();
            var professors = await repositoryProfessor.GetAllAsync();
            var professor = professors.Include(x => x.Subjects).FirstOrDefault(x => x.Id == professorId);
            var _subject = await subjects
                .Include(x => x.Professors)
                .Include(x => x.College)
                .Include(x => x.Students)
                .FirstOrDefaultAsync(c => c.Id == subjectId);
           _subject.Professors.Add(professor);
            
            
            await professorRepository.AddSubjectFromProfessorInDB(_subject);
            return _subject;           

        }

      
    }
}
