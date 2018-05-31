using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RabbitTank
{
    public class File
    {
        private IEnumerable<string> _Files;

        public IEnumerable<string> Files => _Files;


        public bool FilesExists(string path, string searchString)
        {
            _Files = Directory.EnumerateFiles(path, searchString, SearchOption.AllDirectories);
            bool result = _Files.Count() > 0 ? true : false;
            return result;
        }
    }
}
