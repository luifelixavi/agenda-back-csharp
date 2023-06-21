namespace Agenda.API.Application.DTO
{
    public class ServicoCommand : BaseCommand
    {
        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string Nome { get;  set; }
        /// <summary>
        /// Tipo do serviço prestado
        /// </summary>
        public string TipoServico { get;  set; }
        /// <summary>
        /// Tempo em que o serviço é realizado
        /// </summary>
        public int TempoExecucao { get;  set; }
        /// <summary>
        /// Descrição breve do serviço
        /// </summary>
        public string Descricao { get;  set; }
        /// <summary>
        /// Valor do serviço
        /// </summary>
        public double Valor { get;  set; }
        /// <summary>
        /// Status de como o serviço está 1 = ativo, 0 = Inativo
        /// </summary>
        public int Status { get;  set; }
    }

}
