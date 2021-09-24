using Carometro.Comum.Commands;
using Carometro.Comum.Handlers.Contracts;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Handlers.Alunos
{
    public class CriarAlunoHandle : Notifiable<Notification>, IHandlerCommand<CadastrarCommand>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public CriarAlunoHandle(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public ICommandResult Handler(CadastrarCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos do pacote", command.Notifications);
            }

            // Mudar para verificar RG
            var alunoExiste = _alunoRepositorio.BuscarPorNome(command.Nome);
            if (alunoExiste != null)
                return new GenericCommandResult(false, "Aluno já cadastrado", null);

            var aluno = new Aluno(command.Nome, command.Turma, command.Status, command.RG, command.Endereco, command.NumMatricula, command.Foto);
            if (!aluno.IsValid)
                return new GenericCommandResult(false, "Falha ao cadastrar o pacote", command.Notifications);

            _alunoRepositorio.Cadastrar(aluno);

            return new GenericCommandResult(true, "Aluno cadastrado com sucesso!", aluno);

        }
    }
}
