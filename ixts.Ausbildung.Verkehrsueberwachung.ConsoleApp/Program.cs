
namespace ixts.Ausbildung.Verkehrsueberwachung.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new TrafficControl(args,"127.0.0.1:2000");
            controller.Start();
        }
    }
}
