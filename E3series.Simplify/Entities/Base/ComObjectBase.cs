using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using E3series.Simplify.Extensions;

namespace E3series.Simplify.Entities.Base
{
    public abstract class ComObjectBase<TE3ComObjectType> : IComObject
    {
        #region Private Fields

        private readonly List<IComObject> _children;

        #endregion
        
        #region Public Fields

        public TE3ComObjectType ComObject { get; private set; }

        #endregion

        #region Constructor

        protected ComObjectBase(IComObject parent, Func<TE3ComObjectType> createAction)
        {
            _children = new List<IComObject>();

            try
            {
                ComObject = createAction.Invoke();
                
                if (parent != null)
                    parent.RegisterChild(this);
            }
            catch
            {
                ComObject = default(TE3ComObjectType);
            }
        }

        #endregion

        #region IComObject Members

        public void RegisterChild(IComObject child)
        {
            _children.Add(child);
        }

        public void UnregisterChild(IComObject child)
        {
            _children.Remove(child);
        }

        #endregion
        
        #region IDisposable Members

        public virtual void Dispose()
        {
            if (ComObject != null)
            {
                Marshal.ReleaseComObject(ComObject);
                ComObject = default(TE3ComObjectType);
            }

            _children.Where(o => o != null).ForEach(o => o.Dispose());

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion
    }
}