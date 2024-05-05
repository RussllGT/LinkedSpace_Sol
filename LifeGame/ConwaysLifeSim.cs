using LinkedSpace.Model;
using LinkedSpace.View.Dialog;
using System.Threading.Tasks;
using LifeGame.Model.Creators;
using LifeGame.Model.Field;
using LifeGame.Controls.Creator;

namespace LifeGame
{
    public class ConwaysLifeSim : Simulation
    {
        public new ConwaysLifeCreator Creator
        {
            get => (ConwaysLifeCreator)base.Creator;
            private set => base.Creator = value;
        }

        public override void CreateSpace()
        {
            _space = new ConwaysLifeField(Creator, out _colors);
        }

        public override async Task CreationRequest(object sender)
        {
            IDialogHostOwner owner = (IDialogHostOwner)sender;
            Creator = (ConwaysLifeCreator)await owner.ShowDialogHost(new LifeCreatorControl());
        }
    }
}