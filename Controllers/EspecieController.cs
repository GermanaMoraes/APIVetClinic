using APIVetClinic.Models;
using APIVetClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private EspecieRepository repositorio = new EspecieRepository();

        /// <summary>
        /// Cadastrar uma espécie 
        /// </summary>
        /// <param name="especie"></param>
        /// <returns>Espécie cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Especies especie)
        {
            try
            {
                repositorio.Insert(especie);
                return Ok(especie);
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
      /// Listar todas as Espécies
      /// </summary>
      /// <returns>lista de espécies</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var especie = repositorio.GetAll();
                return Ok(especie);
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
        /// Alterar alguma espécie por meio do Id
        /// </summary>
        /// <param name="IdEspecie"></param>
        /// <param name="especie"></param>
        /// <returns></returns>
        [HttpPut("{IdEspecie}")]
        public IActionResult Alterar(int IdEspecie, Especies especie)
        {
            try
            {
                var buscarEspecie = repositorio.GetbyId(IdEspecie);
                if (buscarEspecie == null)
                { return NotFound(); }

                var usuarioAlterado = repositorio.Update(IdEspecie, especie);

                return Ok(especie);
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
        /// Deletar alguma espécie
        /// </summary>
        /// <param name="IdEspecie"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int IdEspecie)
        {
            try
            {
                var buscarEspecie = repositorio.GetbyId(IdEspecie);
                if (buscarEspecie == null)
                {
                    return NotFound();
                }

                repositorio.Delete(IdEspecie);

                return Ok(new { msg = "Espécie removida com sucesso" });
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








    

