using LinkedSpace.Model.Create;
using LinkedSpace.View.Dialog;
using System;
using System.Windows.Controls;

namespace LinkedSpace.View.BaseCreator
{
    public partial class BaseCreatorControl : UserControl, IDialogHostControl<SpaceCreator>
    {
        public event EventHandler<GenericArgs<SpaceCreator>> OnDialogResult;

        public new BaseCreatorViewModel DataContext
        {
            get => (BaseCreatorViewModel)base.DataContext;
            set
            {
                base.DataContext = value;
                DataContext.OnClosing += DataContext_OnClosing;
            }
        }

        private void DataContext_OnClosing(object sender, EventArgs e)
        {
            DataContext.OnClosing -= DataContext_OnClosing;
            OnDialogResult.Invoke(this, new GenericArgs<SpaceCreator>(DataContext.Creator));
        }
    }
}