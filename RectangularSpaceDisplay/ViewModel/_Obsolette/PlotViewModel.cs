using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows.Media;
using System;
using LinkedSpace;

namespace RectangularSpaceDisplay.ViewModel.Old
{
//    public class PlotViewModel<T> : BindableBase
//    {
//        private readonly LinearAxis _xAxis = CreateAxis(AxisPosition.Top);
//        private readonly LinearAxis _yAxis = CreateAxis(AxisPosition.Left);

//        private T[] _previous;

//        public AreaSeries[,] Areas { get; set; }
//        public SquareField<T> Field { get;  }


//        #region BINDINGS

//        public PlotModel Screen { get; } = new PlotModel();

//        private SettingsViewModel _settings;
//        public SettingsViewModel Settings
//        {
//            get => _settings;
//            private set => SetProperty(ref _settings, value);
//        }

//        private PlayViewModel _play;
//        public PlayViewModel Play
//        {
//            get => _play;
//            private set => SetProperty(ref _play, value);
//        }

//        public OxyColorInfo<T> Colors { get; }

//        private bool _isEdit = false;
//        public bool IsEdit
//        {
//            get => _isEdit;
//            set => SetProperty(ref _isEdit, value);
//        }

//        private bool _isReady = false;
//        public bool IsReady
//        {
//            get => _isReady;
//            set => SetProperty(ref _isReady, value);
//        }

//        private bool _isRunning = false;
//        public bool IsRunning
//        {
//            get => _isRunning;
//            set => SetProperty(ref _isRunning, value);
//        }

//        private uint _stepNumber;
//        public uint StepNumber
//        {
//            get => _stepNumber;
//            set => SetProperty(ref _stepNumber, value);
//        }

//        private TimeSpan _time = TimeSpan.Zero;
//        public TimeSpan Time
//        {
//            get => _time;
//            set => SetProperty(ref _time, value);
//        }

//        #endregion

//        #region EVENTS

//        #endregion

//        #region COMMANDS

//        #endregion

//        #region CONSTRUCTORS

//        private PlotViewModel(SquareField<T> field) 
//        {
//            Field = field;

//            Screen.Axes.Add(_xAxis);
//            Screen.Axes.Add(_yAxis);

//            Screen.PlotType = PlotType.Cartesian;
//            Screen.PlotAreaBackground = Colors.BackgroundColor;

//            Screen.EdgeRenderingMode = EdgeRenderingMode.PreferSharpness;
//            Screen.InvalidatePlot(true);
//        }

//        public static PlotViewModel<T> Create(SquareField<T> field)
//        {
//            PlotViewModel<T> result = new PlotViewModel<T>(field);
//            result.Settings = new SettingsViewModel<T>(result);
//            result.Play = new PlayViewModel<T>(result);
//            return result;
//        }

//        #endregion

//        #region METHODS

//        private static LinearAxis CreateAxis(AxisPosition position)
//        {
//            bool isVertically = position == AxisPosition.Left || position == AxisPosition.Right;
//            return new LinearAxis
//            {
//                Position = position,
//                StartPosition = isVertically ? 1 : 0,
//                EndPosition = isVertically ? 0 : 1,
//                AxisDistance = 5,
//                IntervalLength = 50,
//                MinimumMargin = 15
//            };
//        }

//        public void ResetAreas(int width, int height)
//        {
//#if NO_REDRAW

//#else

//            double shift = 0.07;
//            DataPoint first, second, third, fourth;

//            Screen.Series.Clear();
//            Areas = new AreaSeries[width, height];
//            for (int i = 0; i < width; ++i)
//            {
//                for (int j = 0; j < height; ++j)
//                {
//                    first = new DataPoint(i + shift, j + shift);
//                    second = new DataPoint(i + shift, j + 1 - shift);
//                    third = new DataPoint(i + 1 - shift, j + 1 - shift);
//                    fourth = new DataPoint(i + 1 - shift, j + shift);

//                    AreaSeries area = new AreaSeries
//                    {
//                        ItemsSource = new List<DataPoint> { first, second, third, fourth, first },
//                        StrokeThickness = 2,
//                        LineStyle = LineStyle.Solid
//                    };

//                    Areas[i, j] = area;
//                    Screen.Series.Add(area);
//                }
//            }

//            Screen.Annotations.Clear();
//            RectangleAnnotation rectangle = new RectangleAnnotation
//            {
//                MinimumX = 0,
//                MaximumX = width,
//                MinimumY = 0,
//                MaximumY = height,
//                StrokeThickness = 4,
//                Stroke = Colors.FrameColor,
//                Fill = Colors.TransparentColor,
//                Selectable = false
//            };
//            Screen.Annotations.Add(rectangle);

//#endif

//            StepNumber = 0;
//        }

//        public void Redraw(StepResult<T> step)
//        {
//#if NO_REDRAW

//#else

//            int rows = step.Data.GetUpperBound(0) + 1;
//            int columns = step.Data.Length / rows;

//            for (int i = 0; i < rows; ++i)
//            {
//                for (int j = 0; j < columns; ++j)
//                {
//                    Colors.SetColor(Areas[i, j], step.Data[i * columns +j]);
//                }
//            }
//            Screen.InvalidatePlot(true);

//#endif

//            StepNumber = step.Step;
//            Time = step.Time;
//        }

//        public void StartEdit()
//        {
//            _previous = Field.GetData();
//            IsEdit = true;
//            Screen.MouseDown += Screen_MouseDown;
//        }

//        public void ApplyEdit()
//        {
//            Screen.MouseDown -= Screen_MouseDown;
//            IsEdit = false;
//        }

//        public void CancelEdit()
//        {
//            Screen.MouseDown -= Screen_MouseDown;
//            Field.SetData(_previous);
//            Redraw(new StepResult<T>(Field.GetData(), _stepNumber, _time));
//            IsEdit = false;
//        }

//        private void Screen_MouseDown(object sender, OxyMouseDownEventArgs e)
//        {
//            DataPoint point = Axis.InverseTransform(e.Position, _xAxis, _yAxis);
//            int x = (int)Math.Truncate(point.X);
//            int y = (int)Math.Truncate(point.Y);
//            AreaSeries area = Areas[x, y];

//            T data = Colors.ChangeCellData(area);
//            Field.GetData()[(int)Math.Truncate(point.X) * Field.Columns + y] = data;
//            Colors.SetColor(area, data);
//            Screen.InvalidatePlot(true);
//        }

//        #endregion
//    }
}