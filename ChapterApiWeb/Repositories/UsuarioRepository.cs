using ChapterApiWeb.Contexts;
using ChapterApiWeb.Interfaces;
using ChapterApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChapterApiWeb.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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


        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            // Metodo feito sem verificaçao Exclui direto | Metodo HTTP Atualizar tem Verificação para servir de Exemplo

            _context.Usuarios.Remove(usuarioEncontrado);

            _context.SaveChanges();
        }


        // Adiantando Metodo de Login | Será feito no Encontro Remoto 4 - 28/01 de Segurança de APIs
        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}