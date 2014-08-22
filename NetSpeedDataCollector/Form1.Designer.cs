namespace NetSpeedDataCollector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.InterfacePickerCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.downLabel = new System.Windows.Forms.Label();
            this.NetSpeedTimer = new System.Windows.Forms.Timer(this.components);
            this.NetDataInputTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // InterfacePickerCB
            // 
            this.InterfacePickerCB.FormattingEnabled = true;
            this.InterfacePickerCB.Location = new System.Drawing.Point(25, 29);
            this.InterfacePickerCB.Name = "InterfacePickerCB";
            this.InterfacePickerCB.Size = new System.Drawing.Size(114, 21);
            this.InterfacePickerCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Speed = ";
            // 
            // downLabel
            // 
            this.downLabel.AutoSize = true;
            this.downLabel.Location = new System.Drawing.Point(105, 74);
            this.downLabel.Name = "downLabel";
            this.downLabel.Size = new System.Drawing.Size(13, 13);
            this.downLabel.TabIndex = 3;
            this.downLabel.Text = "1";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 111);
            this.Controls.Add(this.downLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InterfacePickerCB);
            this.Name = "Form1";
            this.Text = "NetData";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox InterfacePickerCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label downLabel;
        private System.Windows.Forms.Timer NetDataInputTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

