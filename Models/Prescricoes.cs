namespace APIVetClinic.Models
{
    public class Prescricoes
    {
        public int IdPrescricao { get; set; }
        public string Descricao { get; set; }

        //Foreign Key´s
        public int IdAnimal { get; set; }
        public int IdMedicamento { get; set; }

        public int IdVeterinario { get; set; }
    }
}
