using APIVetClinic.Models;
using APIVetClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private ProprietarioRepository repositorio = new ProprietarioRepository();

      /// <summary>
      /// Cadastrar Proprietários
      /// </summary>
      /// <param name="proprietario"></param>
      /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Proprietarios proprietario)
        {
            try
            {
                repositorio.Insert(proprietario);
                return Ok(proprietario);
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
       /// Listar Proprietários
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var proprietario = repositorio.GetAll();
                return Ok(proprietario);
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
        /// Altera o Proprietário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="proprietario"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Proprietarios proprietario)
        {
            try
            {
                var buscarProprietario = repositorio.GetbyId(id);
                if (buscarProprietario == null)
               { return NotFound(); }

                var usuarioAlterado = repositorio.Update(id, proprietario);

                return Ok(proprietario);
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
       /// Deletar um Proprietário por meio de um Id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                var buscarProprietario = repositorio.GetbyId(id);
                if (buscarProprietario == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Proprietário removido com sucesso" });
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








    


    

