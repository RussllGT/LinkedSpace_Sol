using System.Collections.Generic;

namespace LinkedSpace.Model.Color
{
    public abstract class ColorConverter<TData>
    {
        protected Dictionary<string, Argb> _colors;

        public Argb this[string description] { get => _colors[description]; set => _colors[description] = value; }

        public abstract Argb Convert(TData data);

        public IEnumerable<string> GetDescriptions() => _colors.Keys;
    }
}