namespace TextFileLines
{
    public class TestFileStreamFactory:IFileStreamFactory
    {
        public IFileStream Make(string inputFileName)
        {
            return new TestFileStream(inputFileName);
        }
    }
}
