using APIVetClinic.Models;
using APIVetClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private ExameRepository repositorio = new ExameRepository();

        /// <summary>
        /// Cadastra Exame
        /// </summary>
        /// <param name="exames"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Exames exames)
        {
            try
            {
                repositorio.Inserir(exames);
                return Ok(exames);
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
        /// Listar todos os Exames
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var exames = repositorio.GetAll();
                return Ok(exames);
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
        /// Alterar algum exame por meio do Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exames"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Exames exames)
        {
            try
            {
              var usuarioAlterado = repositorio.Update(id, exames);

                return Ok(exames);
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
        /// Deletar o Exame por meio do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                var buscarExame = repositorio.GetbyId(id);
                if (buscarExame == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Exame removido com sucesso" });
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

