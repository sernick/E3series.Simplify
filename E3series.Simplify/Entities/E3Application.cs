using e3;
using E3series.Simplify.Entities.Base;
using E3series.Simplify.Entities.Base.Interfaces;
using E3series.Simplify.Helpers;

namespace E3series.Simplify.Entities
{
    public class E3Application : ComObjectBase, IComObjectProvider<IApplicationInterface>
    {
        #region Constructor

        public E3Application(int programId)
            : base(null, () => Connector.Connect(programId))
        {
        }

        public E3Application()
            : base(null, Connector.Connect)
        {
        }

        #endregion

        #region IComObjectProvider Members

        public IApplicationInterface ComObject { get { return Object as IApplicationInterface; } }

        #endregion
    }
}