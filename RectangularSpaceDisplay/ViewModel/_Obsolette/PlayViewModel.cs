using LinkedSpace;
using LinkedSpace.Model.Color;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RectangularSpaceDisplay.ViewModel.Old
{
//    public class PlayViewModel<T> : BindableBase
//    {
//        #region BINDINGS

//        private readonly PlotViewModel<T> _plotVM;

//        private int _delay = 1000;
//        public int Delay
//        {
//            get => _delay;
//            set => SetProperty(ref _delay, value);
//        }

//        #endregion

//        #region EVENTS

//        #endregion

//        #region COMMANDS

//        public DelegateCommand NextCmd { get; }
//        public DelegateCommand RunCmd { get; }

//        #endregion

//        #region CONSTRUCTORS

//        public PlayViewModel(PlotViewModel<T> plotVM)
//        {
//            NextCmd = new DelegateCommand(Cmd_Next);
//            RunCmd = new DelegateCommand(Cmd_Run);

//            _plotVM = plotVM;
//        }

//        #endregion

//        #region METHODS

//        private void Cmd_Next() => _plotVM.Redraw(_plotVM.Field.NextStep());

//        private async void Cmd_Run()
//        {
//#if NO_REDRAW

//            while (true) _ = ConwaysLifeModel.Instance.Field.NextStep();

//#else

//            if (_plotVM.IsRunning)
//            {
//                _plotVM.IsRunning = false;
//                return;
//            }

//            _plotVM.IsRunning = true;
//            while (_plotVM.IsRunning)
//            {
//                Task delay = Task.Delay(_delay);
//                Task<StepResult<T>> calculate = Task.Run(_plotVM.Field.NextStep);

//                await Task.WhenAll(new Task[] { delay, calculate });
//                Dispatcher.CurrentDispatcher.Invoke(() => _plotVM.Redraw(calculate.Result), DispatcherPriority.Background);
//            }

//#endif
//        }

//#endregion
//    }
}