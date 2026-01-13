using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using SemantleGame.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace SemantleGame.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private ObservableCollection<SubmittedWordViewModel> _submittedWords = new ObservableCollection<SubmittedWordViewModel>()
        {
            new SubmittedWordViewModel(1, "test", 0.0f, 500),
        };

        public ObservableCollection<SubmittedWordViewModel> SubmittedWords
        {
            get { return _submittedWords; } 
        }

        private readonly MainWindowViewModel _mainViewMode;

        public ICommand SubmitCommand
        {
            get;
            set;
        }

        private string _inputWord;

        public string InputWord
        {
            get { return _inputWord; }
            set
            {
                _inputWord = value;
                OnPropertyChanged();
            }
        }
        
        public StartViewModel(MainWindowViewModel mainViewMode)
        {
            _mainViewMode = mainViewMode;

            SubmitCommand = new RelayCommand(_=>SubmitButtonClicked());
        }

        public void SubmitButtonClicked()
        {

        }
    }
}
