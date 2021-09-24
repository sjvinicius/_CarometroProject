using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Autenticacao;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Autenticacao
{
    public class LogarHandle : Notifiable<Notification>, IHandlerCommand<LogarCommand>
    {
        // La injéccion de dependencia
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LogarHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(LogarCommand command)
        {
            // Verificar Comand
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Buscar usuário
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            // Existindo
            if (usuario == null)
                return new GenericCommandResult(false, "Email inválido", null);

            // Validar senha
            if (!Senha.ValidarHashes(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida!", null);

            return new GenericCommandResult(true, "Logado com sucesso!", usuario);
        }
    }
}
