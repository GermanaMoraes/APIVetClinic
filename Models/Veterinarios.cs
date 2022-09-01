using System.ComponentModel.DataAnnotations;

namespace APIVetClinic.Models
{
    public class Veterinarios
    {
        public int IdVeterinario { get; set; }
        [Required]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

    }
}
