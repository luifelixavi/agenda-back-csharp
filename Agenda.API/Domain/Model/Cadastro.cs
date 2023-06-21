
using Agenda.API.Domain.Enum;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.API.Domain.Model
{
    /// <summary>
    /// Tabela de Cadastros
    /// </summary>
    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

        public Cadastro(string nome, string sobrenome, string cpf, string rg, DateTime dataNascimento, EnumCor cor, EnumSexo sexo, string telefone, EnumEstadoCivil estadoCivil)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Cor = cor;
            Sexo = sexo;
            Telefone = telefone;
            EstadoCivil = estadoCivil;
        }






        /// <summary>
        /// Nome do Cadastrado
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Sobrenome do Cadastrado
        /// </summary>
        public string Sobrenome { get; private set; }
        /// <summary>
        /// CPF do Cadastrado
        /// </summary>
        public string Cpf { get; private set; }
        /// <summary>
        /// RG do Cadastrado
        /// </summary>
        public string Rg { get; private set; }
        /// <summary>
        /// Data de Nascimento do Cadastrado
        /// </summary>
        public DateTime DataNascimento { get; private set; }
        /// <summary>
        /// Branco, Pardo, Preto, Indigena, Amarelo E Outro
        /// </summary>
        public EnumCor Cor { get; private set; }
        /// <summary>
        /// Masculino, Feminino e Outro
        /// </summary>
        public EnumSexo Sexo { get; private set; }
        /// <summary>
        /// Telefone do Cadastrado
        /// </summary>
        public string Telefone { get; private set; }
        /// <summary>
        /// Solteiro,Casado,Divorciado,Viuvo e SeparadoJudicialmente
        /// </summary>
        public EnumEstadoCivil EstadoCivil { get; private set; }
        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; private set; }

        public void setStatus(int status)
        {
            this.Status = status;
        }
    }
}
