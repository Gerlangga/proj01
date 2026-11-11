using System.ComponentModel.DataAnnotations;

namespace proj01.DTOs.Kalkulator
{
    public class HitungRequestDto
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "Angka Pertama Wajib Diisi")]
        public int Angkasatu{get;set;}

        [Required(ErrorMessage = "Operasi wajib dipilih")]
        public string Operasi{get;set;} = string.Empty;

        [Required(ErrorMessage = "Angka ke dua wajib diisi")]
        public int Angkadua{get;set;}
    }
}