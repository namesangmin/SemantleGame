using System;
using System.Collections.Generic;
using System.Text;

using SemantleGame.Services;
using SemantleGame.ViewModels;

namespace SemantleGame.Models
{
    public class WordModel : ViewModelBase
    {
        private string  _name;

        public string Name
        {
            get => _name;
        }

        private float[] _vectors;

        public float[] Vectors
        {
            get => _vectors;
        }

        public WordModel(string stringValue)
        {
            
        }
    }
}
