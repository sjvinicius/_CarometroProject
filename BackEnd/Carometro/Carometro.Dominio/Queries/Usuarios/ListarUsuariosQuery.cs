using Carometro.Comum.Enum;
using Carometro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Queries.Usuarios
{
    public class ListarUsuariosQuery : IQuery
    {
        public bool? ativo { get; set; } = null;
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarUsuariosResult
    {
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public EnTipoUsuario TipoUsuario { get;  set; }
    }
}
