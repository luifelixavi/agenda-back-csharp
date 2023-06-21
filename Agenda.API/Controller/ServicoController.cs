
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
    public class ServicoController : MainController<Servico,ServicoCommand,ServicoDTO>
    {
        private readonly IServicoRepositorie _servicoRepositorie;
        public ServicoController(IServicoRepositorie servicoRepositorie,IMapper mapper) : base(servicoRepositorie, mapper)
        {
            _servicoRepositorie = servicoRepositorie;

        }

        [HttpPost("get-all-com-filtro")]
        public async Task<IActionResult> GetAllComFiltro(ServicoListaPaginadoFiltroDTO filtro)
        {
            var servico = await _servicoRepositorie.ListaPaginado(filtro);

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
            await _servicoRepositorie.DesativarAsync(id,obj);

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
            await _servicoRepositorie.AtivarAsync(id, obj);

            return NoContent();
        }
    }
}
