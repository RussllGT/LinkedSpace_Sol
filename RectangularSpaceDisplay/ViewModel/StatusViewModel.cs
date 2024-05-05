using Prism.Mvvm;
using System;

namespace RectangularSpaceDisplay.ViewModel
{
    public class StatusViewModel :BindableBase
    {
        #region BINDINGS

        //private bool _isSimulationSelected = false;
        //public bool IsSimulationSelected
        //{
        //    get => _isSimulationSelected;
        //    set => SetProperty(ref _isSimulationSelected, value);
        //}

        private bool _isEdit = false;
        public bool IsEdit
        {
            get => _isEdit;
            set => SetProperty(ref _isEdit, value);
        }

        private bool _isReady = false;
        public bool IsReady
        {
            get => _isReady;
            set => SetProperty(ref _isReady, value);
        }

        private bool _isRunning = false;
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        private uint _stepNumber;
        public uint StepNumber
        {
            get => _stepNumber;
            set => SetProperty(ref _stepNumber, value);
        }

        private TimeSpan _time = TimeSpan.Zero;
        public TimeSpan Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        private int _delay = 400;
        public int Delay
        {
            get => _delay;
            set => SetProperty(ref _delay, value);
        }

        #endregion

        #region EVENTS

        #endregion

        #region COMMANDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        #endregion
    }
}