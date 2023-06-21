using Core.Util.Model;

namespace Agenda.API.Application.DTO.Filtro
{
    public class CadastroListaPaginadoFiltroDTO : PageRequest
    {
        /// <summary>
        /// Filtro por nome para busca
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Filtro por account para buscar somente dados da empresa logada
        /// </summary>
        public Guid AccountId { get; set; }
    }
}
