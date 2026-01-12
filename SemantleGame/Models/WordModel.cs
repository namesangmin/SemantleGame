using System;
using System.Collections.Generic;
using System.Text;

using SemantleGame.Services;
using SemantleGame.ViewModels;

namespace SemantleGame.Models
{
    public class WordModel : ViewModelBase
    {
        public string? Word { get; set; }       // 단어
        public float[]? Vector { get; set; }   // 벡터값

    }
}