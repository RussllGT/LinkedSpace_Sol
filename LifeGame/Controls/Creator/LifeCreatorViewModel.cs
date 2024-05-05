using LifeGame.Model.Creators;
using LinkedSpace.Model.Create;
using LinkedSpace.View.BaseCreator;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.IO;
using System.Windows;

namespace LifeGame.Controls.Creator
{
    public class LifeCreatorViewModel : BaseCreatorViewModel
    {
        #region BINDINGS

        private int _width = 60;
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private int _height = 40;
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private string _path = string.Empty;
        public string Path
        {
            get => _path; 
            set => SetProperty(ref _path, value);
        }

        #endregion

        #region EVENTS

        #endregion

        #region COMMANDS

        public DelegateCommand EmptyCmd { get; }
        public DelegateCommand RandomCmd { get; }
        public DelegateCommand OpenCmd { get; }
        public DelegateCommand CancelCmd { get; }

        #endregion

        #region CONSTRUCTORS

        public LifeCreatorViewModel()
        {
            EmptyCmd = new DelegateCommand(Cmd_Empty);
            RandomCmd = new DelegateCommand(Cmd_Random);
            OpenCmd = new DelegateCommand(Cmd_Open);
            CancelCmd = new DelegateCommand(Close);
        }

        #endregion

        #region METHODS

        private void Cmd_Empty()
        {
            Creator = new EmptyField();
            Creator.Args = new RectangularFieldCreationArgs
            {
                Rows = _height,
                Columns = _width
            };
            Close();
        }

        private void Cmd_Random()
        {
            Creator = new RandomField();
            Creator.Args = new RectangularFieldCreationArgs
            {
                Rows = _height,
                Columns = _width
            };
            Close();
        }

        private void Cmd_Open()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog { Filter = "Life Game Field File (*.lgf) | *.lgf" };
                if (ofd.ShowDialog().Value && File.Exists(ofd.FileName))
                {
                    Creator = new FieldFromFile();
                    Creator.Args = new RectangularFieldCreationArgs
                    {
                        File = new FileInfo(ofd.FileName)
                    };
                    Close();
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