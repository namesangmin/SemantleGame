using SemantleGame.Commands;
using SemantleGame.Models;
using SemantleGame.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace SemantleGame.ViewModels
{
    public class StartViewModel : ViewModelBase
    {

        private readonly MainWindowViewModel _mainViewMode;
        public ObservableCollection<UserLogModel> InputHistory { get; set; }
        private Dictionary<string, WordModel> _WordDic;
        private Dictionary<string, int> _RankingMap;
        private string _Ans = "";

        public ICommand SubmitCommand
        {
            get;
        }

        public ICommand AnswerCommand
        {
            get;
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

            // 전체 파일 데이터 + 정답 데이터 불러오기 객체 생성
            WordVectorService vectorService = new WordVectorService();
            AnswerWordsService answerService = new AnswerWordsService();

            // 전체 데이터 로드 + 정답 데이터 선택됨
            _WordDic = vectorService.getWordVectors();
            _Ans = answerService.getAnswerWord();
            // 정답 데이터와 탑 1000등 등수를 매김
            PreCalculateRanks();

            SubmitCommand = new RelayCommand(_=>SubmitButtonClicked());
            AnswerCommand = new RelayCommand(_=>AnswerButtonClicked());

            // 사용자 입력 로그
            InputHistory = new ObservableCollection<UserLogModel>();

        }
        private void PreCalculateRanks()
        {
            _RankingMap = new Dictionary<string, int>();
            if (_Ans == null || !_WordDic.ContainsKey(_Ans)) return;

            // 올바른 제네릭 타입 사용: Tuple<string, float> 또는 ValueTuple<string, float>
            WordModel targetModel = _WordDic[_Ans];
            var tm = new List<(string word, float score)>();
            foreach(var item in _WordDic)
            {
                float sim = CalculateCos(targetModel, item.Value);
                tm.Add((item.Key, sim));
            }

            var sortedList = tm.OrderByDescending(x => x.score).ToList();
            sortedList = sortedList.Slice(0, 1000);
            for(int i=0; i< sortedList.Count; i++)
            {
                _RankingMap[sortedList[i].word] = i + 1;
            }
        }
        private float CalculateCos(WordModel Input, WordModel Ans)
        {
            if (Input?.Vector == null || Ans?.Vector == null)
                return 0f;

            float[] inputVec = Input.Vector;
            float[] ansVec = Ans.Vector;
            float dot = 0f, normA = 0f, normB = 0f;
            for (int i = 0; i < inputVec.Length; i++)
            {
                dot += inputVec[i] * ansVec[i];
                normA += inputVec[i] * inputVec[i];
                normB += ansVec[i] * ansVec[i];
            }
            return dot/((float)(Math.Sqrt(normA) * Math.Sqrt(normB)));
        }

        public void SubmitButtonClicked()
        {
            int cnt = InputHistory.Count+1;
            int rank;

            // 객체를 생성하기 전에 확인이 필요함 =>
            // 1. 예외인지?
            if (!_WordDic.ContainsKey(InputWord))
            {
                // 위에 레이블로 떠야 함 -> 임시
                MessageBox.Show("사전에 없는 단어입니다.");
                return;
            }

            // 2. 이미 입력한 단어?
            if (InputHistory.Any(x => x.UserInputWord == InputWord))
            {
                MessageBox.Show("이미 입력한 단어입니다.");
                return;
            }
            // 정답
            if(InputWord == _Ans)
            {
                MessageBox.Show("정답입니다! 게임 승리!");
            }

            // 다 통과하면 코사인 유사도 계산
            float sim = CalculateCos(_WordDic[InputWord], _WordDic[_Ans]);
            if (_RankingMap.ContainsKey(InputWord)) rank = _RankingMap[InputWord];
            else rank = 1000;

            UserLogModel user = new UserLogModel(cnt, InputWord, sim, rank);
            InputHistory.Add(user);
            InputWord = "";
        }

        public void AnswerButtonClicked()
        {
            MessageBox.Show($"정답 : {_Ans}");
        }
    }
}
