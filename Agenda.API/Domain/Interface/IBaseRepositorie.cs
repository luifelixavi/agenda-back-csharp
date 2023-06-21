

using Agenda.API.Domain.Model;

namespace Agenda.API.Domain.Interface
{
    public interface IBaseRepositorie<T> where T : BaseModel
    {
        public Task<List<T>> GetAsync();

        public Task<T?> GetAsync(Guid id);

        public Task CreateAsync(T novo);

        public Task UpdateAsync(Guid id, T atualizar);

        public Task RemoveAsync(Guid id);
    }
}
