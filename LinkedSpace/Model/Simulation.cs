using LinkedSpace.Model.Color;
using LinkedSpace.Model.Create;
using LinkedSpace.Model.Field;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedSpace.Model
{
    public abstract class Simulation
    {
        protected Argb[] _colors;
        protected Space _space;

        public SpaceCreator Creator { get; protected set; }

        protected Simulation() { }

        public StepResult<TColor> Next<TColor>(Func<Argb, TColor> colorFunction)
        {
            _space.Next(_colors);
            return Current(colorFunction);
        }

        public StepResult<TColor> Current<TColor>(Func<Argb, TColor> colorFunction) => new StepResult<TColor>(_space.Step, _colors.Select(colorFunction).ToArray());

        public abstract Task CreationRequest(object sender);
        public abstract void CreateSpace();
    }
}