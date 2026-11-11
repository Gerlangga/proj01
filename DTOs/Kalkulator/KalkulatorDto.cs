
namespace proj01.DTOs.Kalkulator
{
    public class KalkulatorDto
    {
        public int Id { get; set; }
        public int Angkasatu { get; set; }
        public string Operasi { get; set; } = string.Empty;
        public int Angkadua { get; set; } 
        public int Hasil { get; set; }

    }
}