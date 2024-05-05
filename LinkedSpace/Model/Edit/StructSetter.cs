namespace LinkedSpace.Model.Edit
{
    public abstract class StructSetter<TData> : Setter<TData> where TData : struct
    {
        public override void Save(int index, TData data)
        {
            if (_changes.ContainsKey(index)) return;
            _changes[index] = data;
        }
    }
}