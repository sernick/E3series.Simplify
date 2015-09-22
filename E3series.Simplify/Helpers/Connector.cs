using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using e3;
using E3series.Simplify.Helpers.Native;
using E3series.Simplify.ViewModels;

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
                    IntPtr hWnd = WinApi.GetForegroundWindow();
                    int curPid;
                    WinApi.GetWindowThreadProcessId(hWnd, out curPid);

                    if (Process.GetProcessById(curPid).ProcessName == Assembly.GetEntryAssembly().GetName().Name)
                    {
                        IntPtr targetHwnd =
                            WinApi.GetWindow(Process.GetCurrentProcess().MainWindowHandle,
                                (uint)WinApi.GetWindowCmd.GW_HWNDNEXT);
                        while (true)
                        {
                            IntPtr temp = WinApi.GetParent(targetHwnd);
                            if (temp.Equals(IntPtr.Zero)) break;
                            targetHwnd = temp;
                        }
                        WinApi.GetWindowThreadProcessId(targetHwnd, out curPid);
                    }

                    if (Process.GetProcessById(curPid).ProcessName == Identifier)
                        return Connect(Process.GetProcessById(curPid).Id);

                    var vm = new SelectionViewModel();

                    return vm.ShowDialog() == true
                        ? vm.SelectedE3Application
                        : null;
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