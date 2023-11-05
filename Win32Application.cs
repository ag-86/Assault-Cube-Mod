using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AConsole
{
    internal class Win32Application
    {

        //ProcessEntry32Structure
        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szExeFile;
        };


        //ModuleEntry32Structure
        [StructLayout(LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public struct MODULEENTRY32
        {
            internal uint dwSize;
            internal uint th32ModuleID;
            internal uint th32ProcessID;
            internal uint GlblcntUsage;
            internal uint ProccntUsage;
            internal IntPtr modBaseAddr;
            internal uint modBaseSize;
            internal IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szExePath;
        }


        //WriteProcessMemoryAPI
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            Int32 nSize,
            IntPtr lpNumberOfBytesWritten);


        //ReadProcessMemoryAPI
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            IntPtr lpNumberOfBytesRead);


        //OpenProcessAPI
        [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr OpenProcess(
            uint processAccess,
            bool bInheritHandle,
            uint processId);


        //CloseHandleAPI
        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(
            IntPtr hObject);

        //CreateToolHelp32SnapshotAPI
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(
            Int32 dwFlags,
            uint th32ProcessID);

        //Process32FirstAPI
        [DllImport("kernel32.dll")]
        static extern bool Process32First(
            IntPtr hSnapshot,
            ref PROCESSENTRY32 lppe);

        //Process32NextAPI
        [DllImport("kernel32.dll")]
        static extern bool Process32Next(
            IntPtr hSnapshot,
            ref PROCESSENTRY32 lppe);

        
        //Module32FirstAPI
        [DllImport("kernel32.dll")]
        static extern bool Module32First(
            IntPtr hSnapshot,
            ref MODULEENTRY32 lpme);


        //Module32NextAPI
        [DllImport("kernel32.dll")]
        static extern bool Module32Next(
            IntPtr hSnapshot,
            ref MODULEENTRY32 lpme);

       
        //GetAsyncKeyStateAPI
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int ArrowKeys);



        //Custom Methods
        public static Process GetProcess(string procname, ref bool isValid)
        {
            Process proc = new Process();
            Process[] procArray = Process.GetProcessesByName(procname);


            if (procArray.Length != 0)
            {
                isValid = true;
                proc = procArray[0];
            }
            else
            {
                isValid = false;
            }

            return proc;

        }

        public static IntPtr GetModuleBase(string modulename, ref Process proc)
        {
            if (modulename.Contains(".exe"))
                return proc.MainModule.BaseAddress;

            foreach (ProcessModule module in proc.Modules)
            {
                if (module.ModuleName == modulename)
                    return module.BaseAddress;
            }
            return IntPtr.Zero;
        }
    }
}
