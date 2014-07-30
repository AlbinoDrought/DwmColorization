using System.Runtime.InteropServices;
using System.Drawing;
using System;

namespace AlbinoDrought
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

        private int limit(int input, int maximum = 100, int minimum = 0)
        {
            return Math.Max(minimum, Math.Min(maximum, input));
        }

        public void makeBright()
        {
            setColorBalance(120, false);
            setTransparency(false, false);
            setBlurBalance(0, false);
            setColorBalance(100, false);
        }

        #region set/get

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
    }
}
