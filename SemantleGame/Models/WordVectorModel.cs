using System;
using System.Collections.Generic;
using System.Text;

using SemantleGame.Services;
using SemantleGame.ViewModels;

namespace SemantleGame.Models
{
    public class WordVectorModel : ViewModelBase
    {
        public string? Word { get; set; }       // 단어
        public float[]? Vector { get; set; }   // 벡터값 -> 소수점

        public WordVectorModel(string word, float[] vector)
        {
            Word = word;
            Vector = vector;
        }
    }
}
