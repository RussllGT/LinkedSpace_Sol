using System;

namespace LinkedSpace.View.Dialog
{
    public interface IDialogHostControl
    {
        event EventHandler OnDialogResult;
    }
}
