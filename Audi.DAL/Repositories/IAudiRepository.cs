using Audi.DAL.Models;

namespace Audi.DAL.Repositories
{
    public interface IAudiRepository
    {
        Task<IEnumerable<AudiModel>> GetAsync();
        Task<AudiModel> GetAsync(int id);
        Task<int> CreateAsync(AudiModel model);
        Task UpdateAsync(int id, AudiModel model);
        Task DeleteAsync(int id);
    }
}
