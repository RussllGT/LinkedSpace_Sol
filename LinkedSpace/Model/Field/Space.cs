using LinkedSpace.Model.Color;
using System.IO;

namespace LinkedSpace.Model.Field
{
    public abstract class Space
    {
        protected uint _step = 0;
        public uint Step => _step;
        protected Space() { }

        public abstract void Next(Argb[] colors);
        public abstract bool WriteFile(FileInfo file);
    }
}