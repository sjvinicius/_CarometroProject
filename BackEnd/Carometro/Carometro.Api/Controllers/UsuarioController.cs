using Carometro.Comum.Commands;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Autenticacao;
using Carometro.Dominio.Commands.Usuario;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Handlers.Autenticacao;
using Carometro.Dominio.Handlers.Usuarios;
using Carometro.Dominio.Queries.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCarometroSenai321"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definir claims
            var claims = new[]
            {
                // Pq family name?
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "Carometro",
                    "Carometro",
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUp(CriarContaCommand command, [FromServices] CriarUsuarioHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarUsuariosHandle handle)
        {
            ListarUsuariosQuery query = new();

            return (GenericQueryResult)handle.Handler(query);
        }


        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandle handle)
        {
            var resultado = (GenericCommandResult)handle.Handler(command);

            if (resultado.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)resultado.Data);
                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }

    }
}
