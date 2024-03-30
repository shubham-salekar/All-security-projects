#pragma warning disable CA1416

using System;
using System.Management;

class Demo
{
    public static double ByteToGB(ulong value)
    {
        return Math.Round(value / 1024d / 1024d / 1024d, 2);
    }
    public static void main(string[] args)
    {

        ManagementObjectSearcher searcher = new("SELECT * FROM Win32_ComputerSystem");

        foreach (var mo in searcher.Get())
        {
            Console.WriteLine($"Name: {mo["Name"]}");
            Console.WriteLine($"Manufacturer: {mo["Manufacturer"]}");
            Console.WriteLine($"Model: {mo["Model"]}");
            Console.WriteLine($"Total physical memory: {ByteToGB((ulong)mo["TotalPhysicalMemory"])} GB");
            Console.WriteLine($"Number of processors: {mo["NumberOfProcessors"]}");
            Console.WriteLine();
        }

        searcher = new("SELECT * FROM Win32_VideoController");

        foreach (var mo in searcher.Get())
        {
            Console.WriteLine($"Graphics card: {mo["Name"]}");
            Console.WriteLine();
        }

        searcher = new("SELECT * FROM Win32_Processor");

        foreach (var mo in searcher.Get())
        {
            Console.WriteLine($"Processor: {mo["Name"]}");
            Console.WriteLine($"Number of cores: {mo["NumberOfCores"]}");
            Console.WriteLine($"Number of logical processors: {mo["NumberOfLogicalProcessors"]}");
            Console.WriteLine($"Max clock speed: {mo["MaxClockSpeed"]} MHz");
            Console.WriteLine();
        }

        searcher = new("SELECT * FROM Win32_PhysicalMemory");

        foreach (var mo in searcher.Get())
        {
            Console.WriteLine($"RAM: {ByteToGB((ulong)mo["Capacity"])} GB");
            Console.WriteLine($"Type: {mo["MemoryType"]}");
            Console.WriteLine($"Speed: {mo["Speed"]} MHz");
            Console.WriteLine();
        }

        // for more ingp SELECT UUID,Caption,Description,IdentifyingNumber,Name,SKUNumber,Vendor,Version FROM Win32_ComputerSystemProduct
    }
}
