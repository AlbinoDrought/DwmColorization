namespace ColorShifter.Examples
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtARGB = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBlink = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.nudBlinks = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBlend = new System.Windows.Forms.Button();
            this.btnSynchBlend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinks)).BeginInit();
            this.SuspendLayout();
            // 
            // txtARGB
            // 
            this.txtARGB.Location = new System.Drawing.Point(12, 24);
            this.txtARGB.Name = "txtARGB";
            this.txtARGB.Size = new System.Drawing.Size(100, 20);
            this.txtARGB.TabIndex = 0;
            this.txtARGB.Text = "FFFF0000";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(118, 22);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(199, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ARGB:";
            // 
            // btnBlink
            // 
            this.btnBlink.Location = new System.Drawing.Point(118, 70);
            this.btnBlink.Name = "btnBlink";
            this.btnBlink.Size = new System.Drawing.Size(75, 23);
            this.btnBlink.TabIndex = 4;
            this.btnBlink.Text = "Blink";
            this.btnBlink.UseVisualStyleBackColor = true;
            this.btnBlink.Click += new System.EventHandler(this.btnBlink_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Duration:";
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(12, 73);
            this.nudDuration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(47, 20);
            this.nudDuration.TabIndex = 8;
            this.nudDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDuration.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // nudBlinks
            // 
            this.nudBlinks.Location = new System.Drawing.Point(65, 73);
            this.nudBlinks.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudBlinks.Name = "nudBlinks";
            this.nudBlinks.Size = new System.Drawing.Size(47, 20);
            this.nudBlinks.TabIndex = 10;
            this.nudBlinks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBlinks.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Blinks:";
            // 
            // btnBlend
            // 
            this.btnBlend.Location = new System.Drawing.Point(118, 99);
            this.btnBlend.Name = "btnBlend";
            this.btnBlend.Size = new System.Drawing.Size(75, 23);
            this.btnBlend.TabIndex = 11;
            this.btnBlend.Text = "Blend";
            this.btnBlend.UseVisualStyleBackColor = true;
            this.btnBlend.Click += new System.EventHandler(this.btnBlend_Click);
            // 
            // btnSynchBlend
            // 
            this.btnSynchBlend.Location = new System.Drawing.Point(199, 99);
            this.btnSynchBlend.Name = "btnSynchBlend";
            this.btnSynchBlend.Size = new System.Drawing.Size(75, 23);
            this.btnSynchBlend.TabIndex = 12;
            this.btnSynchBlend.Text = "SynchBlend";
            this.btnSynchBlend.UseVisualStyleBackColor = true;
            this.btnSynchBlend.Click += new System.EventHandler(this.btnSynchBlend_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSynchBlend);
            this.Controls.Add(this.btnBlend);
            this.Controls.Add(this.nudBlinks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBlink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtARGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlinks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtARGB;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBlink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.NumericUpDown nudBlinks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBlend;
        private System.Windows.Forms.Button btnSynchBlend;
    }
}