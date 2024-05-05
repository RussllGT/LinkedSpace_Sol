using LinkedSpace.Model.Color;
using LinkedSpace.Model.Create;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace RectangularSpaceDisplay.ViewModel
{
    public class OxyCanvasViewModel : CanvasViewModel<OxyColor>
    {
        private static readonly OxyColor _transparent = OxyColor.FromArgb(0, 0, 0, 0);
        private static readonly OxyColor _black = OxyColor.FromRgb(0, 0, 0);
        private static readonly OxyColor _gray = OxyColor.FromRgb(200, 200, 200);

        private readonly LinearAxis _xAxis = CreateAxis(AxisPosition.Top);
        private readonly LinearAxis _yAxis = CreateAxis(AxisPosition.Left);
        
        public AreaSeries[] Areas { get; set; }

        #region BINDINGS

        public PlotModel Screen { get; } = new PlotModel();

        #endregion

        #region EVENTS

        #endregion

        #region COMMANDS

        #endregion

        #region CONSTRUCTORS

        public OxyCanvasViewModel(CommonViewModel vm) : base(vm, false) 
        { 
            TransparentColor = _transparent;
            BackgroundColor = _gray;
            FrameColor = _black;
            LinesColor = _gray;
        }

        #endregion

        #region METHODS

        public override StepResult<OxyColor> Next() => _vm.Simulation.Next(ConvertColor);
        public override StepResult<OxyColor> Current() => _vm.Simulation.Current(ConvertColor);
        public override OxyColor ConvertColor(Argb argb) => OxyColor.FromArgb(argb.Alpha, argb.Red, argb.Green, argb.Blue);

        public override void CreatePlotArea()
        {
            Screen.Axes.Add(_xAxis);
            Screen.Axes.Add(_yAxis);

            Screen.PlotType = PlotType.Cartesian;
            Screen.PlotAreaBackground = BackgroundColor;

            Screen.EdgeRenderingMode = EdgeRenderingMode.PreferSharpness;
            Screen.InvalidatePlot(true);
        }

        public override void ResetCells(int height, int width)
        {
            double shift = 0.07;
            DataPoint first, second, third, fourth;

            Screen.Series.Clear();
            Areas = new AreaSeries[width * height];
            int k = 0;
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    first = new DataPoint(i + shift, j + shift);
                    second = new DataPoint(i + shift, j + 1 - shift);
                    third = new DataPoint(i + 1 - shift, j + 1 - shift);
                    fourth = new DataPoint(i + 1 - shift, j + shift);

                    AreaSeries area = new AreaSeries
                    {
                        ItemsSource = new List<DataPoint> { first, second, third, fourth, first },
                        StrokeThickness = 2,
                        LineStyle = LineStyle.Solid
                    };

                    Areas[k++] = area;
                    Screen.Series.Add(area);
                }
            }

            Screen.Annotations.Clear();
            RectangleAnnotation rectangle = new RectangleAnnotation
            {
                MinimumX = 0,
                MaximumX = width,
                MinimumY = 0,
                MaximumY = height,
                StrokeThickness = 4,
                Stroke = FrameColor,
                Fill = TransparentColor,
                Selectable = false
            };
            Screen.Annotations.Add(rectangle);

            _vm.Status.StepNumber = 0;
        }

        public override void Redraw(StepResult<OxyColor> step)
        {
            for (int i = 0; i < Areas.Length; i++) SetColor(Areas[i], step.Colors[i]);
            Screen.InvalidatePlot(true);
            _vm.Status.StepNumber = step.Number;
        }

        private async void Screen_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            DataPoint point = Axis.InverseTransform(e.Position, _xAxis, _yAxis);
            int x = (int)Math.Truncate(point.X);
            int y = (int)Math.Truncate(point.Y);

            RectangularFieldCreationArgs args = (RectangularFieldCreationArgs)_vm.Simulation.Creator.Args;
            int index = IsAxisInversed ? x * args.Rows + y : y * args.Columns + x;
            AreaSeries area = Areas[index];

            OxyColor color = await _vm.Simulation.ChangeCell(_vm.Owner, index, ConvertColor);
            SetColor(area, color);
            Screen.InvalidatePlot(true);
        }

        public override void StartEdit()
        {
            _vm.Status.IsEdit = true;
            Screen.MouseDown += Screen_MouseDown;
        }

        public override void ApplyEdit()
        {
            Screen.MouseDown -= Screen_MouseDown;
            _vm.Simulation.Commit();
            _vm.Status.IsEdit = false;
        }

        public override void CancelEdit()
        {
            Screen.MouseDown -= Screen_MouseDown;
            _vm.Simulation.RollBack();
            Redraw(_vm.Simulation.Current(ConvertColor));
            _vm.Status.IsEdit = false;
        }

        #endregion

        private static LinearAxis CreateAxis(AxisPosition position)
        {
            bool isVertically = position == AxisPosition.Left || position == AxisPosition.Right;
            return new LinearAxis
            {
                Position = position,
                StartPosition = isVertically ? 1 : 0,
                EndPosition = isVertically ? 0 : 1,
                AxisDistance = 5,
                IntervalLength = 50,
                MinimumMargin = 15
            };
        }

        private static void SetColor(AreaSeries area, OxyColor color)
        {
            area.Color = color;
            area.Fill = color;
        }
    }
}
