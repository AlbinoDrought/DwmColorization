using System.Runtime.InteropServices;
using System.Drawing;
using System;
using System.Threading;

namespace ColorShifter
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

    class ColorShiftHelper : ColorShifter
    {
        /// <summary>
        /// opaqueBlend: 0 for transparency, 1 for opaque
        /// </summary>
        public ColorizationParameters cp;
        private ColorizationParameters original;
        Thread colorThread;

        public ColorShiftHelper()
        {
            // Store the current colorscheme
            DwmGetColorizationParameters(ref cp);
            original = cp;
        }

        public ColorShiftHelper(ColorizationParameters _cp)
        {
            // We always want the original colors
            DwmGetColorizationParameters(ref original);
            cp = _cp;
        }

        public void update()
        {
            DwmSetColorizationParameters(ref cp);
        }

        public void update(ColorizationParameters _cp)
        {
            cp = _cp;
            update();
        }

        /// <summary>
        /// Reset the theme color to what it was when this class was initialized
        /// </summary>
        /// <param name="overwrite">If true, resets the stored color to the original color</param>
        public void resetColor(bool overwrite = true)
        {
            if (overwrite)
            {
                cp = original;
            }
            DwmSetColorizationParameters(ref original);
        }

        public void makeBright()
        {
            setColorBalance(120, false);
            setTransparency(false, false);
            setBlurBalance(0, false);
            setColorBalance(100, false);
        }

        #region Blend
        public void synchBlendInto(Color start, Color end, int pause = 50)
        {
            setColor(start);
            for(int i = 0; i < 50; i++)
            {
                setColor(Blend(getColor(), end, 0.95));
                Thread.Sleep(pause);
            }
        }

        public void blendInto(Color end, int pause = 50)
        {
            blendInto(getColor(), end, pause);
        }

        public void blendInto(Color start, Color end, int pause = 50)
        {
            if (colorThread != null && colorThread.ThreadState == ThreadState.Running)
                return;
            colorThread = new Thread(() => { synchBlendInto(start, end, pause); });
            colorThread.Start();
        }
        #endregion

        #region Blink
        /// <summary>
        /// Blinks between color and color2 in the same thread
        /// </summary>
        /// <param name="color">First blink color</param>
        /// <param name="color2">Second blink (return) color</param>
        /// <param name="blinks">Amount of blinks</param>
        /// <param name="duration">Pause after changing to the first color</param>
        /// <param name="pause">Pause after changing to the second color</param>
        public void synchBlink(Color color, Color color2, int blinks, int duration, int pause)
        {
            for (int i = 0; i < blinks; i++)
            {
                setColor(color);
                Thread.Sleep(duration);
                setColor(color2);
                Thread.Sleep(pause);
            }
        }

        /// <summary>
        /// Blinks between a specified color and the current color asynchronously
        /// </summary>
        /// <param name="color">Blink color</param>
        /// <param name="blinks">Amount of blinks</param>
        /// <param name="duration">Pause after changing to the color</param>
        /// <param name="pause">Pause after changing back from the color</param>
        public void blink(Color color, int blinks = 2, int duration = 250, int pause = -1)
        {
            ColorizationParameters current = new ColorizationParameters();
            DwmGetColorizationParameters(ref current);
            blink(color, Color.FromArgb(current.color), blinks, duration, pause);
        }

        /// <summary>
        /// Blinks between the specified colors asynchronously
        /// </summary>
        /// <param name="color">First blink color</param>
        /// <param name="color2">Second blink (return) color</param>
        /// <param name="blinks">Amount of blinks</param>
        /// <param name="duration">Pause after changing to the first color</param>
        /// <param name="pause">Pause after changing to the second color</param>
        public void blink(Color color, Color color2, int blinks = 2, int duration = 250, int pause = -1)
        {
            if (colorThread != null && colorThread.ThreadState == ThreadState.Running)
                return;
            if (pause == -1)
                pause = duration;
            colorThread = new Thread(() => { synchBlink(color, color2, blinks, duration, pause); });
            colorThread.Start();
        }
        #endregion

        #region Set/Get Methods
        // cp.color
        public void setColor(Color c, bool update = true)
        {
            cp.color = c.ToArgb();
            if (update)
            {
                this.update();
            }
        }

        public void setColor(int argb, bool update = true)
        {
            cp.color = argb;
            if (update)
            {
                this.update();
            }
        }

        public Color getColor()
        {
            return Color.FromArgb(cp.color);
        }

        // original.color
        public Color getOriginalColor()
        {
            return Color.FromArgb(original.color);
        }

        // cp.colorBalance
        public void setColorBalance(int colorbalance, bool update = true)
        {
            // Can't be below 0 or above 100
            cp.colorBalance = limit(colorbalance);
            if (update)
            {
                this.update();
            }
        }

        public int getColorBalance()
        {
            return cp.colorBalance;
        }

        // cp.afterglow
        public void setAfterglow(Color c, bool update = true)
        {
            cp.afterglow = c.ToArgb();
            if (update)
            {
                this.update();
            }
        }

        public void setAfterglow(int argb, bool update = true)
        {
            cp.afterglow = argb;
            if (update)
            {
                this.update();
            }
        }

        public Color getAfterglow()
        {
            return Color.FromArgb(cp.afterglow);
        }

        // cp.afterglowBalance
        public void setAfterglowBalance(int afterglowBalance, bool update = true)
        {
            cp.afterglowBalance = limit(afterglowBalance);
            if (update)
            {
                this.update();
            }
        }

        public int getAfterglowBalance()
        {
            return cp.afterglowBalance;
        }

        // cp.blurBalance
        /// <summary>
        /// Blur Balance only comes into effect if transparency is enabled. At maximum value (120), bars around windows will be completely transparent.
        /// </summary>
        /// <param name="blurbalance">Value between 0-120. 0 = Opaque window borders, 120 = Fully transparent window borders</param>
        public void setBlurBalance(int blurbalance, bool update = true)
        {
            cp.blurBalance = limit(blurbalance, 120);
            if (update)
            {
                this.update();
            }
        }

        public int getBlurBalance()
        {
            return cp.blurBalance;
        }

        // cp.opaqueBlend
        public void setTransparency(bool transparent, bool update = true)
        {
            cp.opaqueBlend = transparent ? 0 : 1;
            if (update)
            {
                this.update();
            }
        }

        public bool getTransparency()
        {
            // 0 is transparent
            return (cp.opaqueBlend == 0);
        }

        // cp.glassReflectionIntensity
        /// <summary>
        /// GlassReflectionIntensity is the intensity of the "Aero Stripes". Windows 7 only
        /// </summary>
        /// <param name="intensity"></param>
        public void setGlassReflectionIntensity(int intensity, bool update = true)
        {
            cp.glassReflectionIntensity = limit(intensity, 120);
            if (update)
            {
                this.update();
            }
        }

        public int getGlassReflectionIntensity()
        {
            return cp.glassReflectionIntensity;
        }
        #endregion

        private int limit(int input, int maximum = 100, int minimum = 0)
        {
            return Math.Max(minimum, Math.Min(maximum, input));
        }

        //http://stackoverflow.com/questions/3722307/is-there-an-easy-way-to-blend-two-system-drawing-color-values
        /// <summary>Blends the specified colors together.</summary>
        /// <param name="color">Color to blend onto the background color.</param>
        /// <param name="backColor">Color to blend the other color onto.</param>
        /// <param name="amount">How much of <paramref name="color"/> to keep,
        /// “on top of” <paramref name="backColor"/>.</param>
        /// <returns>The blended colors.</returns>
        private static Color Blend(Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
    }
}

