using Microsoft.AspNetCore.Mvc;
using proj01.Data;
using proj01.Models;
using System.Linq;

namespace proj01.Data
{
    public class KalkulatorController : Controller
    {
        private readonly AppDbContext _context;
        public KalkulatorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Hitung(int? id)
        {
            var viewModel = new KalkulatorViewModel
            {
                //ambil data dari database untuk di tampilkan di table
                DaftarRiwayat = _context.KalkulatorModel.ToList()
            };
            //jika ada parameter id dari url + user klik edit = ambil data lamanya
            if (id.HasValue && id.Value > 0)
            {
                var dataEdit = _context.KalkulatorModel.Find(id.Value);
                if (dataEdit != null)
                {
                    viewModel.IsEdit = true;
                    viewModel.FormModel=dataEdit;
                }
            }
            else 
            {
                viewModel.FormModel = new KalkulatorModel();
                viewModel.IsEdit = false;
            }
            return View(viewModel);
        }

        [HttpPost]
        //method untuk olah data
        public IActionResult Hitung(KalkulatorViewModel viewModel)
        {
            var data = viewModel.FormModel;
            if (data != null)
            {
                switch (data.Operasi)
                {
                    case "+":
                    data.Hasil = data.Angkasatu + data.Angkadua;
                    break;
                    case "-":
                    data.Hasil = data.Angkasatu - data.Angkadua;
                    break;
                    case "*":
                    data.Hasil = data.Angkasatu * data.Angkadua;
                    break;
                    case "/":
                    data.Hasil = data.Angkadua != 0 ? data.Angkasatu / data.Angkadua : 0;
                    break;
                    default:
                    data.Hasil = 0;
                    break;
                }
    #pragma warning restore CS8602 // Dereference of a possibly null reference.
                if (data.Id == 0)
                {
                    //jika id=0 input data baru
                    _context.KalkulatorModel.Add(data);
                }
                else
                {
                    //jika id > 0 kenanya update
                    _context.KalkulatorModel.Update(data);
                }
                _context.SaveChanges();
            }
            viewModel.IsEdit = false;
            ModelState.Clear();
            return RedirectToAction("Hitung", new { id = (int?)null });
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        //method untuk hapus
        public IActionResult Hapus(int Id)
        {
            Console.WriteLine($"Hapus Di panggil dengan id : {Id}");
            var data = _context.KalkulatorModel.Find(Id);
            if (data == null)
            {
                Console.WriteLine($"Data dengan id {Id} TIDAK DI TEMUKAN");
                return NotFound();
            }
            _context.KalkulatorModel.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}