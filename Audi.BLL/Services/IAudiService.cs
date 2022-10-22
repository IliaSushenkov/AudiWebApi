using Audi.BLL.DTO;

namespace Audi.BLL.Services
{
    public interface IAudiService
    {
        Task<IEnumerable<AudiModelDTO>> GetAsync();
        Task<AudiModelDTO> GetAsync(int id);
        Task<int> CreateAsync(AudiModelDTO model);
        Task UpdateAsync(int id, AudiModelDTO model);
        Task DeleteAsync(int id);
    }
}
