using LifeGame.Model.Field;
using LinkedSpace.Model.Create;
using LinkedSpace.Model.Field;
using System.Collections.Generic;

namespace LifeGame.Model.Creators
{
    public abstract class ConwaysLifeCreator : SpaceCreator<byte>
    {
        public new RectangularFieldCreationArgs Args => (RectangularFieldCreationArgs)base.Args;
        protected ConwaysLifeCreator(string description) : base(description) { }

        protected Cell<byte>[] CreateCells(byte[] data)
        {
            ConwaysLifeCell[] result = new ConwaysLifeCell[Args.Rows * Args.Columns];
            for (int k = 0; k < Args.Rows * Args.Columns; ++k) result[k] = new ConwaysLifeCell();
            if (!(data is null)) for (int k = 0; k < Args.Rows * Args.Columns; ++k) result[k].SetData(data[k]);

            return result;
        }

        protected byte[] CreateLinks(Cell<byte>[] cells)
        {
            List<byte> listOfLinks = new List<byte>();
            for (int k = 0; k < Args.Rows * Args.Columns; ++k) Connect(k);
            return listOfLinks.ToArray();

            void Connect(int k)
            {
                int i = k % Args.Columns;
                int j = k / Args.Columns;

                int xi, xj, count;

                count = listOfLinks.Count;
                listOfLinks.Add(default);
                cells[k].AddOutput(count);

                for (int di = -1; di < 2; ++di)
                {
                    for (int dj = -1; dj < 2; ++dj)
                    {
                        if (di == 0 && dj == 0) continue;

                        xi = i + di;
                        xj = j + dj;

                        if (xi < 0) xi = Args.Columns - 1;
                        else if (xi == Args.Columns) xi = 0;

                        if (xj < 0) xj = Args.Rows - 1;
                        else if (xj == Args.Rows) xj = 0;

                        cells[Index(xi, xj)].AddInput(count);
                    }
                }
            }

            int Index(int i, int j) => j * Args.Columns + i;
        }
    }
}