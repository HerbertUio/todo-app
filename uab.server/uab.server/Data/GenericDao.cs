using NHibernate;
using NHibernate.Cfg;
using System;
using uab.server.Data.Contracts;

namespace uab.server.Data
{
    public class GenericDao<T> : IGenericDao<T>
    {
        public ISession session;
        public GenericDao()
        {
            LoadSession();
        }
        private void LoadSession()
        {
            var hibernateConfigurarion = new Configuration().Configure();
            var sessionFactory = hibernateConfigurarion.BuildSessionFactory();
            session = sessionFactory.OpenSession();
        }
        public T Save(T entity)
        {
            var tx = session.BeginTransaction();
            try
            {
                session.Save(entity);
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
                throw e;
            }
            return entity;
        }

        public T Update(T entity)
        {
            var tx = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(entity);
                tx.Commit();
            }
            catch (Exception s)
            {
                tx.Rollback();
                throw s;
            }
            return entity;
        }

        public void Delete(T entity)
        {
            var tx = session.BeginTransaction();
            try
            {
                session.Delete(entity);
                tx.Commit();
            }
            catch (Exception s)
            {
                tx.Rollback();
                throw s;
            }
        }
        public void DeleteById(int id)
        {
            var tx = session.BeginTransaction();
            try
            {
                // string concatenacion = "Hola mundo " + 1;
                // string contact = string.Format("{0}Hola mundo{1}", 1, 2);
                string cmd = string.Format(@"Delete {0} Where Id= :id", typeof(T).Name);
                session.CreateQuery(cmd).SetInt32("id", id).ExecuteUpdate();
                tx.Commit();
            }
            catch (Exception s)
            {
                tx.Rollback();
                throw s;
            }
        }

        public T GetById(int id)
        {
            return session.Get<T>(id);
        }
    }
}
