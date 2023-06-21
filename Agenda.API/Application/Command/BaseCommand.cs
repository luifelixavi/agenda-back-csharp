namespace Agenda.API.Application.DTO
{
    public class BaseCommand
    {
        public Guid UsuarioCriacaoId { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid AccountId { get; set; }
    }

}
