using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkedSpace.Model.Edit
{
    public abstract class Setter<TData>
    {
        protected readonly Dictionary<int, TData> _changes = new Dictionary<int, TData>();
        public Dictionary<int, TData> Changes => _changes;

        protected Setter() {}

        public abstract Task<TData> Edit(object sender, TData data);

        public abstract void Save(int index, TData data);
    }
}