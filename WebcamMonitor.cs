using System;
using System.Threading;
using Microsoft.Win32;

namespace WebcamMonitor
{
    class Program
    {
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "WebcamMonitor_SingleInstance_V1", out createdNew))
            {
                if (!createdNew)
                {
                    return; 
                }

                bool wasWebcamActive = false;

                while (true)
                {
                    bool isWebcamActive = IsWebcamInUse();

                    if (isWebcamActive && !wasWebcamActive)
                    {
                        Console.Beep(3000, 200);
                        Thread.Sleep(100);
                        Console.Beep(3000, 200);
                    }

                    wasWebcamActive = isWebcamActive;
                    Thread.Sleep(1500); 
                }
            }
        }

        static bool IsWebcamInUse()
        {
            try
            {
                string basePath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam";
                using (RegistryKey consentStore = Registry.CurrentUser.OpenSubKey(basePath))
                {
                    if (consentStore != null)
                    {
                        foreach (string subKeyName in consentStore.GetSubKeyNames())
                        {
                            if (subKeyName.Equals("NonPackaged", StringComparison.OrdinalIgnoreCase))
                                continue;

                            using (RegistryKey subKey = consentStore.OpenSubKey(subKeyName))
                            {
                                if (IsKeyActive(subKey)) return true;
                            }
                        }

                        using (RegistryKey nonPackaged = consentStore.OpenSubKey("NonPackaged"))
                        {
                            if (nonPackaged != null)
                            {
                                foreach (string subKeyName in nonPackaged.GetSubKeyNames())
                                {
                                    using (RegistryKey subKey = nonPackaged.OpenSubKey(subKeyName))
                                    {
                                        if (IsKeyActive(subKey)) return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        static bool IsKeyActive(RegistryKey key)
        {
            if (key != null)
            {
                object stopTimeObj = key.GetValue("LastUsedTimeStop");
                if (stopTimeObj != null)
                {
                    long stopTime = Convert.ToInt64(stopTimeObj);
                    return stopTime == 0;
                }
            }
            return false;
        }
    }
}