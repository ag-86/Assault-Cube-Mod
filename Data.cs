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
        public const Int32
        LocalPlayerPointerOffset1 = 0x109B74,
        LocalPlayerPointerOffset2 = 0x10F4F4,
        LocalPlayerPointerOffset3 = 0x11E20C,

        //Health
        HealthOffset = 0xF8,

        //find positiInt32ffset
        HeadPosOffset = 0x4,
        BodyPosOffset = 0x34,

        //find viewanInt32offset
        YawOffset = 0x40,
        PitchOffset = 0x44,

        //find the enInt32List pointer
        EntityListPointer1 = 0x110D90,
        EntityListPointer2 = 0x10f4f8,

        //Movement ofInt32s
        HighJumpPointer = 0x69;

    }
}
