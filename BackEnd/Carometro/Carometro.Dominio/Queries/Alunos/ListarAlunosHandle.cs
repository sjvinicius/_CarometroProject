using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Alunos;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers
{
    public class ListarAlunosHandle : IHandlerQuery<ListarAlunosQuery>
    {
        // Injeção de Dependência
        private readonly IAlunoRepositorio _alunoRepositorio;

        public ListarAlunosHandle(IAlunoRepositorio alunoRepositorio)
        {

            _alunoRepositorio = alunoRepositorio;
        }
        public IQueryResult Handler(ListarAlunosQuery query)
        {
            var alunos = _alunoRepositorio.Listar(query.ativo);

            var retornaAlunos = alunos.Select(
                    x =>
                    {
                        return new ListarAlunosResult()
                        {
                            Nome = x.Nome,
                            Turma = x.Turma,
                            Status = x.Status,
                            RG = x.RG,
                            Endereco = x.Endereco,
                            NumMatricula = x.NumMatricula

                        };
                    }
                );
                return new GenericQueryResult(true, "Alunos encontrados", retornaAlunos);
        }
    }
}
