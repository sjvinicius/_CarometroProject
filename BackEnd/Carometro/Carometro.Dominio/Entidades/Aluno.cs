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
    public class Aluno : Entidade
    {
        public Aluno()
        {

        }
        public Aluno(string nome, EnTurma turma, EnStatus status, string rg, string endereco, int numMatricula, string foto)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                .IsNotNull(turma, "Turma", "Turma não pode ser vazia")
                .IsNotNull(status, "Status", "Status não pode ser vazio")
                .IsNotEmpty(rg, "RG", "RG não pode ser vazio")
                .IsNotEmpty(endereco, "Endereco", "Endereço não pode ser vazio")
                .IsNotNull(numMatricula, "NumMatricula", "Numero de matricula não pode ser vazio")
                .IsNotEmpty(foto, "Foto", "Caminho da foto não pode ser vazio")
            );

            if (IsValid)
            {
                Nome = nome;
                Turma = turma;
                Status = status;
                RG = rg;
                Endereco = endereco;
                NumMatricula = numMatricula;
                Foto = foto;
            }
        }

        public string Nome { get; private set; }
        public EnTurma Turma { get; private set; }
        public EnStatus Status { get; private set; }
        public string RG { get; private set; }
        public string Endereco { get; private set; }
        public int NumMatricula { get; private set; }
        public string Foto { get; private set; }

    }
}
