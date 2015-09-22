using System;

namespace E3series.Simplify.Entities.Base.Interfaces
{
    public interface IComObjectProvider<TE3ComObjectType>
    {
        TE3ComObjectType ComObject { get; }
        void Initialize(Func<TE3ComObjectType> createAction);
    }
}