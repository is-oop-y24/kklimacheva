using System.Collections.Generic;
using System.Security.Cryptography;

namespace IsuExtra
{
    public class ElectiveCourse
    {
        private List<Stream> _streams = new List<Stream>();
        private char _megafaculty;

        public ElectiveCourse(string name, char megafaculty)
        {
            Name = name;
            _megafaculty = megafaculty;
        }

        public string Name { get; }

        public void AddStream(Stream stream)
        {
            _streams.Add(stream);
        }

        public char Megafaculty()
        {
            return _megafaculty;
        }

        public IReadOnlyList<Stream> Streams()
        {
            return _streams;
        }
    }
}