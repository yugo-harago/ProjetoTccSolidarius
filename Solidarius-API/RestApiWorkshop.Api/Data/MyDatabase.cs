using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using SolidariusAPI.Api.Models;

namespace SolidariusAPI.Api.Data
{
    public class MyDatabase : IDatabase
    {
        private readonly ISession db;
        public MyDatabase(ISession db)
        {
            db.FlushMode = FlushMode.Manual;
            this.db = db;
        }
        public IQueryable<Beneficiario> Beneficiario => db.Query<Beneficiario>();

        public IQueryable<Pedido> Pedido => db.Query<Pedido>();

        public IQueryable<Doador> Doador => db.Query<Doador>();

        public IQueryable<Mediador> Mediador => db.Query<Mediador>();
        public IQueryable<Item> Item => db.Query<Item>();
        public IQueryable<Usuario> Usuario => db.Query<Usuario>();
        public ISQLQuery Query(string sql) => db.CreateSQLQuery(sql);

        public T Insert<T>(T entity)
        {
            db.Clear();
            try
            {
                db.Save(entity);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            db.Flush(); //force the SQL INSERT
            db.Refresh(entity); //re-read the state (after the trigger executes)
            return entity;
        }
        public async Task<T> InsertAsync<T>(T entity)
        {
            db.Clear();
            try
            {
                await db.SaveAsync(entity);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            db.Flush(); //force the SQL INSERT
            db.Refresh(entity); //re-read the state (after the trigger executes)
            return entity;
        }
        public T Update<T>(T entity)
        {
            db.Clear();
            db.Update(entity);
            db.Flush();
            db.Refresh(entity);
            return entity;
        }

        public void Delete(object entity)
        {
            db.Clear();
            db.Delete(entity);
            db.Flush();
        }
    }
}