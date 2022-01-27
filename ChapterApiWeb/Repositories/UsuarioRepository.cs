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
       
    }
}
