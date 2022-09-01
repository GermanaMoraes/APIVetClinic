using System;

namespace APIVetClinic.Models
{
    public class Consultas
    {
        public int IdConsulta { get; set; }

        public DateTime Horario { get; set; }

        //Foreign Key´s

        public int IdAnimal { get; set; }
        public int IdVeterinario { get; set; }

    }
}
