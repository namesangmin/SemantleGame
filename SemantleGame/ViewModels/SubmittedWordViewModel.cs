using System;
using System.Collections.Generic;
using System.Text;

namespace SemantleGame.ViewModels
{
    public class SubmittedWordViewModel : ViewModelBase
    {
        private string _word;

        public string Word
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged();
            }
        }

        private int _index;

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                OnPropertyChanged();
            }



        }

        private float _similarity;

        public float Similarity
        {
            get => _similarity;
            set
            {
                _similarity = value;
                OnPropertyChanged();
            }
        }

        private int _similarityRank;

        public int SimilarityRank
        {
            get => _similarityRank;
            set
            {
                _similarityRank = value;
                OnPropertyChanged();
            }
        }

        public SubmittedWordViewModel(int index, string word, float similarity, int similarityRank)
        {
            _index = index;
            _word = word;
            _similarity = similarity;
            _similarityRank = similarityRank;
        }
    }
}