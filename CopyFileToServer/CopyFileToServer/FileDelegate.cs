using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopyFileToServer
{
    public delegate void FileDelegate(string filePath);

    public class FileManager
    {
        public event FileDelegate fd;

        public void Files(string filePath)
        {
            fd(filePath);
        }
    }
}
