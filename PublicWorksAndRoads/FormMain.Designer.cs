namespace PublicWorksAndRoads
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonTestConnection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonTestConnection.Location = new System.Drawing.Point(24, 24);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(240, 32);
            this.buttonTestConnection.TabIndex = 0;
            this.buttonTestConnection.Text = "اختبار الاتصال بقاعدة البيانات";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.ButtonTestConnection_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.buttonTestConnection);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Public Works & Roads";
            this.ResumeLayout(false);
        }
    }
}