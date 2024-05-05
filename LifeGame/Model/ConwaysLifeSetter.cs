using LinkedSpace.Model.Edit;
using System.Threading.Tasks;
using static LifeGame.Model.ByteConstants;

namespace LifeGame.Model
{
    public class ConwaysLifeSetter : StructSetter<byte>
    {
        public override Task<byte> Edit(object sender, byte data)
        {
            byte value = data == 0 ? BYTE_1 : BYTE_0;
            return Task.FromResult(value);
        }
    }
}