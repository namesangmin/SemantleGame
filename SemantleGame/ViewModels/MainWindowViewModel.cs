using System;
using System.Collections.Generic;
using System.Text;

using SemantleGame.Services;
using SemantleGame.Models;
using System.Windows.Shapes;

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

        //IFileService _fileReader;
        Dictionary<string, WordModel> dic;
        public MainWindowViewModel()
        {
            WordVectorService vectorService = new WordVectorService();
            AnswerWordsService answerService = new AnswerWordsService();

            Dictionary<string, WordModel> wordDic = vectorService.getWordVectors();
            string? ans = answerService.getAnswerWord();

            // 시작 화면
            CurrentViewModel = new StartViewModel(this);


            //_fileReader = fileReader;


        }

        public void Navigate(ViewModelBase vm)
        {
            CurrentViewModel = vm;
        }
    }
}
