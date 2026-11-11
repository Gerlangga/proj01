using Microsoft.EntityFrameworkCore;
using proj01.Data;
using proj01.Models;
using proj01.Repositories.Interfaces;

namespace proj01.Repositories.Implementations
{
    public class KalkulatorRepository : IKalkulatorRepository
    {
        private readonly AppDbContext _context;

        public KalkulatorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<KalkulatorModel>> GetAllAsync()
        {
            return await _context.KalkulatorModel.ToListAsync();
        }
        public async Task<KalkulatorModel?> GetByIdAsync(int id)
        {
            return await _context.KalkulatorModel.FindAsync(id);
        }
        public async Task<KalkulatorModel> AddAsync(KalkulatorModel entity)
        {
            _context.KalkulatorModel.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(KalkulatorModel entity)
        {
            _context.KalkulatorModel.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _context.KalkulatorModel.FindAsync(id);
            if (data == null)
            return false;

            _context.KalkulatorModel.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}