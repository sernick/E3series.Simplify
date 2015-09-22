using System;

namespace E3series.Simplify.Entities.Base
{
    public interface IComObject : IDisposable
    {
        void RegisterChild(IComObject child);
        void UnregisterChild(IComObject child);
    }
}