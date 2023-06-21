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
    public class CadastroRepositorie : BaseRepositorie<Cadastro>, ICadastroRepositorie
    {

        public CadastroRepositorie(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings, "Cadastro")
        {

        }

        public async Task<PageResult<Cadastro>> ListaPaginado(CadastroListaPaginadoFiltroDTO filtro)
        {
            FilterDefinition<Cadastro> filter;

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                filter = Builders<Cadastro>.Filter.Eq(c => c.Nome, filtro.Nome);
            }
            else
            {
                filter = Builders<Cadastro>.Filter.Empty;
            }
            var dados = await _collection
            .Find(filter)
            .Skip((filtro.PageIndex - 1) * filtro.PageSize)
            .Limit(filtro.PageSize)
            .ToListAsync();

            var count = await _collection.CountDocumentsAsync(filter);

            return new PageResult<Cadastro>(dados, count);
        }

        public async Task<List<Cadastro>> ListaCheckBox(CadastroListaCheckBoxFiltroDTO filtro)
        {
            var filter = Builders<Cadastro>.Filter.Eq(c => c.Nome, filtro.Nome);

            var dados = await _collection
            .Find(filter)
            .ToListAsync();

            return dados;
        }

        public async Task DesativarAsync(Guid id, Cadastro atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            atualizar.setStatus(0);
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }

        public async Task AtivarAsync(Guid id, Cadastro atualizar)
        {
            atualizar.DataAtualizacao = DateTime.Now;
            atualizar.Id = id;
            atualizar.setStatus(1);
            await _collection.ReplaceOneAsync(x => x.Id == id, atualizar);
        }
    }
}
