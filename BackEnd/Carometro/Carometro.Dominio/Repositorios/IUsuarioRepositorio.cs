using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        //void AlterarSenha(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        /// <summary>
        /// Busca um usuário baseado no Id
        /// </summary>
        /// <param name="id">Id a ser utilizado na busca</param>
        /// <returns>Um usuário</returns>
        Usuario BuscarPorId(Guid id);
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns>Todos os usuários</returns>
        ICollection<Usuario> Listar();
    }
}
