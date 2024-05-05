using LinkedSpace.Model.Create;
using Prism.Mvvm;
using System;

namespace LinkedSpace.View.BaseCreator
{
    public class BaseCreatorViewModel : BindableBase
    {
        #region BINDINGS

        public SpaceCreator Creator { get; protected set; }

        #endregion

        #region EVENTS

        public event EventHandler OnClosing;

        #endregion

        #region COMMANDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        protected void Close() => OnClosing?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}