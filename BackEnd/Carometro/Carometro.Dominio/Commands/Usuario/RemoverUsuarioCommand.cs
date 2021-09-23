using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Usuario
{
    public class RemoverUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public RemoverUsuarioCommand()
        {

        }

        public RemoverUsuarioCommand(Guid id)
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
