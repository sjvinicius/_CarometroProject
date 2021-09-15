using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {

        }

        public void Alterar(Usuario usuario)
        {

        }

        public void AlterarSenha(Usuario usuario)
        {

        }

        public Usuario BuscarPorEmail(string email)
        {
            return null;
        }

        public Usuario BuscarPorId(Guid id)
        {
            return new Usuario("Vini", "viniart@email.com", "1234567", EnTipoUsuario.Administrador);
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return new List<Usuario>()
            {
                new Usuario("Vini", "viniart@email.com", "1234567", EnTipoUsuario.Administrador),
                new Usuario("Paulo", "paulo@email.com", "1234567", EnTipoUsuario.Colaborador)
            };
        
        }
        
        
    }
}
