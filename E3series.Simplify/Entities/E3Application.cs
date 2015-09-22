using e3;
using E3series.Simplify.Entities.Base;
using E3series.Simplify.Helpers;

namespace E3series.Simplify.Entities
{
    public class E3Application : ComObjectBase<IApplicationInterface>
    {
        #region Private Fields

        private E3Job _job;

        #endregion
        
        #region Constructor

        public E3Application(int programId): base(null, () => Connector.Connect(programId))
        {
        }

        public E3Application() : base(null, Connector.Connect)
        {
        }

        #endregion

        #region Public Fields

        public E3Job Job
        {
            get { return _job ?? (_job = new E3Job(this)); }
        }

        #endregion
    }
}