using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carometro.Comum.Enum;
using Carometro.Dominio.Commands.Usuario;
using Xunit;

namespace Carometro.Testes.Commands
{
    public class CriarUsuarioCommandTeste
    {
        [Fact]
        public void DeveRetornarSeDadosForemValidos()
        {
            var command = new CriarContaCommand(
                "Vini",
                "viniart@email.com",
                "1234567",
                EnTipoUsuario.Administrador
                );

            command.Validar();

            Assert.True(command.IsValid, "Os dados estão preenchidos corretamente");
        }
    }
}
