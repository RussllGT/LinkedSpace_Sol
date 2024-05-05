using LinkedSpace.Model.Color;
using System.Collections.Generic;

namespace LifeGame.Model
{
    public class ConwaysLifeColors : ColorConverter<byte>
    {
        private const string ACTIVE = "Active";
        private const string IDLE = "Idle";

        public ConwaysLifeColors()
        {
            _colors = new Dictionary<string, Argb>
            {
                { "Active", Argb.RED },
                { "Idle", Argb.WHITE }
            };
        }

        public override Argb Convert(byte data) => data == 0 ? _colors[IDLE] : _colors[ACTIVE];
    }
}