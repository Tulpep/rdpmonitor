using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RDPMonitor
{
    static class Program
    {

        [STAThread]
        static void Main()
        {

            //Start MSTSC
            Process mstsc = new Process();
            mstsc.StartInfo.FileName = "mstsc.exe";
            mstsc.StartInfo.Arguments = @"\\CAVDCP05\Netlogon\VDI.rdp";
            mstsc.Start();
                         

            while (true)
            {
                Thread.Sleep(2000);

                //Check if process exists
                Process[] pname = Process.GetProcessesByName("mstsc");
                if (pname.Length == 0)
                {

                    Process logoff = new Process();
                    logoff.StartInfo.FileName = "logoff.exe";
                    //Do Not show Window
                    logoff.StartInfo.RedirectStandardOutput = true;
                    logoff.StartInfo.UseShellExecute = false;
                    logoff.StartInfo.CreateNoWindow = true;
                    //
                    logoff.Start();

                }
                                

            }

        }
    }
}
