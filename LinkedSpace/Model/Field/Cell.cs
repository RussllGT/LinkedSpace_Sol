using System.Collections.Generic;

namespace LinkedSpace.Model.Field
{
    public abstract class Cell<TData>
    {
        protected TData _data;
        protected readonly List<int> _output = new List<int>();
        protected readonly List<int> _input = new List<int>();

        protected Cell() { }

        public void AddOutput(int index) => _output.Add(index);
        public void AddInput(int index) => _input.Add(index);
        
        public abstract void Push(TData[] links);
        public abstract void Pull(TData[] links);

        public abstract TData GetData();
        public abstract void SetData(TData data);
    }
}