using MongoDB.Bson;

namespace SorvetesRepository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(ObjectId? id);

        Task Add(T entity);

        Task Update(ObjectId? id, T entity);

        Task Delete(ObjectId id);
    }
}
