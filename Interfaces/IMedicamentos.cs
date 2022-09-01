using APIVetClinic.Models;
using System.Collections.Generic;

namespace APIVetClinic.Interfaces
{
    public interface IMedicamentos
    {
        //Read
        ICollection<Medicamentos> GetAll();
        Medicamentos GetbyId(int id);
        //Create
        Medicamentos Inserir(Medicamentos medicamento);


        //UpdateConsultas
        Medicamentos Update(int id, Medicamentos medicamento);

        //Delete
        bool Delete(int id);
    }
}
