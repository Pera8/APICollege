using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel: class , IBaseModel
    {
        private readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<TModel> AddAsync(TModel model)
        {
            await appDbContext.AddAsync(model);
            await appDbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await appDbContext.Set<TModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
            appDbContext.Remove(result);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<DbSet<TModel>> GetAllAsync()
        {
            return  appDbContext.Set<TModel>();
        }

        public async Task<TModel> GetAsyncById(int id)
        {
            return await appDbContext.Set<TModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
