using System;

namespace LinkedSpace.View.Dialog
{
    public interface IDialogHostControl<T>
    {
        event EventHandler<GenericArgs<T>> OnDialogResult;
    }
}