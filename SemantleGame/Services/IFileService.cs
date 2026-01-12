using System;
using System.Collections.Generic;
using System.Text;

namespace SemantleGame.Services
{
    public interface IFileService
    {
        public bool Open(string path);

        public void close();

        public string? ReadLine();
    }
}
