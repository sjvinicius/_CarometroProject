using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Carometro.Dominio.Commands.Usuario;
using Carometro.Dominio.Handlers.Usuarios;
using Carometro.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carometro.Testes.Handlers.Usuarios
{
    public class CriarUsuarioHandleTeste
    {
        [Fact]
        public void DevemRetornarCasoOsDadosDoHandleSejamValidos()
        {
            // Criar command
            var command = new CriarContaCommand();
            command.Nome = "Vini";
            command.Email = "email@email.com";
            command.Senha = "1234567";
            command.TipoUsuario = EnTipoUsuario.Administrador;

            // Criar handle
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());

            // Pegar e validar
            // Muda de ICommandResult pra GenericCommandResult
            var resultado = (GenericCommandResult)handle.Handler(command);

            
            Assert.True(resultado.Sucesso, "Usuário válido");
        }

    }
}
