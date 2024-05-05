using LinkedSpace.Model;
using System.Collections.Generic;
using System.IO;
using static LifeGame.Model.ByteConstants;

namespace LifeGame.Model
{
    public class ConwaysLifeDataIO : IDataIO<byte>
    {
        private const int STORAGETYPE_SIZE = 8;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public byte[] ReadFile(FileInfo file)
        {
            List<byte> compressed = new List<byte>();
            using (BinaryReader reader = new BinaryReader(new FileStream(file.FullName, FileMode.Open, FileAccess.Read)))
            {
                Rows = reader.ReadInt32();
                Columns = reader.ReadInt32();
                while (reader.BaseStream.Position != reader.BaseStream.Length) compressed.Add(reader.ReadByte());
            }

            List<byte> uncompressed = new List<byte>();
            int count = 0;
            for (int i = 0; i < compressed.Count; ++i)
            {
                for (int j = 0; j < STORAGETYPE_SIZE; ++j)
                {
                    uncompressed.Add((byte)(compressed[i] & BYTE_1 << j) == 0 ? BYTE_0 : BYTE_1);
                    if (++count == Rows * Columns) break;
                }
            }
            return uncompressed.ToArray();
        }

        public void WriteFile(FileInfo file, byte[] data)
        {
            Rows = data.GetUpperBound(0) + 1;
            Columns = data.Length / Rows;

            List<byte> compressed = new List<byte>();
            byte current = BYTE_0;
            byte mask = BYTE_1;
            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i] != 0) current += mask;
                mask = (byte)(mask << 1);

                if (mask == 0)
                {
                    compressed.Add(current);
                    current = BYTE_0;
                    mask = BYTE_1;
                }
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(file.FullName, FileMode.Create)))
            {
                writer.Write(Rows);
                writer.Write(Columns);
                foreach (byte b in compressed) writer.Write(b);
            }
        }
    }
}