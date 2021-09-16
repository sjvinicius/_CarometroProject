using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Usuarios
{
    public class ListarUsuariosHandle : IHandlerQuery<ListarUsuariosQuery>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ListarUsuariosHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IQueryResult Handler(ListarUsuariosQuery query)
        {
            var usuarios = _usuarioRepositorio.Listar(query.ativo);

            var RetornaUsuarios = usuarios.Select(
                x =>
                    {
                        return new ListarUsuariosResult()
                        {
                            Nome = x.Nome,
                            Email = x.Email,
                            Senha = x.Senha,
                            TipoUsuario = x.TipoUsuario
                        };
                    }
                );
            return new GenericQueryResult(true, "Usuário encontrado", RetornaUsuarios);
        }
    }
}
