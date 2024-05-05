using LinkedSpace.View.BaseCreator;
using System;
using System.Windows.Controls;

namespace LifeGame.Controls.Creator
{
    public partial class LifeCreatorControl : BaseCreatorControl
    {
        public LifeCreatorControl()
        {
            InitializeComponent();
            DataContext = new LifeCreatorViewModel();
        }
    }
}
