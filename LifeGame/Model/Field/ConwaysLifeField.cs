using LifeGame.Model.Creators;
using LinkedSpace.Model.Color;
using LinkedSpace.Model.Field;
using LifeGame.Model;
using System.IO;

namespace LifeGame.Model.Field
{
    public class ConwaysLifeField : Space<byte>
    {
        public ConwaysLifeField(ConwaysLifeCreator creator, out Argb[] colors) : base(creator, out colors) 
        {
            _setter = new ConwaysLifeSetter();
        }

        public override bool WriteFile(FileInfo file)
        {
            _dataIO.WriteFile(file, GetData());
            return true;
        }
    }
}