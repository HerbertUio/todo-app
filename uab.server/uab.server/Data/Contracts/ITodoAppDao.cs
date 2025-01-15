using System.Collections.Generic;
using uab.server.Entities;

namespace uab.server.Data.Contracts
{
    public interface ITodoAppDao: IGenericDao<TodoApp>
    {
        int ContarActiviades(int usuarioId);
        IList<TodoApp> GetAll();
        IList<TodoApp> SearchByDescription(string description);
        int ContarActividadesScript(int usuarioId);
        IList<TodoAppModel> FindByUserName(string name);
    }
}
