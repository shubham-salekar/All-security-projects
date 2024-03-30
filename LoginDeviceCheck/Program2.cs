using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDeviceCheck
{
    internal class Program2
    {
        public static void main()
        {
            //HARDWARE\DEVICEMAP\VIDEO
            //RegistryKey key = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\VIDEO",RegistryKeyPermissionCheck.ReadSubTree);

            RegistryKey test9999 = Registry.CurrentUser.CreateSubKey("Software\\Test22_11", RegistryKeyPermissionCheck.ReadWriteSubTree);

            // Create subkeys under HKEY_CURRENT_USER\Test9999.

         /*   using (RegistryKey testSettings = test9999.CreateSubKey("TestSettings"))
            {
                testSettings.SetValue("ID", 12345);
            }*/

            // Print the information from the Test9999 subkey.
            // Console.WriteLine("There are {0} subkeys under {1}.", test9999.SubKeyCount.ToString(), test9999.Name);

            foreach (string subKeyName in test9999.GetSubKeyNames())
            {
                using (RegistryKey tempKey = test9999.OpenSubKey(subKeyName))
                {
                    Console.WriteLine("\nThere are {0} values for {1}.",tempKey.ValueCount.ToString(), tempKey.Name);

                    foreach (string valueName in tempKey.GetValueNames())
                    {
                        Console.WriteLine("{0,-8}: {1}", valueName,tempKey.GetValue(valueName).ToString());
                    }
                }
            }
            test9999.Close();                   
        }

    }
}
