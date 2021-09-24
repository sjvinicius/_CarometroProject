using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carometro.Testes.Entidades
{
    public class AlunoTestes
    {
        [Fact]
        public void DeveRetornarSeAlunoForValido()
        {
            var aluno = new Aluno(
                "Vini",
                EnTurma.Manha,
                EnStatus.Cursando,
                "14232152231",
                "Rua Vitória, 242",
                1245123142,
                "Allahu"
                );

            Assert.True(aluno.IsValid, "Aluno é valido");
        }
    }
}
