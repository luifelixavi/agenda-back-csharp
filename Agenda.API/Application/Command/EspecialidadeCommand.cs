namespace Agenda.API.Application.DTO
{
    public class EspecialidadeCommand : BaseCommand
    {
        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string Nome { get;  set; }
        /// <summary>
        /// Descrição breve do serviço
        /// </summary>
        public string Descricao { get;  set; }
        /// <summary>
        /// Status de como o serviço está 1 = ativo, 0 = Inativo
        /// </summary>
        public int Status { get;  set; }
    }

}
