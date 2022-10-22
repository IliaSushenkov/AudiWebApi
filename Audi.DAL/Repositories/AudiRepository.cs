using Audi.DAL.Context;
using Audi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Audi.DAL.Repositories
{
    public class AudiRepository : IAudiRepository
    {
        private readonly AudiContext _audiContext;

        public AudiRepository(AudiContext audiContext)
        {
            _audiContext = audiContext;
        }

        public async Task<int> CreateAsync(AudiModel model)
        {
            await _audiContext.Audi.AddAsync(model);
            await _audiContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var audiModel = await _audiContext.Audi.FindAsync(id);
            if (audiModel == null)
            {
                throw new KeyNotFoundException();
            }

            _audiContext.Audi.Remove(audiModel);

            await _audiContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AudiModel>> GetAsync()
        {
            return await _audiContext.Audi.ToListAsync();
        }

        public AudiContext GetAudiContext()
        {
            return _audiContext;
        }

        public async Task<AudiModel> GetAsync(int id)
        {
            return await _audiContext.Audi.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, AudiModel model)
        {
            var audiModel = await _audiContext.Audi.FindAsync(id);
            if (audiModel == null)
            {
                throw new KeyNotFoundException();
            }

            audiModel.Brand = model.Brand;
            audiModel.Model = model.Model;
            audiModel.Price = model.Price;
            audiModel.Description = model.Description;

            await _audiContext.SaveChangesAsync();
        }
    }
}

