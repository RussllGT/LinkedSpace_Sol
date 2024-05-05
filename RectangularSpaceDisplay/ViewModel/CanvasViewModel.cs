using LinkedSpace.Model.Color;
using Prism.Mvvm;

namespace RectangularSpaceDisplay.ViewModel
{
    public abstract class CanvasViewModel<TColor> : BindableBase
    {
        protected readonly CommonViewModel _vm;

        private readonly bool _isAxisInversed;
        public bool IsAxisInversed => _isAxisInversed;

        #region BINDINGS

        private TColor _transparentColor;
        public TColor TransparentColor
        {
            get => _transparentColor;
            set => SetProperty(ref _transparentColor, value);
        }

        private TColor _backgroundColor;
        public TColor BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        private TColor _frameColor;
        public TColor FrameColor
        {
            get => _frameColor;
            set => SetProperty(ref _frameColor, value);
        }

        private TColor _linesColor;
        public TColor LinesColor
        {
            get => _linesColor;
            set => SetProperty(ref _linesColor, value);
        }

        #endregion

        #region EVENTS

        #endregion

        #region COMMANDS

        #endregion

        #region CONSTRUCTORS

        protected CanvasViewModel(CommonViewModel vm, bool isAxisInversed)
        {
            _vm = vm;
            _isAxisInversed = isAxisInversed;
        }

        #endregion

        #region METHODS

        public abstract StepResult<TColor> Next();
        public abstract StepResult<TColor> Current();
        public abstract TColor ConvertColor(Argb color);

        public abstract void CreatePlotArea();
        public abstract void ResetCells(int height, int width);
        public abstract void Redraw(StepResult<TColor> step);

        public abstract void StartEdit();
        public abstract void ApplyEdit();
        public abstract void CancelEdit();

        #endregion
    }
}
