using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IAlunoRepositorio
    {
        void Cadastrar(Aluno aluno);

        void Alterar(Aluno aluno);

        ICollection<Aluno> Listar();

        Aluno BuscarPorNome(string nome);

        Aluno BuscarPorID(Guid id);
    }
}
