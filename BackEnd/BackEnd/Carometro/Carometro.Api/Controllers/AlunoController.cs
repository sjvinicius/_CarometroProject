using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Handlers.Alunos;
using Carometro.Dominio.Queries.Alunos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Carometro.Api.Controllers
{
    [Route("v1/student")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public AlunoController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult Create([FromForm]CadastrarCommand command, [FromServices] CriarAlunoHandle handle)
        {
            if(SaveImage(command.ArquivoImagem) != null)
            {
                command.Foto = SaveImage(command.ArquivoImagem);
            }
            return (GenericCommandResult)handle.Handler(command);
        }

        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarAlunosHandle handle)
        {

            var imageSrc = string.Format("{0}://{1}{2}/Images/", Request.Scheme, Request.Host, Request.PathBase);
            ListarAlunosQuery query = new();

            return (GenericQueryResult)handle.Handler(query, imageSrc);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete]
        public GenericCommandResult Delete(RemoverAlunoCommand command, [FromServices] ExcluirAlunoHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [NonAction]
        public string SaveImage(IFormFile imageFile)
        {
            if(imageFile != null)
            {
                // var file = Request.Form.Files;
                string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

                var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                return imageName;
            }

            return null;
        }
    }
}
