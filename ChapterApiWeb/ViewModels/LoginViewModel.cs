using System.ComponentModel.DataAnnotations;

namespace ChapterApiWeb.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string senha { get; set; }

    }
}
