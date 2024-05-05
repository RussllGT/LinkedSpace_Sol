using Prism.Commands;
using Prism.Mvvm;
using System;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using LinkedSpace;

namespace RectangularSpaceDisplay.ViewModel.Old
{
    //public class SettingsViewModel<T> : BindableBase
    //{
    //    private const int MINIMUM_SIZE = 4;

    //    private const string INCORRECT_SIZE_MESSAGE = "Некорректный размер поля: Стороны должны быть не менее ";
    //    private const string OF_CELLS_MESSAGE = " ячеек";

    //    private readonly PlotViewModel<T> _plotVM;

    //    #region BINDINGS

    //    public bool[,] Data { get; private set; }

    //    private int _width = 60;
    //    public int Width
    //    {
    //        get => _width;
    //        set => SetProperty(ref _width, value);
    //    }

    //    private int _height = 40;
    //    public int Height
    //    {
    //        get => _height;
    //        set => SetProperty(ref _height, value);
    //    }

    //    #endregion

    //    #region EVENTS

    //    #endregion

    //    #region COMMANDS

    //    public DelegateCommand EmptyCmd { get; }
    //    public DelegateCommand RandomCmd { get; }
    //    public DelegateCommand OpenCmd { get; }
    //    public DelegateCommand EditCmd { get; }
    //    public DelegateCommand ApplyCmd { get; }
    //    public DelegateCommand CancelCmd { get; }
    //    public DelegateCommand SaveCmd { get; }

    //    #endregion

    //    #region CONSTRUCTORS

    //    public SettingsViewModel(PlotViewModel<T> plotVM)
    //    {
    //        EmptyCmd = new DelegateCommand(Cmd_Empty);
    //        RandomCmd = new DelegateCommand(Cmd_Random);
    //        OpenCmd = new DelegateCommand(Cmd_Open);
    //        EditCmd = new DelegateCommand(Cmd_Edit);
    //        ApplyCmd = new DelegateCommand(Cmd_Apply);
    //        CancelCmd = new DelegateCommand(Cmd_Cancel);
    //        SaveCmd = new DelegateCommand(Cmd_Save);

    //        _plotVM = plotVM;
    //    }

    //    #endregion

    //    #region METHODS

    //    private void Cmd_Empty() => CreateField(false);
    //    private void Cmd_Random() => CreateField(true);
    //    private void Cmd_Open()
    //    {
    //        try
    //        {
    //            OpenFileDialog ofd = new OpenFileDialog { Filter = "Life Game Field File (*.lgf) | *.lgf" };
    //            if (ofd.ShowDialog().Value && File.Exists(ofd.FileName))
    //            {
    //                ConwaysLifeModel.ConstructInstance(ofd.FileName);
    //                Width = ConwaysLifeModel.Instance.Field.Rows;
    //                Height = ConwaysLifeModel.Instance.Field.Columns;

    //                NewField();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.ToString());
    //        }
    //    }
    //    private void Cmd_Edit() => _plotVM.StartEdit();
    //    private void Cmd_Apply() => _plotVM.ApplyEdit();
    //    private void Cmd_Cancel() => _plotVM.CancelEdit();
    //    private void Cmd_Save()
    //    {
    //        try
    //        {
    //            SaveFileDialog sfd = new SaveFileDialog { Filter = "Life Game Field File (*.lgf) | *.lgf" };
    //            if (sfd.ShowDialog().Value)
    //            {
    //                ConwaysLifeModel.Instance.Save(sfd.FileName);
    //                MessageBox.Show("Файл сохранён");
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            MessageBox.Show(ex.ToString());
    //        }
    //    }


    //    private void CreateField(bool isRandom) 
    //    {
    //        if (_width < 4 || _height < 4) throw new ArgumentException($"{INCORRECT_SIZE_MESSAGE}{MINIMUM_SIZE}{OF_CELLS_MESSAGE}");
    //        ConwaysLifeModel.ConstructInstance(_width, _height);
    //        if (isRandom) ConwaysLifeModel.Instance.SetRandom();

    //        NewField();
    //    }

    //    private void NewField()
    //    {
    //        _plotVM.ResetAreas(_width, _height);
    //        _plotVM.Redraw(new StepResult<T>(_plotVM.Field.GetData(), 0, TimeSpan.Zero));
    //        _plotVM.IsReady = true;
    //    }

    //    #endregion
    //}
}