using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Aluno
{
    public class CadastrarCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarCommand()
        {

        }

        public CadastrarCommand(string nome, EnTurma turma, EnStatus status, string rg, string endereco, int numMatricula)
        {
            Nome = nome;
            Turma = turma;
            Status = status;
            RG = rg;
            Endereco = endereco;
            NumMatricula = numMatricula;
        }

        public string Nome { get; private set; }
        public EnTurma Turma { get; private set; }
        public EnStatus Status { get; private set; }
        public string RG { get; private set; }
        public string Endereco { get; private set; }
        public int NumMatricula { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio")
                .IsNotNull(Turma, "Turma", "Turma não pode ser vazia")
                .IsNotNull(Status, "Status", "Status não pode ser vazio")
                .IsNotEmpty(RG, "RG", "RG não pode ser vazio")
                .IsNotEmpty(Endereco, "Endereco", "Endereço não pode ser vazio")
                .IsNotNull(NumMatricula, "NumMatricula", "Numero de matricula não pode ser vazio")
            );
        }

    }
}
