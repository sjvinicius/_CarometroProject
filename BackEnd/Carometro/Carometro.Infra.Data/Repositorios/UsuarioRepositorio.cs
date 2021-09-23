using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Carometro.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CarometroContext _context;

        public UsuarioRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios
                .AsNoTracking()
                //.Include(x => x.Algo)
                .OrderBy(x => x.DataCriacao)
                .ToList();
        }

        public ICollection<Usuario> ListarAdmin()
        {
            return _context.Usuarios
                .AsNoTracking()
                .OrderBy(x => x.DataCriacao)
                .Where(x => x.TipoUsuario == EnTipoUsuario.Administrador)
                .ToList();
        }

        public ICollection<Usuario> ListarColab()
        {
            return _context.Usuarios
                .AsNoTracking()
                .OrderBy(x => x.DataCriacao)
                .Where(x => x.TipoUsuario == EnTipoUsuario.Colaborador)
                .ToList();
        }

        public void Deletar(Guid id)
        {
            _context.Usuarios.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
    }
}
