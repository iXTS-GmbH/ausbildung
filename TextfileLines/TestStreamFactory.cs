

namespace TextfileLines
{
    public class TestStreamFactory:IStreamFactory
    {

        public IStream Make(string inputPath, string outputPath)
        {
            return new TestStream(inputPath, outputPath);
        }
    }
}
