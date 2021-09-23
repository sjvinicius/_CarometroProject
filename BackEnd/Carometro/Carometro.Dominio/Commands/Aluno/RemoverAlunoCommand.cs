using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Aluno
{
    public class RemoverAlunoCommand : Notifiable<Notification>, ICommand
    {
        public RemoverAlunoCommand()
        {

        }

        public RemoverAlunoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                );
        }
    }
}
