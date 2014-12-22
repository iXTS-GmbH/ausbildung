
namespace ixts.Ausbildung.Filesystemsuche
{
    public class DirDepth:FTW
    {
        private int maxDepth = 0;
        private int depth = 0;


        protected override void EnterDir(string directoryPath)
        {
            depth++;
            if (depth > maxDepth)
            {
                maxDepth = depth;
            }
        }

        protected override void LeaveDir(string directoryPath)
        {
            depth--;
        }

        protected override void AtFile(string filePath){}
    }
}
