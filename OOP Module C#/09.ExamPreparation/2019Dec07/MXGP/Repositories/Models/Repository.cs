using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Repositories.Models
{
    public class Repository<T> : IRepository<T>
    {
        private List<T> data;
        public Repository()
        {
            this.data = new List<T>();
        }

        public IReadOnlyCollection<T> Data
            => this.data.AsReadOnly();

        public void Add(T model)
        => this.data.Add(model);
        

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Data;
        }

        public T GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T model)
            => this.data.Remove(model);
    }
}
