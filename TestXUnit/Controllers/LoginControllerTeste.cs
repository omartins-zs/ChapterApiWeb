using ChapterApiWeb.Controllers;
using ChapterApiWeb.Interfaces;
using ChapterApiWeb.Models;
using ChapterApiWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestXUnit.Controllers
{
    public class LoginControllerTeste
    {

        [Fact]
        public void LoginController_Retornar_UserInvalido()

        {
            //  Arrange = Organizaçao
            var repositorioFalso = new Mock<IUsuarioRepository>();

            //configuraçao do que o repositorio falso prcisa
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            // Dados que vão ir na configuração do Login(email, senha)
            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.Email = "email@email.com";
            dadosUsuario.Senha = "12345";

            var controller = new LoginController(repositorioFalso.Object);

            //  Act = Acao
            var resultado = controller.Login(dadosUsuario);

            //  Assert = Afrimar
            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }


        [Fact]
        public void LoginController_Retornar_Usuario()

        {
            // Arrange = Organizaçao
            // Se mudar o issuer Ira dar Errado que o que precisa ser Feito e Testado | Concluido
            string issuerValidacao = "chapterApiWeb";

            // Criando Usuario Fake
            Usuario usuarioFake = new Usuario();
            usuarioFake.Email = "teste@teste.com";
            usuarioFake.Senha = "123456";

            var repositorioFalso = new Mock<IUsuarioRepository>();
            //configuraçao do que o repositorio falso prcisa
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((usuarioFake));

            var controller = new LoginController(repositorioFalso.Object);


            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.Email = "teste@teste.com";
            dadosUsuario.Senha = "123456";

            //  Act = Acao 
            // 2º OkObjectResult PARA FORÇAR O return a ser do Tipo Solicitado
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            // Usando Split para Formatar e Separar Token e Pegar a 3º Posição do Array
            var tokenFormatado = resultado.Value.ToString().Split(' ')[3];

            var jstHandler = new JwtSecurityTokenHandler();
            var jwtToken = jstHandler.ReadJwtToken(tokenFormatado);

            //  Assert = Afirmar(Resultado Esperado)
            Assert.Equal(issuerValidacao, jwtToken.Issuer);

        }
    }
}
