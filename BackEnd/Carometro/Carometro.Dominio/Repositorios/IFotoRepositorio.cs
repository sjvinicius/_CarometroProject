using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IFotoRepositorio
    {
        void Cadastrar(Foto foto);

        void Alterar(Foto foto);

        ICollection<Foto> Listar(bool? ativo = null);

        Foto BuscarPorID(Guid id);
    }
}
