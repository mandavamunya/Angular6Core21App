using System.IO;

namespace Application.Core.Interfaces
{
    public interface IFileProcessor
    {
        void CreateFile(Stream data);
        void ProcessDirectory(string targetDirectory);
        void ProcessFile(string path);
        string[] ReadFile(string path);
    }
}
