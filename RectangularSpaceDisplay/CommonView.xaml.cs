using RectangularSpaceDisplay.ViewModel;
using System.Windows.Controls;

namespace RectangularSpaceDisplay
{
    public partial class CommonView : UserControl
    {
        public new CommonViewModel DataContext
        {
            get => (CommonViewModel)base.DataContext;
            set => base.DataContext = value;
        }
        public CommonView()
        {
            InitializeComponent();
            DataContext = CommonViewModel.Create();
        }
    }
}