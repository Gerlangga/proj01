using proj01.DTOs.Kalkulator;

namespace proj01.Services.Interfaces
{
    public interface IKalkulatorService
    {
        Task<List<KalkulatorDto>> GetAllAsync();
        Task<HitungRequestDto?> GetForEditAsync(int id);
        Task<KalkulatorDto> HitungAsync(HitungRequestDto request);
        Task<bool> HapusAsync(int id);
    }
}