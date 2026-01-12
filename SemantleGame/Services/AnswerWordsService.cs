using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SemantleGame.Services
{
    internal class AnswerWordsService
    {
        //private StreamReader? _reader;
        //private int _totalLineCount;

        public string? getAnswerWord()
        {
            string path = "word_preprocessing.txt";

            string[] wordLines = File.ReadAllLines(path);
            if (wordLines.Length == 0) return null;

            Random rand = new Random();
            int randomInt = rand.Next(0, wordLines.Length);

            return wordLines[randomInt];
        }
    }
}
