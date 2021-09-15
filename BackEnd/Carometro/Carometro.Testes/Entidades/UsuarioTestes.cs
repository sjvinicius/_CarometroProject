using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carometro.Testes
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            var usuario = new Usuario(
                "Vini",
                "viniart@gmail.com",
                "1234567",
                EnTipoUsuario.Administrador
                );

            Assert.True(usuario.IsValid, "Usuário é valido");
        }
    }
}
