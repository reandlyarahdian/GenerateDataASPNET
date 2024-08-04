using System.ComponentModel.DataAnnotations;

namespace WebAppRen.Models
{
    public class Hobi
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
