using LinkedSpace.Model.Field;
using static LifeGame.Model.ByteConstants;

namespace LifeGame.Model.Field
{
    internal class ConwaysLifeCell : Cell<byte>
    {
        private byte _isAlive;

        public override byte GetData() => _isAlive;

        public override void Pull(byte[] links)
        {
            byte count = BYTE_0;
            foreach (int other in _input) count += links[other];
            _isAlive = count == BYTE_3 || (count == BYTE_2 && _isAlive == BYTE_1) ? BYTE_1 : BYTE_0;
        }

        public override void Push(byte[] links)
        {
            foreach (int other in _output) links[other] = _isAlive;
        }

        public override void SetData(byte data) => _isAlive = data;
    }
}