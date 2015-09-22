using e3;
using E3series.Simplify.Entities.Base;

namespace E3series.Simplify.Entities
{
    public class E3Job : ComObjectBase<IJobInterface>
    {
        #region Constructor

        public E3Job(E3Application app) : base(app, () => app.ComObject.CreateJobObject())
        {
        }

        #endregion
    }
}