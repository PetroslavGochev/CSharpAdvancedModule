using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace CounterStrike.Repositories.Models
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models
            => models;

        public void Add(T model)
        {
            if(model == null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }
            this.models.Add(model);
        }

        public abstract T FindByName(string name);

        public bool Remove(T model)
        => this.models.Remove(model);
    }
}
