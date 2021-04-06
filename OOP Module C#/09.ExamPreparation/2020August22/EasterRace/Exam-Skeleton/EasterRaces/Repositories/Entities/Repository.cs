using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;

        protected  Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models
            => this.models.AsReadOnly();

        public void Add(T model)
            => this.models.Add(model);

        public IReadOnlyCollection<T> GetAll()
            => this.Models;

        public abstract T GetByName(string name);


        public bool Remove(T model)
        => this.models.Remove(model);
    }
}
