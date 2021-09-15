using Carometro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Autenticacao
{
    public class RecuperarSenha : Notifiable<Notification>, ICommand
    {
        public RecuperarSenha(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "formato incorreto de email")
            );
        }
    }
}
