using System.ComponentModel.DataAnnotations;

namespace WebAppRen.Models
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public int IdGender { get; set; }
        public string IdHobi { get; set; }
        public int Umur { get; set; }
    }
}
