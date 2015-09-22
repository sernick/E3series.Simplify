namespace E3series.Simplify.Entities.Base.Interfaces
{
    public interface IComObjectProvider<out TE3ComObjectType>
    {
        TE3ComObjectType ComObject { get; }
    }
}