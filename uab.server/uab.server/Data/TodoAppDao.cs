using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using uab.server.Data.Contracts;
using uab.server.Entities;

namespace uab.server.Data
{
    public class TodoAppDao: GenericDao<TodoApp>, ITodoAppDao
    {
        public int ContarActiviades(int usuarioId)
        {
            var resultado = session.QueryOver<TodoApp>()
                            .Where(src => src.Usuario.Id == usuarioId);

            return resultado.List().ToList().Count();
        }

        public IList<TodoApp> GetAll()
        {
            var resultado = session.QueryOver<TodoApp>();
            return resultado.List();
        }

        public IList<TodoApp> SearchByDescription(string description)
        {
            var result = session.QueryOver<TodoApp>()
                .Where(src => src.Descripcion.IsLike(description, MatchMode.Anywhere));
            return result.List();
        }

        public int ContarActividadesScript(int usuarioId)
        {
            var query = @"SELECT COUNT(ta.Id) FROM todoApp ta
                            INNER JOIN usuario us ON ta.IdUsuario = us.Id
                            WHERE us.Id = :userId";
            var result = session.CreateSQLQuery(query)
                .SetParameter("userId", usuarioId)
                .UniqueResult();
            return Convert.ToInt32(result);
        }

        public IList<TodoApp> SearchByUserName(string userName)
        {
            Usuario usuarioAlias = null;
            var result = session.QueryOver<TodoApp>()
                .JoinAlias(src => src.Usuario, () => usuarioAlias)
                .Where(() => usuarioAlias.Nombre.IsLike(userName, MatchMode.Anywhere))
                .List();
            return result;
        }

        public IList<TodoApp> FindByUserFechaNacimiento(DateTime from, DateTime to)
        {
            Usuario usuarioAlias = null;
            var result = session.QueryOver<TodoApp>()
                .JoinAlias(src => src.Usuario, () => usuarioAlias)
                .Where(() => usuarioAlias.FechaNacimiento.Month >= from.Month 
                            && usuarioAlias.FechaNacimiento.Year >= from.Year
                            && usuarioAlias.FechaNacimiento.Month <= to.Month
                            && usuarioAlias.FechaNacimiento.Year <= to.Year)
                .List();
            return result;
        }

        public IList<TodoAppModel> FindByUserName(string name)
        {
            var query = @"SELECT ta.* FROM todoApp ta
                            INNER JOIN usuario us ON ta.IdUsuario = us.Id
                            WHERE us.Nombre = :userName";
            var result = session.CreateSQLQuery(query)
                .SetParameter("userName", name)
                .SetResultTransformer(Transformers.AliasToBean<TodoAppModel>());
            return result.List<TodoAppModel>();
        }
    }
}
