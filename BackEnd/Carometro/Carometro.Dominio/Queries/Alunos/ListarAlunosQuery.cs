using Carometro.Comum.Enum;
using Carometro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Alunos
{
    public class ListarAlunosQuery : IQuery
    {
        public void Validar()
        {

        }

       
    }

        public class ListarAlunosResult
        {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnTurma Turma { get; set; }
        public EnStatus Status { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public int NumMatricula { get; set; }
        public string Foto { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
