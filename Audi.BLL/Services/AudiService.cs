using Audi.BLL.DTO;
using Audi.DAL.Models;
using Audi.DAL.Repositories;

namespace Audi.BLL.Services
{
    public class AudiService : IAudiService
    {
        private readonly IAudiRepository _repository;

        public AudiService(IAudiRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(AudiModelDTO model)
        {
            var contextModel = ContextModelDTO(model);
            return await _repository.CreateAsync(contextModel);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AudiModelDTO>> GetAsync()
        {
            var contextModel = await _repository.GetAsync();
            return contextModel.Select(x => ContextModelToDTO(x)).ToList();
        }

        public async Task<AudiModelDTO> GetAsync(int id)
        {
            var contextModel = await _repository.GetAsync(id);
            return ContextModelToDTO(contextModel);
        }

        public async Task UpdateAsync(int id, AudiModelDTO model)
        {
            var contextModel = ContextModelDTO(model);
            await _repository.UpdateAsync(id, contextModel);
        }

        private static AudiModelDTO ContextModelToDTO(AudiModel audiModelDTO) =>
           new AudiModelDTO
           {
               Id = audiModelDTO.Id,
               Brand = audiModelDTO.Brand,
               Model = audiModelDTO.Model,
               Price = audiModelDTO.Price,
               Description = audiModelDTO.Description
           };

        private static AudiModel ContextModelDTO(AudiModelDTO audiModelDTO) =>
           new AudiModel
           {
               Id = audiModelDTO.Id,
               Brand = audiModelDTO.Brand,
               Model = audiModelDTO.Model,
               Price = audiModelDTO.Price,
               Description = audiModelDTO.Description
           };
    }
}
