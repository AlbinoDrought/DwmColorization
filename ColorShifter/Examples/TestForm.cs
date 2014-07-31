using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorShifter.Examples
{
    public partial class TestForm : Form
    {
        ColorShiftHelper csh = new ColorShiftHelper();

        public TestForm()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            csh.setColor(getHexColor());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            csh.resetColor();
        }

        private void btnBlink_Click(object sender, EventArgs e)
        {
            csh.blink(Color.FromArgb(getHexColor()), (int)nudBlinks.Value, (int)nudDuration.Value);
        }

        private int getHexColor()
        {
            return Int32.Parse(txtARGB.Text, System.Globalization.NumberStyles.HexNumber);
        }

        private Color getColor()
        {
            return Color.FromArgb(getHexColor());
        }

        private void btnBlend_Click(object sender, EventArgs e)
        {
            csh.blendInto(getColor());
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnReset.PerformClick();
        }

        private void btnSynchBlend_Click(object sender, EventArgs e)
        {
            csh.synchBlendInto(csh.getOriginalColor(), getColor());
        }
    }
}
