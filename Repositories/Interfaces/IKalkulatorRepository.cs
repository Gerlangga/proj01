using proj01.Models;

namespace proj01.Repositories.Interfaces
{
    public interface IKalkulatorRepository
    {
        Task<List<KalkulatorModel>> GetAllAsync();
        Task<KalkulatorModel?> GetByIdAsync(int id);
        Task<KalkulatorModel> AddAsync(KalkulatorModel entity);
        Task UpdateAsync(KalkulatorModel entity);
        Task<bool> DeleteAsync(int id);
    }
}
