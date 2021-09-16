using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Commands.Usuario
{
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {
        public CriarContaCommand()
        {
                
        }

        public CriarContaCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio")
                .IsEmail(Email, "Email", "Formato incorreto de email")
                .IsGreaterThan(Senha, 6, "Senha", "A senha deve ter mais de 6 caracteres")
            );
        }


    }
}
