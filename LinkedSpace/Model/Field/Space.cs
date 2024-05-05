using LinkedSpace.Model.Color;
using System.IO;
using System.Threading.Tasks;

namespace LinkedSpace.Model.Field
{
    public abstract class Space
    {
        protected uint _step = 0;
        public uint Step => _step;
        protected Space() { }

        public abstract void Next(Argb[] colors);
        public abstract Task<Argb> ChangeCell(object sender, int index);
        public abstract bool WriteFile(FileInfo file);
        public abstract void Commit();
        public abstract void RollBack();
    }
}