using System;
using AConsole;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AConsole
{
    class Program
    {

        struct Vec3D
        {
            public float x, y, z;
        }

        static void Main(string[] args)
        {
            bool isValid = false;

            //Getting process
            Process AcProc = Win32Application.GetProcess("ac_client", ref isValid);

            if (!isValid)
            {
                return;
            }

            if (AcProc.Handle == IntPtr.Zero || AcProc.Handle.ToInt32() == -1)
            {
                return;
            }

            IntPtr ModuleBaseAdress = Win32Application.GetModuleBase("ac_client.exe", ref AcProc);

            if (ModuleBaseAdress == IntPtr.Zero)
            {
                return;
            }
            else
            {
                byte[] buffer = new byte[12];
                byte[] buffer2 = new byte[4];

                //Main loop
                while (!AcProc.HasExited)
                {  
                    if ((Win32Application.GetAsyncKeyState(0x2D) & 1) == 1) //Insert
                    {
                        break;
                    }
                    else
                    {

                        IntPtr LocalPlayerAdress;
                        Win32Application.ReadProcessMemory(
                            AcProc.Handle,
                            (IntPtr)(ModuleBaseAdress.ToInt32() + AConsole.Offsets.LocalPlayerPointerOffset2),
                            buffer2,
                            4,
                            IntPtr.Zero);

                        LocalPlayerAdress = (IntPtr)(BitConverter.ToInt32(buffer2));

                        if (LocalPlayerAdress == IntPtr.Zero)
                        {
                            continue;
                        }

                        if ((Win32Application.GetAsyncKeyState(0x61) & 1) == 1) //Numpad 1
                        {
                            Win32Application.ReadProcessMemory(
                            AcProc.Handle,
                            (IntPtr)(LocalPlayerAdress.ToInt32() + AConsole.Offsets.BodyPosOffset),
                            buffer,
                            12,
                            IntPtr.Zero);


                        }
                        if ((Win32Application.GetAsyncKeyState(0x62) & 1) == 1) //Numpad 2
                        {
                            Win32Application.WriteProcessMemory(
                            AcProc.Handle,
                            (IntPtr)(LocalPlayerAdress.ToInt32() + AConsole.Offsets.BodyPosOffset),
                            buffer,
                            12,
                            IntPtr.Zero);

                        }
                    }
                }
            }
        }
    }

}


