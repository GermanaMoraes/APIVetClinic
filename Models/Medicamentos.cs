using System.ComponentModel.DataAnnotations;

namespace APIVetClinic.Models
{
    public class Medicamentos
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        
    }
}
