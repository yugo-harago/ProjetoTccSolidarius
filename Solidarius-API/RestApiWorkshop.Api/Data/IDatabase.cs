﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using SolidariusAPI.Api.Models;

namespace SolidariusAPI.Api.Data
{
    public interface IDatabase
    {
        IQueryable<Beneficiario> Beneficiario { get; }
        IQueryable<Pedido> Pedido { get; }
        IQueryable<Doador> Doador { get; }
        IQueryable<Mediador> Mediador { get; }
        IQueryable<Item> Item{ get; }
        IQueryable<Usuario> Usuario { get; }
        IQueryable<Notificacao> Notificacao { get; }
        ISQLQuery Query(string sql);
        public T Insert<T>(T entity);
        public Task<T> InsertAsync<T>(T entity);
        public T Update<T>(T entity);
        public void Delete(object entity);
    }
}