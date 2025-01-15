using System.Collections.Generic;
using System.Linq;
using uab.server.Data;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Business
{
    public class TodoAppBusiness
    {
        private readonly ITodoAppDao todoAppDao;
        public TodoAppBusiness()
        {
            todoAppDao = new TodoAppDao();
        }

        public TodoApp SaveOrUpdate(TodoApp data)
        {
            // opcion 1
            var dato = new TodoApp();
            if (data.Id == 0)
            {
                // nuevo dato
                dato = todoAppDao.Save(data);
            }
            else
            {
                // actualizar dato
                dato = todoAppDao.Update(data);
            }
            return dato;

            // opcion 2
            //return (data.Id == 0) 
            //        ? todoAppDao.Save(data) 
            //        : todoAppDao.Update(data);
        }
        public TodoApp GetById(int entityId)
        {
            return todoAppDao.GetById(entityId);
        }
        public void DeleteById(int entityId)
        {
            todoAppDao.DeleteById(entityId);
        }

        public int ContarActiviades(int usuarioId)
        {
            return todoAppDao.ContarActiviades(usuarioId);
        }

        public List<TodoApp> GetAll()
        {
            return todoAppDao.GetAll().ToList();
        }

        public IList<TodoApp> SearchByDescription(string description)
        {
            return todoAppDao.SearchByDescription(description);
        }

        public int ContarActividadesScript(int usuarioId)
        {
            return todoAppDao.ContarActividadesScript(usuarioId);
        }

        public List<TodoAppModel> FindByUserName(string name)
        {
            return todoAppDao.FindByUserName(name).ToList();
        }
    }
}
