namespace RestApi_MongoDB.Services
{
    public interface IBaseService<T>
    {
        public Task<List<T>> GetAsync();

        public Task<T> GetByIdAsync(Guid id);

        public Task<T> InsertAsync(T value);

        public Task<T> UpdateAsync(Guid id, T value);

        public Task RemoveAsync(Guid id);
    }
}