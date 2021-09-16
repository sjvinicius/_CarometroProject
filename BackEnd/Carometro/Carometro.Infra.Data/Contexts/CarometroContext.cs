using Carometro.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Infra.Data.Contexts
{
    public class CarometroContext : DbContext
    {
        public CarometroContext(DbContextOptions<CarometroContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Tabela Usuários

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(30);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(30)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(200);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(200)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).HasColumnType("int");
            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");

            #endregion



            #region Tabela Alunos

            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            modelBuilder.Entity<Aluno>().Property(x => x.Id);

            // Enum foram tirados os números, cuidado!!
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).HasMaxLength(30);
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).HasColumnType("varchar(30)");
            modelBuilder.Entity<Aluno>().Property(x => x.Nome).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.Turma).HasColumnType("varchar(15)");
            modelBuilder.Entity<Aluno>().Property(x => x.Turma).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.Status).HasColumnType("int");
            modelBuilder.Entity<Aluno>().Property(x => x.Status).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.RG).HasMaxLength(14);
            modelBuilder.Entity<Aluno>().Property(x => x.RG).HasColumnType("varchar(14)");
            modelBuilder.Entity<Aluno>().Property(x => x.RG).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.Endereco).HasMaxLength(100);
            modelBuilder.Entity<Aluno>().Property(x => x.Endereco).HasColumnType("varchar(100)");
            modelBuilder.Entity<Aluno>().Property(x => x.Endereco).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.NumMatricula).HasColumnType("int");
            modelBuilder.Entity<Aluno>().Property(x => x.NumMatricula).IsRequired();

            modelBuilder.Entity<Aluno>().Property(x => x.Foto).HasMaxLength(200);
            modelBuilder.Entity<Aluno>().Property(x => x.Foto).HasColumnType("varchar(200)");
            modelBuilder.Entity<Aluno>().Property(x => x.Foto).IsRequired();

            // Um pra um, relacionamento
            //modelBuilder.Entity<Aluno>()
            //    .HasOne<Foto>(f => f.FotoAluno)
            //    .WithOne(a => a.Aluno)
            //    .HasForeignKey<Foto>(fk => fk.IdAluno);

            #endregion


            //#region Tabela Fotos

            //modelBuilder.Entity<Foto>().ToTable("Fotos");

            //modelBuilder.Entity<Foto>().Property(x => x.Id);

            //modelBuilder.Entity<Foto>().Property(x => x.FotoPath).HasMaxLength(255);
            //modelBuilder.Entity<Foto>().Property(x => x.FotoPath).HasColumnType("varchar(255)");
            //modelBuilder.Entity<Foto>().Property(x => x.FotoPath).IsRequired();

            //#endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
