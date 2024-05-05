using LinkedSpace.Model.Color;
using LinkedSpace.Model.Create;
using LinkedSpace.Model.Edit;
using System;
using System.Threading.Tasks;

namespace LinkedSpace.Model.Field
{
    public abstract class Space<TData> : Space 
    {
        private const string INCORRECT_MATRIX_SIZE_EXCEPTION = "Размерность матрицы переданных данных не совпадает с размерностью поля";

        protected Cell<TData>[] _cells;
        protected TData[] _links;
        protected IDataIO<TData> _dataIO;
        protected Setter<TData> _setter;

        private readonly ColorConverter<TData> _converter;
        public ColorConverter<TData> Converter => _converter;

        protected Space(SpaceCreator<TData> spaceCreator, out Argb[] colors) 
        { 
            spaceCreator.Construct(out _cells, out _links, out _dataIO, out _converter);
            colors = new Argb[_cells.Length];
            for (int i = 0; i < _cells.Length; ++i) colors[i] = _converter.Convert(_cells[i].GetData());
        }

        public override void Next(Argb[] colors)
        {
            Parallel.For(0, _cells.Length, i => _cells[i].Push(_links));
            Parallel.For(0, _cells.Length, i => _cells[i].Pull(_links));

            ++_step;
            for (int i = 0; i < _cells.Length; ++i) colors[i] = _converter.Convert(_cells[i].GetData());
        }

        public override async Task<Argb> ChangeCell(object sender, int index)
        {
            TData data = _cells[index].GetData();
            _setter.Save(index, data);
            TData task = await _setter.Edit(sender, data);
            _cells[index].SetData(task);
            return _converter.Convert(_cells[index].GetData());
        }

        public TData[] GetData()
        {
            TData[] result = new TData[_cells.Length];
            for (int i = 0; i < _cells.Length; ++i)
            {
                result[i] = _cells[i].GetData();
            }
            return result;
        }

        public void SetData(TData[] data)
        {
            CheckLength(data);
            for (int i = 0; i < _cells.Length; ++i)
            {
                _cells[i].SetData(data[i]);
            }
        }

        private void CheckLength(TData[] data) { if (data.Length != _cells.Length) throw new ArgumentException(INCORRECT_MATRIX_SIZE_EXCEPTION); }

        public override void Commit()
        {
            _setter.Changes.Clear();
        }

        public override void RollBack()
        {
            foreach (int index in _setter.Changes.Keys)
            {
                _cells[index].SetData(_setter.Changes[index]);
            }
            _setter.Changes.Clear();
        }
    }
}