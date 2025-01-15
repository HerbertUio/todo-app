namespace uab.server.Data.Contracts
{
    public interface IGenericDao<T>
    {
        T Save(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteById(int Id);
        T GetById(int id);
    }
}
