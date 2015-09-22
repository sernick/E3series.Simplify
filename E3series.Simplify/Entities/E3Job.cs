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
        
        #region IDisposable Members

        // ReSharper disable once RedundantOverridenMember
        public override void Dispose()
        {
            //TODO: Future - need to dispose all child objects
            base.Dispose();
        }

        #endregion
    }
}