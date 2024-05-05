using LinkedSpace.Model.Field;
using System;
using static LifeGame.Model.ByteConstants;

namespace LifeGame.Model.Creators
{
    internal class RandomField : EmptyField
    {
        private const double LIFE_PROBABILITY = 0.2;

        public RandomField() : base("Случайное поле") { }

        protected override void Random(Cell<byte>[] cells)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int k = 0; k < cells.Length; ++k) cells[k].SetData(random.NextDouble() < LIFE_PROBABILITY ? BYTE_1 : BYTE_0);
        }
    }
}