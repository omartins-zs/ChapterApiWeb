using System.ComponentModel.DataAnnotations;

namespace ChapterApiWeb.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string senha { get; set; }


        // Criado para Realizar Teste e usar no LoginControllerTeste e IUsuarioRepository


        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }
    }
}
