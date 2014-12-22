
namespace ixts.Ausbildung.Algebraische_Strukturen
{
    public interface IField<F>:IRing<F> where F:IField<F>
    {
        F Div(F x);
    }
}
