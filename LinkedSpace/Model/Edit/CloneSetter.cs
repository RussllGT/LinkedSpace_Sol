using System;

namespace LinkedSpace.Model.Edit
{
    public abstract class CloneSetter<TData> : Setter<TData> where TData : ICloneable
    {
        public override void Save(int index, TData data)
        {
            if (_changes.ContainsKey(index)) return;
            _changes[index] = (TData)data.Clone();
        }
    }
}