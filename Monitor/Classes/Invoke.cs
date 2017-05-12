using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Monitor.Classes
{
    class Invoke
    {
        [DllImport("Travel.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LoadTravelInfoStruFromFile")]
        internal static extern int LoadTravelInfoStruFromFile(string FileName, IntPtr pTravel, float CableRealLength);

        [DllImport("Travel.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CheckIsMouseInTravel")]
        internal static extern int CheckIsMouseInTravel(int x, int y, IntPtr pTravel, ref float pminLenofDotToLine, ref int pSegLocNum, ref int pIsIn, ref float pSegX, ref float pSegY, ref float pLocRealLen);
        
        [DllImport("Travel.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CheckIsMouseInTravel")]
        internal static extern int CheckMapPointFromCableRealLen(float CableRealLoc, IntPtr pTravel,ref int pSegLocNumFromReal,ref float pLocSegX,ref float pLocSegY);
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct PathSegmentInfoStru
    {
        int segNum;
        int x0, y0, x1, y1;
        float segPixelLen;
        double slope;
        double constant;
        float segLenAccumu;
        float segRealLenStart;
        float segRealLenAccumu;
        float segRealLen;
        float segProportion;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct TravelInfoStru
    {

        int DotNum;
        int AllSegNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        int[] xPoint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        int[] yPoint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        float[] CablesegRealLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        PathSegmentInfoStru[] Seg;
        float CableOverallLen;
    }
}
