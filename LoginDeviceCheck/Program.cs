using Microsoft.Win32;
using Newtonsoft.Json.Linq;

public class RegistryManager
{
    public static void main(string[] args)
    {
        //string keyPath = @"Software\MySQL\MySQL Installer - Community";                                                              //(current user)
        //string keyPath = @"S-1-5-21-917176998-1088348468-280010244-1008\Software\Demo0013";                                          //(users)
        //string keyPath = @"SYSTEM\HardwareConfig\{630c5e80-d966-11ed-a144-281286cf5d00}";                                            //(Local machine)
        //string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\S-1-5-21-917176998-1088348468-280010244-1008";     //(Local machine)
        //ReadRegistryValue(keyPath);


        //string keyPath2 = @"S-1-5-21-917176998-1088348468-280010244-1001\Software"; // Specify the path to the parent key (devic)
        //string keyPath2 = @"S-1-5-21-917176998-1088348468-280010244-1008\Software"; // Specify the path to the parent key  ( demo user)
        string keyPath2 = @"SOFTWARE"; // Specify the path to the parent key (devic)

        string subKeyName = "StrackTrack"; // Name of the subkey to create
        string valueName = "Id1"; // Name of the value to create

        //string valueData = Guid.NewGuid().ToString();

        CreateRegistrySubKeyAndValue(keyPath2, subKeyName, valueName);
    }

    public static void ReadRegistryValue(string keyName)
    {

        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, RegistryKeyPermissionCheck.ReadSubTree))
        {

            //object value = key.GetValue("LastRunDate");
            object value = key.GetValue("Sid");
            if (value is byte[] binaryData)
            {

                Console.WriteLine($"Value Name: {value}");

                foreach (byte byteValue in binaryData)
                {
                    //Console.Write($"    Value: {byteValue}");
                    Console.Write(byteValue);
                }
            }
            if (value != null)
            {
                Console.WriteLine(value.ToString());
            }

        }

        //Console.WriteLine("\n\n---------------------\n\n");
        /*using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, RegistryKeyPermissionCheck.ReadSubTree))
        {
            string[] valueNames = key.GetValueNames();

            foreach (string valueName in valueNames)
            {
                object value1 = key.GetValue(valueName);

                if (value1 is string[] multiStringArray)
                {
                    Console.WriteLine($"Value Name: {value1}");

                    foreach (string stringValue in multiStringArray)
                    {
                        Console.WriteLine($"    Value: {stringValue}");
                    }

                }
                else if (value1 is byte[] binaryData)
                {
                    
                    Console.WriteLine($"Value Name: {valueName}");

                    foreach (byte byteValue in binaryData)
                    {
                        Console.WriteLine($"    Value: {byteValue}");
                    }
                }
                else
                {
                    Console.WriteLine("\n");
                    object value = key.GetValue(valueName);
                    Console.WriteLine(valueName);
                    Console.WriteLine($"    Value: {value}");
                }
            }
        }*/

    }
    public static void CreateRegistrySubKeyAndValue(string keyPath, string subKeyName, string valueName)
    {
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree))
        {
            if (key != null)
            {
                // Create a subkey under the specified key
                using (RegistryKey subKey = key.CreateSubKey(subKeyName))
                {
                    // Set the value under the subkey
                    subKey.SetValue(valueName,12345);
                }
            }
            else
            {
                Console.WriteLine("Registry key not found.");
            }
        }
    }

   
}

