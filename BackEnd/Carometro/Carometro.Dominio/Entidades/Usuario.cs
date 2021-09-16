using Carometro.Comum.Entidades;
using Carometro.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                .IsEmail(email, "Email", "Formato incorreto de email")
                .IsGreaterThan(senha, 6, "Senha", "A senha deve ter mais de 6 caracteres")
            );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
    }
}
