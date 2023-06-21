namespace Agenda.API.Domain.Model
{
    public class Especialidade : BaseModel
    {
        public Especialidade()
        {
        }

        public Especialidade(string nome, string descricao, int status)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }

        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Descrição breve do serviço
        /// </summary>
        public string Descricao { get; private set; }
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
