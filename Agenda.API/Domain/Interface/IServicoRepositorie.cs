

using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Domain.Model;
using Core.Util.Model;

namespace Agenda.API.Domain.Interface
{
    public interface IServicoRepositorie : IBaseRepositorie<Servico>
    {
        public Task<PageResult<Servico>> ListaPaginado(ServicoListaPaginadoFiltroDTO filtro);
        public Task<List<Servico>> ListaCheckBox(ServicoListaCheckBoxFiltroDTO filtro);
        public  Task DesativarAsync(Guid id, Servico atualizar);
        public  Task AtivarAsync(Guid id, Servico atualizar);

    }
}
