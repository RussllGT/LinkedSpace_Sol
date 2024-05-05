using LinkedSpace.Model.Color;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
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
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
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
