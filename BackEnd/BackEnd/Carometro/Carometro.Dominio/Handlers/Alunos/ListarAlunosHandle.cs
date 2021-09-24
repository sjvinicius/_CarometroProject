using Carometro.Comum.Handlers.Contracts;
using Carometro.Comum.Queries;
using Carometro.Dominio.Queries.Alunos;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Alunos
{
    public class ListarAlunosHandle : IHandlerImageQuery<ListarAlunosQuery>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public ListarAlunosHandle(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public IQueryResult Handler(ListarAlunosQuery query, string imageSrc)
        {
            var alunos = _alunoRepositorio.Listar();

            var retornoAlunos = alunos.Select(
                x =>
                {
                    return new ListarAlunosResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Turma = x.Turma,
                        Status = x.Status,
                        RG = x.RG,
                        Endereco = x.Endereco,
                        NumMatricula = x.NumMatricula,
                        Foto = x.Foto,
                        DataCriacao = x.DataCriacao,
                        ImageSrc = imageSrc + x.Foto
                    };
                });

            return new GenericQueryResult(true, "Alunos econtrados", retornoAlunos);
        }

    }
}
