﻿using APIVetClinic.Models;
using APIVetClinic.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private AnimalRepository repositorio = new AnimalRepository();

        /// <summary>
        /// Cadastrar um Animal
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Animais animal)
        {
            try
            {
                repositorio.Insert(animal);
                return Ok(animal);
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
        /// Lista todos os Animais
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var animal = repositorio.GetAll();
                return Ok(animal);
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
        /// Alterar algum Animal
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animal"></param>
        /// <returns></returns>        
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Animais animal)
        {
            try
            {
                var buscarAnimal = repositorio.GetbyId(id);
                if (buscarAnimal == null)
                { return NotFound(); }

                var usuarioAlterado = repositorio.Update(id, animal);

                return Ok(animal);
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
                var buscarAnimal = repositorio.GetbyId(id);
                if (buscarAnimal == null)
                {
                    return NotFound();
                }

                repositorio.Delete(id);

                return Ok(new { msg = "Animal removido com sucesso" });
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








    


  
