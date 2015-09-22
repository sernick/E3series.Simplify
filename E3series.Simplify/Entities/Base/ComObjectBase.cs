using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using E3series.Simplify.Entities.Base.Interfaces;
using E3series.Simplify.Extensions;

namespace E3series.Simplify.Entities.Base
{
    public abstract class ComObjectBase: IComObject
    {
       #region Private Fields

        private readonly IComObject _parent;
        private readonly IList<IComObject> _children;

        #endregion

        #region Constructor

        protected ComObjectBase(IComObject parent)
        {
            _parent = parent;
            _children = new IComObject[] { };
            
            if (_parent != null)
                _parent.RegisterChild(this);
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
            if (_parent != null)
                _parent.UnregisterChild(this); 

            _children.Where(o => o != null).ForEach(o => o.Dispose());
            _children.Clear();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion
    }
}