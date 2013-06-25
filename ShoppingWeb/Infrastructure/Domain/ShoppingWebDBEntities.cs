using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Infrastructure.Domain
{
    public partial class ShoppingWebDBEntities
    {
        //public void Add<TEntity>(TEntity entity)
        //    where TEntity : class
        //{
        //    CreateObjectSet<TEntity>().AddObject(entity);
        //}

        public void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entry = GetEntry(entity);
            entry.SetModified();
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entry = GetEntry(entity);
            entry.Delete();
        }

        private ObjectStateEntry GetEntry<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entry = ObjectStateManager.GetObjectStateEntry(entity);
            if (entry.State == System.Data.EntityState.Detached)
            {
                CreateObjectSet<TEntity>().Attach(entity);
            }

            return ObjectStateManager.GetObjectStateEntry(entity);
        }
    }
}