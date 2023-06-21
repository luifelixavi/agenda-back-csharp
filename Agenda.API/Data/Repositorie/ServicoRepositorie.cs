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
    public class ServicoRepositorie : BaseRepositorie<Servico>, IServicoRepositorie
    {

        public ServicoRepositorie(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings, "Servico")
        {

        }

        public async Task<PageResult<Servico>> ListaPaginado(ServicoListaPaginadoFiltroDTO filtro)
        {
            FilterDefinition<Servico> filter;

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                filter = Builders<Servico>.Filter.Eq(c => c.Nome, filtro.Nome);
            }
            else
            {
                filter = Builders<Servico>.Filter.Empty;
            }
            var dados = await _collection
            .Find(filter)
            .Skip((filtro.PageIndex - 1) * filtro.PageSize)
            .Limit(filtro.PageSize)
            .ToListAsync();

            var count = await _collection.CountDocumentsAsync(filter);

            return new PageResult<Servico>(dados, count);
        }

        public async Task<List<Servico>> ListaCheckBox(ServicoListaCheckBoxFiltroDTO filtro)
        {
            var filter = Builders<Servico>.Filter.Eq(c => c.Nome, filtro.Nome);

            var dados = await _collection
            .Find(filter)
            .ToListAsync();

            return dados;
        }

        public async Task DesativarAsync(Guid id, Servico atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            atualizar.setStatus(0);
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }

        public async Task AtivarAsync(Guid id, Servico atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            atualizar.setStatus(1);
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }
    }
}
