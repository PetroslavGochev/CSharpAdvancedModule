using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;

namespace SantaWorkshop.Repositories.Models
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }
        public IReadOnlyCollection<T> Models
            => this.models.AsReadOnly();

        public void Add(T model)
        => this.models.Add(model);

        public abstract T FindByName(string name);


        public bool Remove(T model)
            => this.models.Remove(model);
    }
}
