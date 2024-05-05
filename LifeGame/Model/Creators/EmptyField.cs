using LinkedSpace.Model.Color;
using LinkedSpace.Model.Field;
using LinkedSpace.Model;

namespace LifeGame.Model.Creators
{
    public class EmptyField : ConwaysLifeCreator
    {
        public EmptyField() : base("Пустое поле") { }
        protected EmptyField(string description) : base(description) { }

        public override void Construct(out Cell<byte>[] cells, out byte[] links, out IDataIO<byte> dataIO, out ColorConverter<byte> converter)
        {
            cells = CreateCells(null);
            links = CreateLinks(cells);
            dataIO = new ConwaysLifeDataIO();
            converter = new ConwaysLifeColors();
            Random(cells);
        }

        protected virtual void Random(Cell<byte>[] cells) { }
    }
}