using APIVetClinic.Repositories;
using APIVetClinic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescricaoController : ControllerBase
    {
        private PrescricaoRepository repositorio = new PrescricaoRepository();

        /// <summary>
        /// Cadastrar a Prescricao
        /// </summary>
        /// <param name="prescricao"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Prescricoes prescricao)
        {
            try
            {
                repositorio.Inserir(prescricao);
                return Ok(prescricao);
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
        /// Listar todas as prescricoes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var prescricao = repositorio.GetAll();
                return Ok(prescricao);
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

              
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Prescricoes prescricao)
        {
            try
            {
                var buscarPrescricao = repositorio.GetbyId(id);
                if (buscarPrescricao == null)
                { return NotFound(); }

                var usuarioAlterado = repositorio.Update(id, prescricao);

                return Ok(prescricao);
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

       
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                var buscarPrescricao = repositorio.GetbyId(id);
                if (buscarPrescricao == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Prescrição removida com sucesso" });
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

