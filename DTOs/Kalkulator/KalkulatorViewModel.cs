
namespace proj01.DTOs.Kalkulator
{
    public class KalkulatorViewModel
    {
        public HitungRequestDto FormModel { get; set; } = new HitungRequestDto();
        public List<KalkulatorDto> DaftarRiwayat { get; set; } = new List<KalkulatorDto>();
        public bool IsEdit { get; set; } = false;
    }
}