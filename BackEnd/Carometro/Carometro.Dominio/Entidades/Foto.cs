using Carometro.Comum.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Entidades
{
    public class Foto : Entidade
    {
        public Foto(string fotoPath, Guid idAluno)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(fotoPath, "Foto", "Foto não pode ser vazia")
                .IsNotNull(idAluno, "IdAluno", "Id do Aluno não pode ser vazio")
                );

            if (IsValid)
            {
                FotoPath = fotoPath;
                IdAluno = idAluno;
            }
        }

        public string FotoPath { get; private set; }

        public Guid IdAluno { get; private set; }
        public virtual Aluno Aluno { get; private set; }
    }
}
