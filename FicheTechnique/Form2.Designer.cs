namespace FicheTechnique
{
    partial class Form2
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.timerBattery = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.lbInitialCharge = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(218, 35);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(379, 64);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Battery Tester";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerBattery
            // 
            this.timerBattery.Interval = 1800000;
            this.timerBattery.Tick += new System.EventHandler(this.timerBattery_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(229, 350);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(158, 61);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbInitialCharge
            // 
            this.lbInitialCharge.AutoSize = true;
            this.lbInitialCharge.Location = new System.Drawing.Point(257, 193);
            this.lbInitialCharge.Name = "lbInitialCharge";
            this.lbInitialCharge.Size = new System.Drawing.Size(111, 13);
            this.lbInitialCharge.TabIndex = 2;
            this.lbInitialCharge.Text = "Initial battery charge : ";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(439, 350);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(158, 61);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbInitialCharge);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbTitle);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Timer timerBattery;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbInitialCharge;
        private System.Windows.Forms.Button btnStop;
    }
}