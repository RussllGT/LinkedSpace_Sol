using System.IO;

namespace LinkedSpace.Model
{
    public interface IDataIO<TData>
    {
        TData[] ReadFile(FileInfo file);
        void WriteFile(FileInfo file, TData[] data);
    }
}