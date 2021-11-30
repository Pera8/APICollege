using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
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
    public class CollegeService : IRepository<College>
    {
        static CollegeService() 
        { 
            MapperConfig.RegisterCollegeMapping();
            MapperConfig.RegisterCollegeDTOMapping();
        }

        private readonly IRepository<College> repositoryCollege;

        public CollegeService (IRepository<College> repositoryCollege)
        {
            this.repositoryCollege = repositoryCollege;
        }

        public async Task<College> AddAsync(CollegeDTO model)
        {
            if (model == null)
            {
                throw new Exception("College can not be null");
            }
            var _college = TypeAdapter.Adapt<CollegeDTO, College>(model);

            return await repositoryCollege.AddAsync(_college);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryCollege.DeleteAsync(id);
        }

        public async Task<DbSet<College>> GetAllAsync()
        {
            return await repositoryCollege.GetAllAsync();
        }

        public async Task<IEnumerable<CollegeDTO>> GetAllCollege()
        {
            var result= await repositoryCollege.GetAllAsync();

            var collegeListDto = result.Select(TypeAdapter.Adapt<CollegeDTO>);
            return collegeListDto;
        }

        public async Task<CollegeDTO> GetAsyncCollegeById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            var result = await repositoryCollege.GetAsyncById(id);
            var resultDTO= TypeAdapter.Adapt<College, CollegeDTO>(result);

            return resultDTO;
        }

        public Task<College> AddAsync(College model)
        {
            throw new NotImplementedException();
        }        

        public async Task<College> GetAsyncById(int id)
        {
            return await repositoryCollege.GetAsyncById(id);
        }
    }
}
