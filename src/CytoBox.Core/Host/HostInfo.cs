using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace CytoBox.Core.Host
{
    public static class HostInfo
    {
        public static void GetHostInfo()
        {
            //IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName()); //通过主机名去获取全部ip信息

            //IpEntry.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToList()
            //  .ForEach(y => Console.WriteLine(y)); //获取Ipv4

            //IpEntry.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetworkV6).ToList()
            //.ForEach(y => Console.WriteLine(y)); //获取Ipv6

            Console.WriteLine($"本机操作系统和信息！\nLinux：{RuntimeInformation.IsOSPlatform(OSPlatform.Linux)}\nOSX：{RuntimeInformation.IsOSPlatform(OSPlatform.OSX)}\nWindows：{RuntimeInformation.IsOSPlatform(OSPlatform.Windows)}\n系统架构：{RuntimeInformation.OSArchitecture}\n系统名称：{RuntimeInformation.OSDescription}\n进程架构：{RuntimeInformation.ProcessArchitecture}\n是否64位操作系统：{Environment.Is64BitOperatingSystem}\n");
        }
    }
}
