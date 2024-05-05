using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;

namespace LinkedSpace.View.Dialog
{
    public static partial class Extensions
    {
        public static async Task ShowDialogHost(this IDialogHostOwner owner, IDialogHostControl control)
        {
            control.OnDialogResult += Control_OnDialogResult;
            await DialogHost.Show(control, owner.HostDialogIdentifier);

            void Control_OnDialogResult(object sender, EventArgs e)
            {
                control.OnDialogResult -= Control_OnDialogResult;
                DialogHost.Close(owner.HostDialogIdentifier);
            }
        }

        public static async Task<T> ShowDialogHost<T>(this IDialogHostOwner owner, IDialogHostControl<T> control)
        {
            T result = default;
            control.OnDialogResult += Control_OnDialogResult;
            await DialogHost.Show(control, owner.HostDialogIdentifier);
            return result;

            void Control_OnDialogResult(object sender, GenericArgs<T> e)
            {
                control.OnDialogResult -= Control_OnDialogResult;
                result = e.Result;
                DialogHost.Close(owner.HostDialogIdentifier);
            }
        }
    }
}