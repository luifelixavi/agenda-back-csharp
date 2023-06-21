namespace Agenda.API.Domain.Model
{
    public class Servico : BaseModel
    {
        public Servico()
        {
        }

        public Servico(string nome, string tipoServico, int tempoExecucao, string descricao, double valor, int status)
        {
            Nome = nome;
            TipoServico = tipoServico;
            TempoExecucao = tempoExecucao;
            Descricao = descricao;
            Valor = valor;
            Status = status;
        }



        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Tipo do serviço prestado
        /// </summary>
        public string TipoServico { get; private set; }
        /// <summary>
        /// Tempo em que o serviço é realizado
        /// </summary>
        public int TempoExecucao { get; private set; }
        /// <summary>
        /// Descrição breve do serviço
        /// </summary>
        public string Descricao { get; private set; }
        /// <summary>
        /// Valor do serviço
        /// </summary>
        public double Valor { get; private set; }
        /// <summary>
        /// Status do trabalho
        /// </summary>
        public int Status { get; private set; }

        public void setStatus(int status)
        {
            this.Status = status;
        }
    }
}
