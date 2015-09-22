using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using e3;
using E3series.Simplify.Helpers.Native;

namespace E3series.Simplify.Helpers
{
    public static class Connector
    {
        #region Constants

        private const string Identifier = "E3.series";

        #endregion

        #region Public Methods

        [STAThread]
        public static e3Application Connect()
        {
            var processList = Process.GetProcessesByName(Identifier);

            switch (processList.Length)
            {
                case 0:
                    return null;
                case 1:
                    return Connect(processList[0].Id);
                default:
                    throw new NotImplementedException();
            }
        }

        [STAThread]
        public static e3Application Connect(int programId)
        {
            if (programId != 0)
            {
                var keyValuePair = Dispatcher.GetE3Applications().FirstOrDefault(o => o.Key == programId);
                if (!Equals(keyValuePair,default(KeyValuePair<int,object>)))
                    return (e3Application) keyValuePair.Value;
            }

            return Connect();
        }

        #endregion
    }
}