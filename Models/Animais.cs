using System.ComponentModel.DataAnnotations;

namespace APIVetClinic.Models
{
    public class Animais
    {
        public int IdAnimal { get; set; }

        [Required]
        public string Nome { get; set; }
        
        public string Raca { get; set; }
        public decimal Peso { get; set; }
         public string Sexo { get; set; }
        public int Idade { get; set; }
        
        //Foreign Key´s
        public int IdProprietario { get; set; }

        public int IdEspecie { get; set; }
    }
}
