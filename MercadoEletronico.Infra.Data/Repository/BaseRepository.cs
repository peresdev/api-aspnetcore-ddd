using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronico.Infra.Data.Repository
{
    public class BaseRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        protected readonly SqliteContext _sqliteContext;

        public BaseRepository(SqliteContext mySqlContext)
        {
            _sqliteContext = mySqlContext;
        }

        protected virtual void Insert(TEntity obj)
        {
            _sqliteContext.Set<TEntity>().Add(obj);
            _sqliteContext.SaveChanges();
        }

        protected virtual void Update(TEntity obj)
        {
            _sqliteContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqliteContext.SaveChanges();
        }

        protected virtual void Update<TProperty>(TEntity obj, params PropertyEntry<TEntity, TProperty>[] propsToIgnore)
        {
            _sqliteContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            foreach (var item in propsToIgnore)
                item.IsModified = false;

            _sqliteContext.SaveChanges();
        }

        protected virtual void Delete(int id)
        {
            _sqliteContext.Set<TEntity>().Remove(Select(id));
            _sqliteContext.SaveChanges();
        }

        protected virtual IList<TEntity> Select() =>
            _sqliteContext.Set<TEntity>().ToList();

        protected virtual TEntity Select(int id) =>
            _sqliteContext.Set<TEntity>().Find(id);
    }
}
