using System.Runtime.InteropServices;
namespace Color_Shifter
{
    class ColorShifter
    {
        [DllImport("dwmapi.dll", EntryPoint = "#127")]
        public static extern void DwmGetColorizationParameters(ref ColorizationParameters c);

        [DllImport("dwmapi.dll", EntryPoint = "#131")]
        public static extern void DwmSetColorizationParameters(ref ColorizationParameters c, int needed = 0);

        [StructLayout(LayoutKind.Sequential)]
        public struct ColorizationParameters
        {
            public int color, afterglow, colorBalance, afterglowBalance, blurBalance, glassReflectionIntensity, opaqueBlend;
        }
    }
}
