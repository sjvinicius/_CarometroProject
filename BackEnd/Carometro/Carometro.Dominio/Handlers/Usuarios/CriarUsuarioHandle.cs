using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Utils;
using Carometro.Dominio.Commands.Usuario;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Usuarios
{
    public class CriarUsuarioHandle : Notifiable<Notification>, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(CriarContaCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult
                    (
                        false,
                        "Informe corretamente os dados do usuario",
                        command.Notifications
                    );
            }

            // Verificação de email (se existe)
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", "Informe outro email");

            // Criptografia
            command.Senha = Senha.Criptografar(command.Senha);

            // Salvar
            Usuario usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);
            if (!usuario.IsValid)
                return new GenericCommandResult(false, "Dados de usuário inválidos", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            // Mais coisas
            return new GenericCommandResult(true, "Usuario criado", "Token");
        }
    }
}
