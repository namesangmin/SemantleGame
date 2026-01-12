using System;
using System.Collections.Generic;
using System.Text;

using SemantleGame.Services;
using SemantleGame.Models;

namespace SemantleGame.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        IFileService _fileReader;

        public MainWindowViewModel(IFileService fileReader)
        {
            // 시작 화면
            CurrentViewModel = new StartViewModel(this);

            _fileReader = fileReader;
        }

        public void Navigate(ViewModelBase vm)
        {
            CurrentViewModel = vm;
        }
    }
}
