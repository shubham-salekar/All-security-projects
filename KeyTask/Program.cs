using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

//[assembly: AssemblyVersion("1.0.0.0")]
//public class Play
//{
//    public static void Run()
//    {
//        Console.WriteLine("In Fun V1 ");
//    }



//}

public class Program
{
    static void Main(string[] args)
    {
        // Play.Run();
        var datetimenow = DateTimeOffset.Now;
        var datetimoffseteutcnow = DateTimeOffset.UtcNow;
        var datetimeutcnow = DateTime.UtcNow;

        Console.WriteLine(datetimenow);
        Console.WriteLine(datetimoffseteutcnow);
        Console.WriteLine(datetimeutcnow);

        TimeZoneInfo mytzone = TimeZoneInfo.Local;
        var localtime = TimeZoneInfo.ConvertTimeFromUtc(datetimeutcnow, mytzone);
        Console.WriteLine(mytzone);
        Console.WriteLine(localtime);
    }
}



