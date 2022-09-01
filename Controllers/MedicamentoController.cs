using APIVetClinic.Models;
using APIVetClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private MedicamentoRepository repositorio = new MedicamentoRepository();

        /// <summary>
        /// Cadastrar um Medicamento
        /// </summary>
        /// <param name="medicamentos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Medicamentos medicamentos)
        {
            try
            {
                repositorio.Inserir(medicamentos);
                return Ok(medicamentos);
            }

            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "Falha na conexão.",
                    erro = ex.Message
                });

            }
        }

        /// <summary>
        /// Listar todos os Medicamentos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var medicamentos = repositorio.GetAll();
                return Ok(medicamentos);
            }

            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro",
                    erro = ex.Message
                });
            }

        }

        /// <summary>
        /// Alterar um Medicamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicamentos"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Medicamentos medicamentos)
        {
            try
            {
                var buscarMedicamento = repositorio.GetbyId(id);
                if (buscarMedicamento == null)
                { return NotFound(); }

                var usuarioAlterado = repositorio.Update(id, medicamentos);

                return Ok(medicamentos);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "Erro",
                    erro = ex.Message
                });
            }
        }

        /// <summary>
        /// Deletar um Medicamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                var buscarMedicamento = repositorio.GetbyId(id);
                if (buscarMedicamento == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Medicamento removido com sucesso" });
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new
                {
                    msg = "Erro",
                    erro = ex.Message
                });
            }
        }

    }

}

