using LinkedSpace;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using Prism.Mvvm;

namespace RectangularSpaceDisplay.ViewModel.Old
{
    //public abstract class OxyColorInfo<TData> : BindableBase, IColorInfo<OxyColor, TData>
    //{
    //    private static readonly OxyColor _transparent = OxyColor.FromArgb(0, 0, 0, 0);
    //    private static readonly OxyColor _black = OxyColor.FromRgb(0, 0, 0);
    //    private static readonly OxyColor _gray = OxyColor.FromRgb(200, 200, 200);

    //    #region BINDINGS

    //    private OxyColor _transparentColor = _transparent;
    //    public OxyColor TransparentColor
    //    {
    //        get => _transparentColor;
    //        set => SetProperty(ref _transparentColor, value);
    //    }

    //    private OxyColor _backgroundColor = _gray;
    //    public OxyColor BackgroundColor
    //    {
    //        get => _backgroundColor;
    //        set => SetProperty(ref _backgroundColor, value);
    //    }

    //    private OxyColor _frameColor = _black;
    //    public OxyColor FrameColor
    //    {
    //        get => _frameColor;
    //        set => SetProperty(ref _frameColor, value);
    //    }

    //    private OxyColor _linesColor = _gray;
    //    public OxyColor LinesColor
    //    {
    //        get => _linesColor;
    //        set => SetProperty(ref _linesColor, value);
    //    }

    //    #endregion

    //    #region EVENTS

    //    #endregion

    //    #region COMMANDS

    //    #endregion

    //    #region CONSTRUCTORS

    //    #endregion

    //    #region METHODS

    //    public abstract OxyColor CalculateCellColor(TData data);

    //    public abstract TData ChangeCellData(AreaSeries area);

    //    public void SetColor(AreaSeries area, TData data)
    //    {
    //        area.Color = CalculateCellColor(data);
    //        area.Fill = CalculateCellColor(data);
    //    }

    //    #endregion
    //}
}