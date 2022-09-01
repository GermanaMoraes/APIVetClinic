using APIVetClinic.Models;
using APIVetClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
       private ConsultaRepository repositorio = new ConsultaRepository();

       /// <summary>
       /// Inserir uma consulta Nova
       /// </summary>
       /// <param name="consulta"></param>
       /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Consultas consulta)
        {
            try
            {
                repositorio.Inserir(consulta);
                return Ok(consulta);
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

        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var consulta = repositorio.GetAll();
                return Ok(consulta);
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
        public IActionResult Alterar(int id, Consultas consulta)
        {
            try
            {
                var buscarConsulta = repositorio.GetbyId(id);
                if (buscarConsulta == null)
                { return NotFound(); }

                var usuarioAlterado = repositorio.Update(id, consulta);

                return Ok(consulta);
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
                var buscarConsulta = repositorio.GetbyId(id);
                if (buscarConsulta == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Consulta removida com sucesso" });
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

