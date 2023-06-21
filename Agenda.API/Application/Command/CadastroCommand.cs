using Agenda.API.Domain.Enum;

namespace Agenda.API.Application.DTO
{
    public class CadastroCommand : BaseCommand
    {
        /// <summary>
        /// Nome do Cadastrado
        /// </summary>
        public string Nome { get;  set; }
        /// <summary>
        /// Sobrenome do Cadastrado
        /// </summary>
        public string Sobrenome { get;  set; }
        /// <summary>
        /// CPF do Cadastrado
        /// </summary>
        public string Cpf { get;  set; }
        /// <summary>
        /// RG do Cadastrado
        /// </summary>
        public string Rg { get;  set; }
        /// <summary>
        /// Data de Nascimento do Cadastrado
        /// </summary>
        public DateTime DataNascimento { get;  set; }
        /// <summary>
        /// Branco, Pardo, Preto, Indigena, Amarelo E Outro
        /// </summary>
        public EnumCor Cor { get;  set; }
        /// <summary>
        /// Masculino, Feminino e Outro
        /// </summary>
        public EnumSexo Sexo { get;  set; }
        /// <summary>
        /// Telefone do Cadastrado
        /// </summary>
        public string Telefone { get;  set; }
        /// <summary>
        /// Solteiro,Casado,Divorciado,Viuvo e SeparadoJudicialmente
        /// </summary>
        public EnumEstadoCivil EstadoCivil { get;  set; }
        /// <summary>
        /// Status
        /// </summary>
        public int Status { get;  set; }
    }

}
