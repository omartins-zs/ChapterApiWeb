using ChapterApiWeb.Controllers;
using ChapterApiWeb.Interfaces;
using ChapterApiWeb.Models;
using ChapterApiWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
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
    }
}
