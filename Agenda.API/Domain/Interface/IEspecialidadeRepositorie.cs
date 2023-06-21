

using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Domain.Model;
using Core.Util.Model;

namespace Agenda.API.Domain.Interface
{
    public interface IEspecialidadeRepositorie : IBaseRepositorie<Especialidade>
    {
        public Task<PageResult<Especialidade>> ListaPaginado(EspecialidadeListaPaginadoFiltroDTO filtro);
        public Task<List<Especialidade>> ListaCheckBox(EspecialidadeListaCheckBoxFiltroDTO filtro);
        public  Task DesativarAsync(Guid id, Especialidade atualizar);
        public  Task AtivarAsync(Guid id, Especialidade atualizar);

    }
}
