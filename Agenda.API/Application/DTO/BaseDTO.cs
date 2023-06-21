namespace Agenda.API.Application.DTO
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Guid UsuarioCriacaoId { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid AccountId { get; set; }
    }
}
