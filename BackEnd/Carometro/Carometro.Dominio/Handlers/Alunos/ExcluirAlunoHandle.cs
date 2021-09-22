using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Alunos
{
    public class ExcluirAlunoHandle : IHandlerCommand<RemoverCommand>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public ExcluirAlunoHandle(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public ICommandResult Handler(RemoverCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Id não pego", command.Notifications);
            }

            var alunoExiste = _alunoRepositorio.BuscarPorID(command.Id);
            if (alunoExiste == null)
                return new GenericCommandResult(false, "Aluno inexistente", null);

            _alunoRepositorio.Deletar(command.Id);

            return new GenericCommandResult(true, "Aluno excluído com sucesso!", null);
        }
    }
}
