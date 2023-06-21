
using Agenda.API.Application.DTO;
using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Domain.Interface;
using Agenda.API.Domain.Model;
using AutoMapper;
using Core.Util.Model;
using Core.Util.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Agenda.API.Controller
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MainController<Entity, EntityCommand, EntityDTO> : ControllerBase
        where Entity : BaseModel
        where EntityCommand : BaseCommand
        where EntityDTO : BaseDTO
    {
        protected readonly IBaseRepositorie<Entity> _baseRepositorie;
        protected ICollection<string> Erros = new List<string>();
        private readonly IMapper _mapper;

        public MainController(
            IBaseRepositorie<Entity> baseRepositorie,
            IMapper mapper)
        {
            _baseRepositorie = baseRepositorie;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _baseRepositorie.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var obj = await _baseRepositorie.GetAsync(id);

            if (obj is null)
            {
                return NotFound();
            }

            return CustomResponse(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EntityCommand newServico)
        {
            await _baseRepositorie.CreateAsync(_mapper.Map<EntityCommand, Entity>(newServico));

            return CustomResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EntityCommand updatedServico)
        {
            var obj = await _baseRepositorie.GetAsync(id);

            if (obj is null)
            {
                return NotFound();
            }

            id = obj.Id;

            await _baseRepositorie.UpdateAsync(id, _mapper.Map<EntityCommand, Entity>(updatedServico));

            return NoContent();
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _baseRepositorie.GetAsync(id);

            if (obj is null)
            {
                return NotFound();
            }

            await _baseRepositorie.RemoveAsync(id);

            return NoContent();
        }

        protected void AdicionarErro(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErro()
        {
            Erros.Clear();
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErro(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        //protected ActionResult CustomResponse(ValidationResult validationResult)
        //{
        //    foreach (var erro in validationResult.Errors)
        //    {
        //        AdicionarErro(erro.ErrorMessage);
        //    }

        //    return CustomResponse();
        //}

        protected ActionResult CustomResponse(ResponseResult resposta)
        {
            ResponsePossuiErros(resposta);

            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta == null || !resposta.Errors.Mensagens.Any()) return false;

            foreach (var mensagem in resposta.Errors.Mensagens)
            {
                AdicionarErro(mensagem);
            }

            return true;
        }
    }
}
