using Microsoft.AspNetCore.Mvc;
using proj01.Data;
using proj01.Models;
using proj01.DTOs.Kalkulator;
using System.Linq;
using proj01.Services.Interfaces;

namespace proj01.Controllers
{
    public class KalkulatorController : Controller
    {
        private readonly IKalkulatorService _kalkulatorService;
        public KalkulatorController(IKalkulatorService kalkulatorService)
        {
            _kalkulatorService = kalkulatorService;
        }
        [HttpGet]
        public async Task<IActionResult> Hitung(int? id)
        {
            var viewModel = new KalkulatorViewModel
            {
                // 1. Ambil semua riwayat dari Service (sudah berupa DTO)
                DaftarRiwayat = await _kalkulatorService.GetAllAsync()
            };
            // 2. Jika ada id, ambil data untuk mode edit
            if (id.HasValue && id.Value > 0)
            {
                var dataEdit = await _kalkulatorService.GetForEditAsync(id.Value);
                if (dataEdit != null)
                {
                    viewModel.IsEdit = true;
                    viewModel.FormModel=dataEdit;
                }
            }
            else 
            {
                viewModel.FormModel = new HitungRequestDto();
                viewModel.IsEdit = false;
            }
            return View(viewModel);
        }

        [HttpPost]
        //method untuk olah data
        public async Task<IActionResult> Hitung(KalkulatorViewModel viewModel)
        {
            // Validasi dasar dari atribut [Required] di HitungRequestDto
            if (viewModel.FormModel != null)
            {
                // Panggil Service untuk hitung + simpan
                await _kalkulatorService.HitungAsync(viewModel.FormModel);
            }
            // Reset form & redirect agar tidak double-submit saat refresh
            ModelState.Clear();
            return RedirectToAction("Hitung", new { id = (int?)null });
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        //method untuk hapus
        public async Task<IActionResult> Hapus(int Id)
        {
            var berhasil = await _kalkulatorService.HapusAsync(Id);
            if (!berhasil)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}