using LinkedSpace.Model.Color;
using LinkedSpace.Model.Field;
using LinkedSpace.Model;

namespace LifeGame.Model.Creators
{
    public class FieldFromFile : ConwaysLifeCreator
    {
        public FieldFromFile() : base("Прочитать из файла") { }

        public override void Construct(out Cell<byte>[] cells, out byte[] links, out IDataIO<byte> dataIO, out ColorConverter<byte> converter)
        {
            ConwaysLifeDataIO reader = new ConwaysLifeDataIO();
            byte[] data = reader.ReadFile(Args.File);
            Args.Rows = reader.Rows;
            Args.Columns = reader.Columns;
            cells = CreateCells(data);
            links = CreateLinks(cells);
            dataIO = reader;
            converter = new ConwaysLifeColors();
        }
    }
}