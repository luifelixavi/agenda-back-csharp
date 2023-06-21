using Agenda.API.Application.DTO;
using Agenda.API.Domain.Model;
using AutoMapper;

namespace Agenda.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Servico, ServicoCommand>().ReverseMap();
            CreateMap<Servico, ServicoDTO>().ReverseMap();

            CreateMap<Especialidade, EspecialidadeCommand>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeDTO>().ReverseMap();

            CreateMap<Cadastro, CadastroCommand>().ReverseMap();
            CreateMap<Especialidade, CadastroDTO>().ReverseMap();
        }
    }
}
