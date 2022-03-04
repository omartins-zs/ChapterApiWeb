using ChapterApiWeb.Models;

namespace ChapterApiWeb.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
