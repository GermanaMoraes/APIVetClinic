using System.ComponentModel.DataAnnotations;

namespace APIVetClinic.Models
{
    public class Exames
    {
        public int IdExame { get; set; }
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }

        //Foreign Key´s 

        public int IdAnimal { get; set; }
        public int IdVeterinario { get; set; }
    }
}
