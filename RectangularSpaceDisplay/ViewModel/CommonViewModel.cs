using LinkedSpace.Model;
using LinkedSpace.Model.Create;
using LinkedSpace.View.Dialog;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CurrentCanvas = RectangularSpaceDisplay.ViewModel.OxyCanvasViewModel; // Заменить на новую отрисовку

namespace RectangularSpaceDisplay.ViewModel
{
    public class CommonViewModel : BindableBase
    {
        #region BINDINGS

        private IDialogHostOwner _owner;
        public IDialogHostOwner Owner => _owner;

        private readonly SimulationsContainer _container;
        public SimulationsContainer Container => _container;

        private string _selectedId;
        public string SelectedId
        {
            get => _selectedId;
            set => SetProperty(ref _selectedId, value);
        }

        private Simulation _simulation;
        public Simulation Simulation
        {
            get => _simulation;
            set => SetProperty(ref _simulation, value);
        }

        private CurrentCanvas _canvas;
        public CurrentCanvas Canvas => _canvas;

        private readonly StatusViewModel _status = new StatusViewModel();
        public StatusViewModel Status => _status;

        #endregion

        #region EVENTS

        #endregion

        #region COMMANDS

        public DelegateCommand<SimulationWindow> FieldCmd { get; }
        public DelegateCommand RunCmd { get; }
        public DelegateCommand StepCmd { get; }
        public DelegateCommand EditCmd { get; }
        public DelegateCommand ApplyEditCmd { get; }
        public DelegateCommand CancelEditCmd { get; }
        public DelegateCommand SaveCmd { get; }

        #endregion

        #region CONSTRUCTORS

        private CommonViewModel()
        {
            _container = new SimulationsContainer();

            FieldCmd = new DelegateCommand<SimulationWindow>(Cmd_Field);

            RunCmd = new DelegateCommand(Cmd_Run);
            StepCmd = new DelegateCommand(Cmd_Step);

            EditCmd = new DelegateCommand(Cmd_Edit);
            ApplyEditCmd = new DelegateCommand(Cmd_ApplyEdit);
            CancelEditCmd = new DelegateCommand(Cmd_CancelEdit);

            SaveCmd = new DelegateCommand(Cmd_Save);
        }

        public static CommonViewModel Create()
        {
            CommonViewModel result = new CommonViewModel();
            result._canvas = new CurrentCanvas(result);
            result._canvas.CreatePlotArea();
            return result;
        }

        #endregion

        #region METHODS

        private async void Cmd_Field(SimulationWindow window)
        {
            if (_owner is null) _owner = window;

            Simulation = _container[_selectedId];

            await Simulation.CreationRequest(_owner);
            _simulation.CreateSpace();

            RectangularFieldCreationArgs args = (RectangularFieldCreationArgs)Simulation.Creator.Args;

            if(_canvas.IsAxisInversed) _canvas.ResetCells(args.Columns, args.Rows);
            else _canvas.ResetCells(args.Rows, args.Columns);

            _canvas.Redraw(_canvas.Current());

            Status.IsReady = true;
        }

        private async void Cmd_Run()
        {
            if (_status.IsRunning)
            {
                _status.IsRunning = false;
                return;
            }

            _status.IsRunning = true;
            while (_status.IsRunning)
            {
                Task delay = Task.Delay(_status.Delay);
                var calculate = Task.Run(_canvas.Next);

                await Task.WhenAll(new Task[] { delay, calculate });
                Dispatcher.CurrentDispatcher.Invoke(() => _canvas.Redraw(calculate.Result), DispatcherPriority.Background);
            }
        }

        private void Cmd_Step() => _canvas.Redraw(_canvas.Next());

        private void Cmd_Edit() => _canvas.StartEdit();

        private void Cmd_ApplyEdit() => _canvas.ApplyEdit();

        private void Cmd_CancelEdit() => _canvas.CancelEdit();

        public void Cmd_Save()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Life Game Field File (*.lgf) | *.lgf" };
                if (sfd.ShowDialog().Value)
                {
                    _simulation.Save(new System.IO.FileInfo(sfd.FileName));
                    MessageBox.Show("Файл сохранён");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
