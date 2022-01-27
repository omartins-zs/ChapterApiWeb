using ChapterApiWeb.Contexts;
using ChapterApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChapterApiWeb.Repositories
{
    public class UsuarioRepository
    {
        // possui acesso aos dados -> Somente leitura
        private readonly ChapterContext _context;

        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }


        public void Cadastrar(Usuario u)
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
        }


        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }


        public void Atualizar(int id, Usuario u)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = u.Email;
                usuarioEncontrado.Senha = u.Senha;
                usuarioEncontrado.Tipo = u.Tipo;
            }
            _context.Usuarios.Update(usuarioEncontrado);

            _context.SaveChanges();
        }
    }
}
