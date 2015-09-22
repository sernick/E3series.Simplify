using System;
using System.Runtime.InteropServices;
using e3;
using E3series.Simplify.Entities.Base;
using E3series.Simplify.Entities.Base.Interfaces;
using E3series.Simplify.Helpers;

namespace E3series.Simplify.Entities
{
    public class E3Application : ComObjectBase, IComObjectProvider<IApplicationInterface>
    {
        #region Constructor

        public E3Application(int programId) : base(null)
        {
            Initialize(() => Connector.Connect(programId));
        }

        public E3Application() : base(null)
        {
            Initialize(Connector.Connect);
        }

        #endregion

        #region IComObjectProvider Members

        public IApplicationInterface ComObject { get; private set; }

        public void Initialize(Func<IApplicationInterface> createAction)
        {
            try
            {
                ComObject = createAction.Invoke();
            }
            catch
            {
                ComObject = null;
            }
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            
            if (ComObject != null)
            {
                Marshal.ReleaseComObject(ComObject);
                ComObject = null;
            }
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}