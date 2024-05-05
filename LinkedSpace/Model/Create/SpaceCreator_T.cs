using LinkedSpace.Model.Color;
using LinkedSpace.Model.Field;
using LinkedSpace.Model.IO;

namespace LinkedSpace.Model.Create
{
    public abstract class SpaceCreator<T> : SpaceCreator
    {
        protected SpaceCreator(string description) : base(description) { }

        public abstract void Construct(out Cell<T>[] cells, out T[] links, out IDataIO<T> dataIO, out ColorConverter<T> converter);
    }
}