using Agenda.API.Application.DTO;
using Agenda.API.Application.DTO.Filtro;
using Agenda.API.Configuration.Model;
using Agenda.API.Data.Repositorie;
using Agenda.API.Domain.Interface;
using Agenda.API.Domain.Model;
using Core.Util.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Agenda.API.Data.Repositorie
{
    public class EspecialidadeRepositorie : BaseRepositorie<Especialidade>, IEspecialidadeRepositorie
    {

        public EspecialidadeRepositorie(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings, "Especialidade")
        {

        }

        public async Task<PageResult<Especialidade>> ListaPaginado(EspecialidadeListaPaginadoFiltroDTO filtro)
        {
            FilterDefinition<Especialidade> filter;

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                filter = Builders<Especialidade>.Filter.Eq(c => c.Nome, filtro.Nome);
            }
            else
            {
                filter = Builders<Especialidade>.Filter.Empty;
            }
            var dados = await _collection
            .Find(filter)
            .Skip((filtro.PageIndex - 1) * filtro.PageSize)
            .Limit(filtro.PageSize)
            .ToListAsync();

            var count = await _collection.CountDocumentsAsync(filter);

            return new PageResult<Especialidade>(dados, count);
        }

        public async Task<List<Especialidade>> ListaCheckBox(EspecialidadeListaCheckBoxFiltroDTO filtro)
        {
            var filter = Builders<Especialidade>.Filter.Eq(c => c.Nome, filtro.Nome);

            var dados = await _collection
            .Find(filter)
            .ToListAsync();

            return dados;
        }

        public async Task DesativarAsync(Guid id, Especialidade atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            atualizar.setStatus(0);
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }

        public async Task AtivarAsync(Guid id, Especialidade atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            atualizar.setStatus(1);
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }
    }
}
