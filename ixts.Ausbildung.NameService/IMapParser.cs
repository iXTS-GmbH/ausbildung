
namespace ixts.Ausbildung.NameService
{
    public interface IMapParser
    {
        IMap LoadMap();
        void SaveMap(IMap map);
    }
}
