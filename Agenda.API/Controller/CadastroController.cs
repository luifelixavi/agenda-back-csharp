
using Agenda.API.Application.DTO;
using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Domain.Interface;
using Agenda.API.Domain.Model;
using AutoMapper;
using Core.Util.Model;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

namespace Agenda.API.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : MainController<Cadastro,CadastroCommand,CadastroDTO>
    {
        private readonly ICadastroRepositorie _cadastroRepositorie;
        public CadastroController(ICadastroRepositorie cadastroRepositorie,IMapper mapper) : base(cadastroRepositorie, mapper)
        {
            _cadastroRepositorie = cadastroRepositorie;

        }

        [HttpPost("get-all-com-filtro")]
        public async Task<IActionResult> GetAllComFiltro(CadastroListaPaginadoFiltroDTO filtro)
        {
            var cadastro = await _cadastroRepositorie.ListaPaginado(filtro);

            if (cadastro is null)
            {
                return NotFound();
            }

            return CustomResponse(cadastro);
        }

        [HttpPut("desativar/{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            var obj = await _baseRepositorie.GetAsync(id);

            if (obj is null)
            {
                return NotFound();
            }
            id = obj.Id;
            await _cadastroRepositorie.DesativarAsync(id,obj);

            return NoContent();
        }

        [HttpPut("ativar/{id}")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            var obj = await _baseRepositorie.GetAsync(id);

            if (obj is null)
            {
                return NotFound();
            }
            id = obj.Id;
            await _cadastroRepositorie.AtivarAsync(id, obj);

            return NoContent();
        }
    }
}
