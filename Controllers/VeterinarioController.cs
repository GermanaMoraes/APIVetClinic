using Microsoft.AspNetCore.Http;
using APIVetClinic.Repositories;
using APIVetClinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private VeterinarioRepository repositorio = new VeterinarioRepository();

        /// <summary>
        /// Cadastrar um veterinário novo
        /// </summary>
        /// <param name="veterinario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Veterinarios veterinario)
        {
            try
            {
                repositorio.Inserir(veterinario);
                return Ok(veterinario);
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
        /// Listar todos os veterinários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var veterinario = repositorio.GetAll();
                return Ok(veterinario);
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
        /// Alterar um veterinário por meio de um Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="veterinario"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Veterinarios veterinario)
        {
            try
            {
                var buscarVeterinario = repositorio.GetbyId(id);
                if (buscarVeterinario == null)
                { return NotFound(); }

                var usuarioAlterado = repositorio.Update(id, veterinario);

                return Ok(veterinario);
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
       /// Deletar um veterinário por meio de um Id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                var buscarVeterinario = repositorio.GetbyId(id);
                if (buscarVeterinario == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Veterinario removido com sucesso" });
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

