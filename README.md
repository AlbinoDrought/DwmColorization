DwmColorization
===============

Simple port of the base functions used in "ColorShifter-qt" to C#. See https://github.com/elfakyn/ColorShifter-qt for more information on usage.

Example:

    static void Main(string args[])
    {
        ColorShifter.ColorizationParameters c = new ColorShifter.ColorizationParameters();
        ColorShifter.ColorizationParameters original;
        
        // Store the current settings
        ColorShifter.DwmGetColorizationParameters(ref c);
        original = c;
        
        // Change the color to red
        c.color = 0xFF0000;
        ColorShifter.DwmSetColorizationParameters(ref c);
        
        // Sleep for a while to let the user enjoy the colors
        System.Threading.Thread.Sleep(2000);
        ColorShifter.DwmSetColorizationParameters(ref original);
    }
