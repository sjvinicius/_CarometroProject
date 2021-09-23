using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Usuario;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Usuarios
{
    public class ExcluirUsuarioHandle : IHandlerCommand<RemoverUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ExcluirUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(RemoverUsuarioCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Id não pego", command.Notifications);
            }

            var usuarioExiste = _usuarioRepositorio.BuscarPorId(command.Id);
            if (usuarioExiste == null)
                return new GenericCommandResult(false, "Usuario inexistente", null);

            _usuarioRepositorio.Deletar(command.Id);

            return new GenericCommandResult(true, "Usuario excluído com sucesso!", null);
        }
    }
}
