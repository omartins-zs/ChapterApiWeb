using ChapterApiWeb.Models;
using ChapterApiWeb.Repositories;
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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Get Listar | /api/usuarios
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            // Execption e
            catch (Exception e)
            {
                // Excetion(e.Message);
                throw new Exception(e.Message);
            }

        }


        // Get Buscar por Id | /api/usuarios/id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioProcurado = _usuarioRepository.BuscarPorId(id);

                if (usuarioProcurado == null)
                {
                    // Mensagem que esta dentro do Return adicionar no final
                    return NotFound("Usuario não encontrado!!");
                }

                return Ok(usuarioProcurado);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Post | /api/usuarios/
        [HttpPost]
        public IActionResult Cadastrar(Usuario u)
        {
            try
            {
                _usuarioRepository.Cadastrar(u);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Put | /api/usuarios/id
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario u)
        {
            try
            {
                _usuarioRepository.Atualizar(id, u);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // Delete | /api/usuarios/id
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
