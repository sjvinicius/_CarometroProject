using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Usuarios;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Usuarios
{
    public class ListarColaboradoresHandle : IHandlerQuery<ListarUsuariosQuery>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ListarColaboradoresHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IQueryResult Handler(ListarUsuariosQuery query)
        {
            var usuarios = _usuarioRepositorio.ListarColab();

            var retornoUsuarios = usuarios.Select(
                x =>
                {
                    return new ListarUsuariosResult()
                    {
                        Id = x.Id,
                        DataCriacao = x.DataCriacao,
                        Email = x.Email,
                        Nome = x.Nome,
                        Senha = x.Senha,
                        TipoUsuario = x.TipoUsuario
                    };
                });

            return new GenericQueryResult(true, "Usuarios econtrados", retornoUsuarios);
        }
    }
}
