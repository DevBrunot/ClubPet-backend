using System.Collections.Generic;
using System.Linq;
using MeuProjetoAPI.Models;

namespace ClubPetAPI.Data
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetUsuario(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool UpdateUsuario(int id, Usuario usuario)
        {
            var existingUsuario = _context.Usuarios.Find(id);
            if (existingUsuario == null) return false;

            existingUsuario.CPF = usuario.CPF;
            existingUsuario.Email = usuario.Email;
            existingUsuario.Nome = usuario.Nome;
            existingUsuario.Senha = usuario.Senha;
            existingUsuario.Telefone = usuario.Telefone;
            existingUsuario.Tipo = usuario.Tipo;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
    }
}