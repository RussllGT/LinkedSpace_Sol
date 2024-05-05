using RectangularSpaceDisplay.ViewModel;
using LinkedSpace.View.Dialog;
using MahApps.Metro.Controls;

namespace RectangularSpaceDisplay
{
    public partial class SimulationWindow : MetroWindow, IDialogHostOwner
    {
        public string HostDialogIdentifier => DataContext.HostDialogIdentifier;

        public new MainViewModel DataContext
        {
            get => (MainViewModel)base.DataContext;
            set => base.DataContext = value;
        }

        public SimulationWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}