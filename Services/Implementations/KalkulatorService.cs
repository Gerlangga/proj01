using proj01.DTOs.Kalkulator;
using proj01.Models;
using proj01.Repositories.Interfaces;
using proj01.Services.Interfaces;

namespace proj01.Services.Implementations
{
    public class KalkulatorService : IKalkulatorService
    {
        private readonly IKalkulatorRepository _repository;

        public KalkulatorService(IKalkulatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<KalkulatorDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();

            // Mapping Entity → DTO
            return data.Select(x => new KalkulatorDto
            {
                Id = x.Id,
                Angkasatu = x.Angkasatu,
                Operasi = x.Operasi ?? string.Empty,
                Angkadua = x.Angkadua,
                Hasil = x.Hasil
            }).ToList();
        }

        public async Task<HitungRequestDto?> GetForEditAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return null;

            // Mapping Entity → DTO (untuk form)
            return new HitungRequestDto
            {
                Id = data.Id,
                Angkasatu = data.Angkasatu,
                Operasi = data.Operasi ?? string.Empty,
                Angkadua = data.Angkadua
            };
        }

        public async Task<KalkulatorDto> HitungAsync(HitungRequestDto request)
        {
            // 1. LOGIC BISNIS: hitung
            int hasil = Hitung(request.Angkasatu, request.Operasi, request.Angkadua);

            // 2. Mapping DTO → Entity (untuk disimpan)
            var entity = new KalkulatorModel
            {
                Id = request.Id,
                Angkasatu = request.Angkasatu,
                Operasi = request.Operasi,
                Angkadua = request.Angkadua,
                Hasil = hasil
            };

            // 3. Simpan via Repository (Id=0 → add, Id>0 → update)
            if (entity.Id == 0)
            {
                entity = await _repository.AddAsync(entity);
            }
            else
            {
                await _repository.UpdateAsync(entity);
            }

            // 4. Mapping Entity → DTO (untuk dikembalikan ke Controller)
            return new KalkulatorDto
            {
                Id = entity.Id,
                Angkasatu = entity.Angkasatu,
                Operasi = entity.Operasi ?? string.Empty,
                Angkadua = entity.Angkadua,
                Hasil = entity.Hasil
            };
        }

        public async Task<bool> HapusAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        // Logic hitung murni — dipisah agar mudah ditest
        private static int Hitung(int a, string? operasi, int b)
        {
            return operasi switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => b != 0 ? a / b : 0,
                _ => 0
            };
        }
    }
}