using Carometro.Comum.Enum;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Carometro.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Infra.Data.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly CarometroContext _context;
        public AlunoRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public void Alterar(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Aluno BuscarPorID(Guid id)
        {
            return _context.Alunos.FirstOrDefault(a => a.Id == id);
        }

        public Aluno BuscarPorNome(string nome)
        {
            return _context.Alunos.FirstOrDefault(a => a.Nome.ToLower() == nome.ToLower());
        }

        public void Cadastrar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public ICollection<Aluno> Listar()
        {
            return _context.Alunos
                    .AsNoTracking()
                    .OrderBy(p => p.DataCriacao)
                    .ToList();
        }

        public void Deletar(Guid id)
        {
            _context.Alunos.Remove(BuscarPorID(id));
            _context.SaveChanges();
        }
    }
}
