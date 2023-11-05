using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AConsole
{
    public class Offsets
    {
        //LocalPlayer offsets
        public const Int32 LocalPlayerPointerOffset1 = 0x109B74;
        public const Int32 LocalPlayerPointerOffset2 = 0x10F4F4;
        public const Int32 LocalPlayerPointerOffset3 = 0x11E20C;

        //Health
        public const Int32 HealthOffset = 0xF8;

        //find positiInt32ffset
        public const Int32 HeadPosOffset = 0x4;
        public const Int32 BodyPosOffset = 0x34;

        //find viewanInt32offset
        public const Int32 YawOffset = 0x40;
        public const Int32 PitchOffset = 0x44;
       
        //find the enInt32List pointer
        public const Int32 EntityListPointer1 = 0x110D90;
        public const Int32 EntityListPointer2 = 0x10f4f8;

        //Movement ofInt32s
        public const Int32 HighJumpPointer = 0x69;

    }
}
