using Carometro.Comum.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Aluno
{
    class AtualizarCommand : Notifiable<Notification>, ICommand
    {
        public AtualizarCommand()
        {

        }


        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
