using System;

namespace E3series.Simplify.Entities.Base.Interfaces
{
    public interface IComObject : IDisposable
    {
        void RegisterChild(IComObject child);
        void UnregisterChild(IComObject child);
    }
}