using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using E3series.Simplify.Helpers.Native;

namespace E3series.Simplify.Helpers
{
    static class Dispatcher
    {
        #region Public Methods

        [STAThread]
        public static IEnumerable<KeyValuePair<int, object>> GetE3Applications()
        {
            IRunningObjectTable runningObjectTable;
            IEnumMoniker monikerEnumerator;
            var monikers = new IMoniker[1];

            IBindCtx ctx;
            WinApi.CreateBindCtx(0, out ctx);

            ctx.GetRunningObjectTable(out runningObjectTable);
            runningObjectTable.EnumRunning(out monikerEnumerator);
            monikerEnumerator.Reset();

            while (monikerEnumerator.Next(1, monikers, IntPtr.Zero) == 0)
            {
                string runningObjectName;
                monikers[0].GetDisplayName(ctx, null, out runningObjectName);

                if (!runningObjectName.StartsWith("!E3Application", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                int index = runningObjectName.IndexOf(':');
                if (index == -1) continue;

                object runningObjectVal;
                runningObjectTable.GetObject(monikers[0], out runningObjectVal);

                yield return
                    new KeyValuePair<int, object>(int.Parse(runningObjectName.Substring(index + 1)),
                        runningObjectVal);
            }
        }

        #endregion
    }
}