using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;

namespace padSoft_e
{
    class scanFunction
    {
        public static bool blScan = false;
        public static bool initScan()
        {
            bool ret = false;
            if (SCANDriver() == true)
            {
                if (ScanPowerOn())
                {
                   // OpenComm(2,115200);
                    ret = true;
                }
            }
            else
                ret = false;
            return ret;
        }

        public static void oneBeeper()
        {            
            BeeperOn();
            Thread.Sleep(100);
            BeeperOff();
        }

        public static void twoBeeper()
        {
            oneBeeper();
            Thread.Sleep(100);
            oneBeeper();
        }
        
        [DllImport("SCAN_SDK.dll", EntryPoint = "SCANDriver", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool SCANDriver();

        [DllImport("SCAN_SDK.dll", EntryPoint = "ScanPowerOn", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool ScanPowerOn();

        [DllImport("SCAN_SDK.dll", EntryPoint = "ScanPowerOff", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool ScanPowerOff();

        [DllImport("SCAN_SDK.dll", EntryPoint = "LEDOn", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool LEDOn();

        [DllImport("SCAN_SDK.dll", EntryPoint = "LEDOff", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool LEDOff();

        [DllImport("SCAN_SDK.dll", EntryPoint = "BeeperOn", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool BeeperOn();

        [DllImport("SCAN_SDK.dll", EntryPoint = "BeeperOff", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool BeeperOff();

        [DllImport("SCAN_SDK.dll", EntryPoint = "OpenComm", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool OpenComm(int portNo, long BAUD);

        [DllImport("SCAN_SDK.dll", EntryPoint = "CloseComm", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool CloseComm();

        [DllImport("SCAN_SDK.dll", EntryPoint = "OneKeyScan", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool OneKeyScan();

        [DllImport("SCAN_SDK.dll", EntryPoint = "ScanKeyOff", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool ScanKeyOff();

        [DllImport("SCAN_SDK.dll", EntryPoint = "CommWrite", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool CommWrite(byte[] code, uint length);

        [DllImport("SCAN_SDK.dll", EntryPoint = "ScanResultStr", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool ScanResultStr(byte[] code, uint[] length);       
      
    }
}
