using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Handlers.Alunos;
using Carometro.Dominio.Queries.Alunos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Carometro.Api.Controllers
{
    [Route("v1/student")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult Create(CadastrarCommand command, [FromServices] CriarAlunoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarAlunosHandle handle)
        {
            ListarAlunosQuery query = new ListarAlunosQuery();

            //var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            //if (tipoUsuario.Value.ToString() == EnTipoUsuario.Administrador.ToString())
            //    query.Ativo = EnStatusPacote.Ativo;

            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
