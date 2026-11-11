using System.ComponentModel.DataAnnotations;


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
   
}