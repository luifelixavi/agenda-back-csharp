namespace Agenda.API.Application.DTO
{
    public class EspecialidadeDTO : BaseDTO
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
        /// Status do trabalho
        /// </summary>
        public int Status { get; set; }
    }
}
