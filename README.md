DwmColorization
===============

Simple port of the base functions used in "ColorShifter-qt" to C#. See https://github.com/elfakyn/ColorShifter-qt for more information on usage.

*See Examples/TestForm.cs for in-use examples.*

Example of use without helper:

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

Example of use with helper:

    static void Main(string args[])
    {
        // Initialize helper. This automatically saves the original color
        // Optionally, you can pass ColorizationParameters to it
        ColorShifterHelper c = new ColorShifterHelper();

        // The false is there because you're changing more than one thing at a time
        // If false, it does not automatically update the theme color
        c.setColor(Color.Red, false);
        c.setTransparency(true);

        System.Threading.Thread.Sleep(2000);
        c.makeBright();
        c.setTransparency(false, false);
        c.setColor(Color.Green, false);
        // Glass Reflection Intensity is the "intensity" of the stripes you see on Windows 7. 0 hides them completely, and gives a look closer to Windows 7.
        c.setGlassReflectionIntensity(0);

        System.Threading.Thread.Sleep(2000);
        // Return to original color before exiting
        c.restoreColor();
    }
