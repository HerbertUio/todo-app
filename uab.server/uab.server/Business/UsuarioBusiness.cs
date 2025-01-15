using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class UsuarioBusiness
    {
        private readonly IUsuarioDao repository;
        public UsuarioBusiness()
        {
            repository = new UsuarioDao();
        }
        public Usuario SaveOrUpdate(Usuario data)
        {
            return (data.Id == 0) 
                ? repository.Save(data) 
                : repository.Update(data);
        }
        public Usuario GetById(int entityId)
        {
            return repository.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            repository.DeleteById(entityId);
        }
    }
}
