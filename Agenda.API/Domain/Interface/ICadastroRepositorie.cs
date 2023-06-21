

using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Domain.Model;
using Core.Util.Model;

namespace Agenda.API.Domain.Interface
{
    public interface ICadastroRepositorie : IBaseRepositorie<Cadastro>
    {
        public Task<PageResult<Cadastro>> ListaPaginado(CadastroListaPaginadoFiltroDTO filtro);
        public Task<List<Cadastro>> ListaCheckBox(CadastroListaCheckBoxFiltroDTO filtro);
        public  Task DesativarAsync(Guid id, Cadastro atualizar);
        public  Task AtivarAsync(Guid id, Cadastro atualizar);

    }
}
