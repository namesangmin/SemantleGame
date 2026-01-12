using SemantleGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SemantleGame.Services
{
    internal class WordVectorService
    {
        private StreamReader? _reader;
        public Dictionary<string,WordModel> getWordVectors ()
        {
            var result = new Dictionary<string, WordModel>();
            string path = "full_data_100d.txt";

            if (!File.Exists(path))
            {
                return result;
            }
            _reader = new StreamReader(path);

            string? line;
            while((line = _reader.ReadLine()) != null){
                string[] totalString = line.Split('|');
                if (totalString.Length < 2) continue;

                string word = totalString[0];
                string[] vectorString= totalString[1].Split(',');
                float[] vec = Array.ConvertAll(vectorString, float.Parse);

                WordModel model = new WordModel
                {
                    Word = word,
                    Vector = vec
                };

                if (!result.ContainsKey(word))
                {
                    result.Add(word, model);
                }
            }
            _reader.Close();
            return result;
        }
    }
}
