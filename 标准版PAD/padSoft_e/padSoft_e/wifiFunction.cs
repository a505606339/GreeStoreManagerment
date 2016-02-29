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
    class wifiFunction
    {
        public static bool blWifi = false;
        public static bool powerOnWiFi()
        {
            if (blWifi == false)
            {
                if (WiFiDriver())
                {
                    blWifi = true;
                    if (WiFiPowerOn())
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                if (WiFiPowerOn())
                    return true;
                else
                    return false;
            }
        }

        public static bool powerOffWifi()
        {
            if (blWifi == false)
            {
                if (WiFiDriver())
                {
                    blWifi = true;
                    if (blWifi == true)
                    {
                        if (WiFiPowerOff())
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                if (WiFiPowerOff())
                    return true;
                else
                    return false;
            }
        }
        
        [DllImport("WiFi_SDK.dll", EntryPoint = "WiFiDriver", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool WiFiDriver();

        [DllImport("WiFi_SDK.dll", EntryPoint = "WiFiPowerOn", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool WiFiPowerOn();

        [DllImport("WiFi_SDK.dll", EntryPoint = "WiFiPowerOff", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public extern static bool WiFiPowerOff();
    }
}
