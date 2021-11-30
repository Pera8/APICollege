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
    public class SubjectService : IRepository<Subject>
    {
        static SubjectService() => MapperConfig.RegisterSubjectMapping();

        private readonly IRepository<Subject> repositorySubject;
        private readonly IRepository<College> repositoryCollege;

        public SubjectService(IRepository<Subject> repositorySubject, IRepository<College> repositoryCollege)
        {
            this.repositorySubject = repositorySubject;
            this.repositoryCollege = repositoryCollege;
        }
        public async Task<Subject> AddAsync(SubjectDTO model)
        {
            if (model == null)
            {
                throw new Exception("Subject can not be null");
            }
            var _college = await repositoryCollege.GetAsyncById(model.CollegeId);

            if (_college == null)
            {
                throw new Exception("College can not be null");
            }

            var subject= TypeAdapter.Adapt<SubjectDTO, Subject>(model);
            subject.College = _college;
            return await repositorySubject.AddAsync(subject);
        }

        public async Task<DbSet<Subject>> GetAllAsync()
        {
            return await repositorySubject.GetAllAsync();
        }

        public async Task<Subject> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositorySubject.GetAsyncById(id);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositorySubject.DeleteAsync(id);
        }

        public Task<Subject> AddAsync(Subject model)
        {
            throw new NotImplementedException();
        }
    }
}
