using e3;
using E3series.Simplify.Entities.Base;

namespace E3series.Simplify.Entities
{
    public class E3Device : ComObjectBase<IDeviceInterface>
    {
        public E3Device(E3Job job) : base(job, () => job.ComObject.CreateDeviceObject())
        {
        }
    }
}