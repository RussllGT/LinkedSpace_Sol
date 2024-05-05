using System.IO;

namespace LinkedSpace.Model.Create
{
    public class RectangularFieldCreationArgs : CreationArgs
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public FileInfo File { get; set; }
    }
}
