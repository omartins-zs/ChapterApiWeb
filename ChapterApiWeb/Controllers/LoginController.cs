using ChapterApiWeb.Interfaces;
using ChapterApiWeb.Models;
using ChapterApiWeb.Repositories;
using ChapterApiWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChapterApiWeb.Controllers
{
    // Para informar que estamos trabalhando com Json
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
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

                // Criando Claims do Token(Claims e usado para armazenar os dados que vem no token)
                var minhasClaims = new[] {
                   new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
               	// JTI da Dependia JWT Claims usado para guardar Ids
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo.ToString())
                };

                // Chave que vai dentro da Crendecial 
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

                // Credencial 
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Criaçao do Token
                var meuToken = new JwtSecurityToken(
                    issuer: "chapterApiWeb",
                    audience: "chapterApiWeb",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(60),
                // Credencial Recebida que contem a Chave e o Algoritimo Credenciado
                    signingCredentials: cred
                );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                        }
                );
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
