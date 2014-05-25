namespace ModSimulator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.buttonBeginSending = new System.Windows.Forms.Button();
            this.buttonStopSendingData = new System.Windows.Forms.Button();
            this.timerDataGenerationTicker = new System.Windows.Forms.Timer(this.components);
            this.textBoxSourceName = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.numericUpDownTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.labelTimerRate = new System.Windows.Forms.Label();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBeginSending
            // 
            this.buttonBeginSending.Location = new System.Drawing.Point(9, 184);
            this.buttonBeginSending.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBeginSending.Name = "buttonBeginSending";
            this.buttonBeginSending.Size = new System.Drawing.Size(216, 26);
            this.buttonBeginSending.TabIndex = 0;
            this.buttonBeginSending.Text = "Begin transmitting";
            this.buttonBeginSending.UseVisualStyleBackColor = true;
            this.buttonBeginSending.Click += new System.EventHandler(this.buttonBeginSending_Click);
            // 
            // buttonStopSendingData
            // 
            this.buttonStopSendingData.Location = new System.Drawing.Point(9, 215);
            this.buttonStopSendingData.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStopSendingData.Name = "buttonStopSendingData";
            this.buttonStopSendingData.Size = new System.Drawing.Size(216, 26);
            this.buttonStopSendingData.TabIndex = 1;
            this.buttonStopSendingData.Text = "Stop";
            this.buttonStopSendingData.UseVisualStyleBackColor = true;
            this.buttonStopSendingData.Click += new System.EventHandler(this.buttonStopSendingData_Click);
            // 
            // timerDataGenerationTicker
            // 
            this.timerDataGenerationTicker.Tick += new System.EventHandler(this.timerDataGenerationTicker_Tick);
            // 
            // textBoxSourceName
            // 
            this.textBoxSourceName.Location = new System.Drawing.Point(9, 24);
            this.textBoxSourceName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSourceName.Name = "textBoxSourceName";
            this.textBoxSourceName.Size = new System.Drawing.Size(216, 22);
            this.textBoxSourceName.TabIndex = 2;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(9, 7);
            this.labelSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(140, 17);
            this.labelSource.TabIndex = 3;
            this.labelSource.Text = "Enter a source name";
            // 
            // numericUpDownTimeInterval
            // 
            this.numericUpDownTimeInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTimeInterval.Location = new System.Drawing.Point(9, 67);
            this.numericUpDownTimeInterval.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTimeInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTimeInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTimeInterval.Name = "numericUpDownTimeInterval";
            this.numericUpDownTimeInterval.Size = new System.Drawing.Size(216, 22);
            this.numericUpDownTimeInterval.TabIndex = 4;
            this.numericUpDownTimeInterval.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // labelTimerRate
            // 
            this.labelTimerRate.AutoSize = true;
            this.labelTimerRate.Location = new System.Drawing.Point(6, 48);
            this.labelTimerRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimerRate.Name = "labelTimerRate";
            this.labelTimerRate.Size = new System.Drawing.Size(208, 17);
            this.labelTimerRate.TabIndex = 5;
            this.labelTimerRate.Text = "Time between transmitions (ms)";
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(9, 255);
            this.textBoxDebug.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.Size = new System.Drawing.Size(216, 145);
            this.textBoxDebug.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(233, 409);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.labelTimerRate);
            this.Controls.Add(this.numericUpDownTimeInterval);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.textBoxSourceName);
            this.Controls.Add(this.buttonStopSendingData);
            this.Controls.Add(this.buttonBeginSending);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "ModSim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBeginSending;
        private System.Windows.Forms.Button buttonStopSendingData;
        private System.Windows.Forms.Timer timerDataGenerationTicker;
        private System.Windows.Forms.TextBox textBoxSourceName;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeInterval;
        private System.Windows.Forms.Label labelTimerRate;
        private System.Windows.Forms.TextBox textBoxDebug;
    }
}

