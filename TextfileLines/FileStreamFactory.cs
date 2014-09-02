
namespace TextFileLines
{
    public class FileStreamFactory:IFileStreamFactory
    {
        public IFileStream Make(string sourcePath)
        {
            return new FileStreamImpl(sourcePath);
        }
    }
}
