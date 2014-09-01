
namespace TextFileLines
{
    public class FileStreamFactory:IFileStreamFactory
    {
        public IFileStream Make(string inputFileName)
        {
            return new FileStreamImpl(inputFileName);
        }
    }
}
