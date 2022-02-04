using ChapterApiWeb.Models;
using ChapterApiWeb.Repositories;
using ChapterApiWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChapterApiWeb.Controllers
{
    // Para informar que estamos trabalhando com Json
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public LoginController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Mesmo sendo Login uma Consulta normante usamos get dessa vez usar o post pela seguranca de os dados nao irem pela Url.
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                // Verificaçao pré Login
                Usuario usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail e/ou senha invalidos");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
