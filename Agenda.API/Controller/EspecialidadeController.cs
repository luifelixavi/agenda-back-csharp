
using Agenda.API.Application.DTO;
using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Data.Repositorie;
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
    public class EspecialidadeController : MainController<Especialidade, EspecialidadeCommand, EspecialidadeDTO>
    {
        private readonly IEspecialidadeRepositorie _especialidadeRepositorie;
        public EspecialidadeController(IEspecialidadeRepositorie especialidadeRepositorie, IMapper mapper) : base(especialidadeRepositorie, mapper)
        {
            _especialidadeRepositorie = especialidadeRepositorie;

        }

        [HttpPost("get-all-com-filtro")]
        public async Task<IActionResult> GetAllComFiltro(EspecialidadeListaPaginadoFiltroDTO filtro)
        {
            var servico = await _especialidadeRepositorie.ListaPaginado(filtro);

            if (servico is null)
            {
                return NotFound();
            }

            return CustomResponse(servico);
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
            await _especialidadeRepositorie.DesativarAsync(id,obj);

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
            await _especialidadeRepositorie.AtivarAsync(id, obj);

            return NoContent();
        }
    }
}
