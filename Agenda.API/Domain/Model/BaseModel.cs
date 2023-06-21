using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Agenda.API.Domain.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
        }

        public BaseModel(Guid id, DateTime dataCriacao, DateTime dataAtualizacao, Guid usuarioCriacaoId, Guid usuarioAtualizacaoId, Guid companyId)
        {
            Id = id;
            DataCriacao = dataCriacao;
            DataAtualizacao = dataAtualizacao;
            UsuarioCriacaoId = usuarioCriacaoId;
            UsuarioAtualizacaoId = usuarioAtualizacaoId;
            CompanyId = companyId;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Guid UsuarioCriacaoId { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
