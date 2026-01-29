namespace PublicWorksAndRoads
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Button buttonBuildingPermit;

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
            this.buttonBuildingPermit = new System.Windows.Forms.Button();
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
            // buttonBuildingPermit
            // 
            this.buttonBuildingPermit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonBuildingPermit.Location = new System.Drawing.Point(24, 70);
            this.buttonBuildingPermit.Name = "buttonBuildingPermit";
            this.buttonBuildingPermit.Size = new System.Drawing.Size(240, 32);
            this.buttonBuildingPermit.TabIndex = 1;
            this.buttonBuildingPermit.Text = "استمارة طلب ترخيص بناء";
            this.buttonBuildingPermit.UseVisualStyleBackColor = true;
            this.buttonBuildingPermit.Click += new System.EventHandler(this.ButtonBuildingPermit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.buttonBuildingPermit);
            this.Controls.Add(this.buttonTestConnection);
            this.Name = "FormMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Public Works & Roads";
            this.ResumeLayout(false);
        }
    }
}