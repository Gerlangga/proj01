using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj01.Models
{
    public class KalkulatorModel
    {
        [Key]
        public int Id {get; set;}
        public int Angkasatu {get; set;}
        public string? Operasi {get; set;}
        public int Angkadua {get; set;}
        public int Hasil {get;set;}
    }
    public class KalkulatorViewModel
    {
        public KalkulatorModel FormModel {get; set;} = new KalkulatorModel();
        public List<KalkulatorModel> DaftarRiwayat {get;set;} = [];
        public bool IsEdit { get; set; } = false;
    }
}