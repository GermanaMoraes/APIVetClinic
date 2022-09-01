using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IConsultas
    {
        //Read
        ICollection<Consultas> GetAll();
        Consultas GetbyId(int id);
        //Create
        Consultas Inserir (Consultas consultas);
        

        //UpdateConsultas
        Consultas Update(int id, Consultas consulta);

        //Delete
        bool Delete(int id);
    }

}
