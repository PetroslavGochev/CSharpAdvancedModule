using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories.Models
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;
        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
            => this.models.AsReadOnly();

        public void Add(IDecoration model)
            => this.models.Add(model);

        public IDecoration FindByType(string type)
            => this.models.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IDecoration model)
            => this.models.Remove(model);
    }
}
