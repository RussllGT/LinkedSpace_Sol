using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace RectangularSpaceDisplay.ViewModel
{
    public class MainViewModel : BindableBase
    {
        #region BINDINGS

        private readonly string _hostDialogIdentifier = Guid.NewGuid().ToString();
        public string HostDialogIdentifier => _hostDialogIdentifier;

        private readonly List<UserControl> _contetntList = new List<UserControl>
        {
            new CommonView()
        };

        private UserControl _visibleContent;
        public UserControl VisibleContent
        {
            get => _visibleContent;
            set => SetProperty(ref _visibleContent, value);
        }

        #endregion

        #region EVENTS

        #endregion

        #region COMMANDS

        #endregion

        #region CONSTRUCTORS

        public MainViewModel()
        {
            VisibleContent = _contetntList[0];
        }

        #endregion

        #region METHODS

        #endregion
    }
}