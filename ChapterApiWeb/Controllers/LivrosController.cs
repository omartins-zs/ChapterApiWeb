using ChapterApiWeb.Models;
using ChapterApiWeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChapterApiWeb.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]

    // Para usar autorização e metodo do JWT e Authentication
    [Authorize]
    public class LivrosController : ControllerBase
    {

        private readonly LivroRepository _livroRepository;
        public LivrosController(LivroRepository
        livroRepository)
        {
            _livroRepository = livroRepository;
        }
        // GET /api/livros
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // GET /api/livros/{id}
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livroProcurado = _livroRepository.BuscarPorId(id);
                if (livroProcurado == null)
                {
                    return NotFound();
                }
                return Ok(livroProcurado);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        // POST /api/livros
        [HttpPost]
        // recebe a informacao do livro que deseja salvar do corpo da requisição
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // PUT /api/livros/{id}
        [HttpPut("{id}")]
        // o id passado no PUT /api/livros/1
        // recebe a informacao do livro que deseja
        // atualizar no corpo da requisição
        public IActionResult Atualizar(int id, Livro livro)
        {

            try
            {
                // atualizar as informações de um livro
                // no corpo da requisição, corresponde as novas informações do livro
                // na solicitação, o id do livro a ser atualizado
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpDelete("{id}")]
        // o id passado no DELETE /api/livros/1
        public IActionResult Deletar(int id)
        {

            try
            {
                _livroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
