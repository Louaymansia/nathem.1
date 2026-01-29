namespace PublicWorksAndRoads
{
    partial class FormBuildingPermit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageDirections;
        private System.Windows.Forms.TabPage tabPageSketch;
        private System.Windows.Forms.TabPage tabPageRecords;
        
        // Main tab controls
        private System.Windows.Forms.TextBox textBoxEntityName;
        private System.Windows.Forms.TextBox textBoxFormNumber;
        private System.Windows.Forms.TextBox textBoxApplicantName;
        private System.Windows.Forms.TextBox textBoxApplicantPhone;
        private System.Windows.Forms.TextBox textBoxLicenseType;
        private System.Windows.Forms.TextBox textBoxRegionName;
        private System.Windows.Forms.TextBox textBoxUnitName;
        private System.Windows.Forms.TextBox textBoxBuildFloor;
        private System.Windows.Forms.TextBox textBoxApplicantSignature;
        private System.Windows.Forms.TextBox textBoxAreaEngineerName;
        private System.Windows.Forms.TextBox textBoxAreaEngineerSignature;
        private System.Windows.Forms.TextBox textBoxReviewEngineerName;
        private System.Windows.Forms.TextBox textBoxReviewEngineerSignature;
        private System.Windows.Forms.TextBox textBoxLandAreaSurvey;
        private System.Windows.Forms.TextBox textBoxLandAreaProjection;
        private System.Windows.Forms.TextBox textBoxBuildingArea;
        private System.Windows.Forms.TextBox textBoxExistingBuilding;
        private System.Windows.Forms.TextBox textBoxLicensedMaterialPrev;
        private System.Windows.Forms.TextBox textBoxLicensePurpose;
        private System.Windows.Forms.TextBox textBoxBlockType;
        private System.Windows.Forms.TextBox textBoxFloorsToLicense;
        private System.Windows.Forms.TextBox textBoxLicensedMaterial;
        private System.Windows.Forms.TextBox textBoxPreviousShopOpenings;
        private System.Windows.Forms.TextBox textBoxRequestedShopOpenings;
        private System.Windows.Forms.TextBox textBoxParkingAreaTotal;
        private System.Windows.Forms.TextBox textBoxLandLayer;
        private System.Windows.Forms.TextBox textBoxCurb;
        private System.Windows.Forms.TextBox textBoxMiddleSetback;
        private System.Windows.Forms.TextBox textBoxLandLocationFromFlood;

        // Direction controls - North
        private System.Windows.Forms.TextBox textBoxNorthLandBoundary;
        private System.Windows.Forms.TextBox textBoxNorthLandDimension;
        private System.Windows.Forms.TextBox textBoxNorthBuildingDimension;
        private System.Windows.Forms.TextBox textBoxNorthBuildingSetback;
        private System.Windows.Forms.TextBox textBoxNorthStreetType;
        private System.Windows.Forms.TextBox textBoxNorthStreetNumber;
        private System.Windows.Forms.TextBox textBoxNorthStreetWidth;
        private System.Windows.Forms.TextBox textBoxNorthParkingBoundary;
        private System.Windows.Forms.TextBox textBoxNorthParkingDimension;
        private System.Windows.Forms.TextBox textBoxNorthParkingArea;

        // Direction controls - South
        private System.Windows.Forms.TextBox textBoxSouthLandBoundary;
        private System.Windows.Forms.TextBox textBoxSouthLandDimension;
        private System.Windows.Forms.TextBox textBoxSouthBuildingDimension;
        private System.Windows.Forms.TextBox textBoxSouthBuildingSetback;
        private System.Windows.Forms.TextBox textBoxSouthStreetType;
        private System.Windows.Forms.TextBox textBoxSouthStreetNumber;
        private System.Windows.Forms.TextBox textBoxSouthStreetWidth;
        private System.Windows.Forms.TextBox textBoxSouthParkingBoundary;
        private System.Windows.Forms.TextBox textBoxSouthParkingDimension;
        private System.Windows.Forms.TextBox textBoxSouthParkingArea;

        // Direction controls - East
        private System.Windows.Forms.TextBox textBoxEastLandBoundary;
        private System.Windows.Forms.TextBox textBoxEastLandDimension;
        private System.Windows.Forms.TextBox textBoxEastBuildingDimension;
        private System.Windows.Forms.TextBox textBoxEastBuildingSetback;
        private System.Windows.Forms.TextBox textBoxEastStreetType;
        private System.Windows.Forms.TextBox textBoxEastStreetNumber;
        private System.Windows.Forms.TextBox textBoxEastStreetWidth;
        private System.Windows.Forms.TextBox textBoxEastParkingBoundary;
        private System.Windows.Forms.TextBox textBoxEastParkingDimension;
        private System.Windows.Forms.TextBox textBoxEastParkingArea;

        // Direction controls - West
        private System.Windows.Forms.TextBox textBoxWestLandBoundary;
        private System.Windows.Forms.TextBox textBoxWestLandDimension;
        private System.Windows.Forms.TextBox textBoxWestBuildingDimension;
        private System.Windows.Forms.TextBox textBoxWestBuildingSetback;
        private System.Windows.Forms.TextBox textBoxWestStreetType;
        private System.Windows.Forms.TextBox textBoxWestNumber;
        private System.Windows.Forms.TextBox textBoxWestStreetWidth;
        private System.Windows.Forms.TextBox textBoxWestParkingBoundary;
        private System.Windows.Forms.TextBox textBoxWestParkingDimension;
        private System.Windows.Forms.TextBox textBoxWestParkingArea;

        // Sketch controls
        private System.Windows.Forms.TextBox textBoxSketchType;
        private System.Windows.Forms.TextBox textBoxSketchPath;
        private System.Windows.Forms.PictureBox pictureBoxSketch;
        private System.Windows.Forms.Button buttonBrowseSketch;

        // Records tab controls
        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;

        // Action buttons
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPrint;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageDirections = new System.Windows.Forms.TabPage();
            this.tabPageSketch = new System.Windows.Forms.TabPage();
            this.tabPageRecords = new System.Windows.Forms.TabPage();
            
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            
            InitializeMainTab();
            InitializeDirectionsTab();
            InitializeSketchTab();
            InitializeRecordsTab();
            
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            
            // TabControl
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageDirections);
            this.tabControl.Controls.Add(this.tabPageSketch);
            this.tabControl.Controls.Add(this.tabPageRecords);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 650);
            this.tabControl.TabIndex = 0;
            
            // TabPages
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1192, 622);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "البيانات الأساسية";
            this.tabPageMain.UseVisualStyleBackColor = true;
            
            this.tabPageDirections.Location = new System.Drawing.Point(4, 24);
            this.tabPageDirections.Name = "tabPageDirections";
            this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDirections.Size = new System.Drawing.Size(1192, 622);
            this.tabPageDirections.TabIndex = 1;
            this.tabPageDirections.Text = "الاتجاهات";
            this.tabPageDirections.UseVisualStyleBackColor = true;
            
            this.tabPageSketch.Location = new System.Drawing.Point(4, 24);
            this.tabPageSketch.Name = "tabPageSketch";
            this.tabPageSketch.Size = new System.Drawing.Size(1192, 622);
            this.tabPageSketch.TabIndex = 2;
            this.tabPageSketch.Text = "الكروكي";
            this.tabPageSketch.UseVisualStyleBackColor = true;
            
            this.tabPageRecords.Location = new System.Drawing.Point(4, 24);
            this.tabPageRecords.Name = "tabPageRecords";
            this.tabPageRecords.Size = new System.Drawing.Size(1192, 622);
            this.tabPageRecords.TabIndex = 3;
            this.tabPageRecords.Text = "السجلات";
            this.tabPageRecords.UseVisualStyleBackColor = true;
            
            // Buttons at bottom
            this.buttonNew.Location = new System.Drawing.Point(950, 660);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(100, 30);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "جديد";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            
            this.buttonSave.Location = new System.Drawing.Point(840, 660);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "حفظ";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            
            this.buttonDelete.Location = new System.Drawing.Point(730, 660);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 30);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "حذف";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            
            this.buttonPrint.Location = new System.Drawing.Point(620, 660);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(100, 30);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.Text = "طباعة";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            
            // FormBuildingPermit
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.tabControl);
            this.Name = "FormBuildingPermit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "استمارة طلب ترخيص بناء";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void InitializeMainTab()
        {
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.AutoScroll = true;
            
            int y = 10;
            int labelX = 900;
            int textBoxX = 600;
            int width = 280;
            
            // Entity and Form Info
            AddLabelAndTextBox(panel, "اسم الجهة:", ref textBoxEntityName, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "رقم الاستمارة:", ref textBoxFormNumber, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "اسم مقدم الطلب:", ref textBoxApplicantName, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "رقم الهاتف:", ref textBoxApplicantPhone, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "نوع الترخيص:", ref textBoxLicenseType, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "اسم المنطقة:", ref textBoxRegionName, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "اسم الوحدة:", ref textBoxUnitName, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "الطابق:", ref textBoxBuildFloor, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "توقيع مقدم الطلب:", ref textBoxApplicantSignature, labelX, ref y, textBoxX, width);
            
            y += 10;
            AddGroupLabel(panel, "بيانات المهندسين", labelX, ref y);
            AddLabelAndTextBox(panel, "اسم مهندس المنطقة:", ref textBoxAreaEngineerName, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "توقيع مهندس المنطقة:", ref textBoxAreaEngineerSignature, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "اسم مهندس المراجعة:", ref textBoxReviewEngineerName, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "توقيع مهندس المراجعة:", ref textBoxReviewEngineerSignature, labelX, ref y, textBoxX, width);
            
            y += 10;
            AddGroupLabel(panel, "بيانات الأرض والبناء", labelX, ref y);
            AddLabelAndTextBox(panel, "مساحة الأرض (مساحي):", ref textBoxLandAreaSurvey, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "مساحة الأرض (إسقاط):", ref textBoxLandAreaProjection, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "مساحة البناء:", ref textBoxBuildingArea, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "البناء القائم:", ref textBoxExistingBuilding, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "مواد مرخصة سابقاً:", ref textBoxLicensedMaterialPrev, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "الغرض من الترخيص:", ref textBoxLicensePurpose, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "نوع القطعة:", ref textBoxBlockType, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "الطوابق المراد ترخيصها:", ref textBoxFloorsToLicense, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "المواد المرخصة:", ref textBoxLicensedMaterial, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "فتحات المحلات السابقة:", ref textBoxPreviousShopOpenings, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "فتحات المحلات المطلوبة:", ref textBoxRequestedShopOpenings, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "مساحة الموقف الإجمالية:", ref textBoxParkingAreaTotal, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "طبقة الأرض:", ref textBoxLandLayer, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "الرصيف:", ref textBoxCurb, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "الارتداد الأوسط:", ref textBoxMiddleSetback, labelX, ref y, textBoxX, width);
            AddLabelAndTextBox(panel, "موقع الأرض من السيل:", ref textBoxLandLocationFromFlood, labelX, ref y, textBoxX, width);
            
            this.tabPageMain.Controls.Add(panel);
        }

        private void InitializeDirectionsTab()
        {
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.AutoScroll = true;
            
            int y = 10;
            int col1X = 900;
            int col2X = 450;
            int textBoxX1 = 700;
            int textBoxX2 = 250;
            int width = 180;
            
            // North Direction
            AddGroupLabel(panel, "الجهة الشمالية", col1X, ref y);
            AddLabelAndTextBox(panel, "حدود الأرض:", ref textBoxNorthLandBoundary, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "بعد الأرض:", ref textBoxNorthLandDimension, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "بعد البناء:", ref textBoxNorthBuildingDimension, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "الارتداد:", ref textBoxNorthBuildingSetback, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "نوع الشارع:", ref textBoxNorthStreetType, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "رقم الشارع:", ref textBoxNorthStreetNumber, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "عرض الشارع:", ref textBoxNorthStreetWidth, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "حدود الموقف:", ref textBoxNorthParkingBoundary, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "بعد الموقف:", ref textBoxNorthParkingDimension, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "مساحة الموقف:", ref textBoxNorthParkingArea, col1X, ref y, textBoxX1, width);
            
            y = 10;
            // South Direction
            AddGroupLabel(panel, "الجهة الجنوبية", col2X, ref y);
            AddLabelAndTextBox(panel, "حدود الأرض:", ref textBoxSouthLandBoundary, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "بعد الأرض:", ref textBoxSouthLandDimension, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "بعد البناء:", ref textBoxSouthBuildingDimension, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "الارتداد:", ref textBoxSouthBuildingSetback, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "نوع الشارع:", ref textBoxSouthStreetType, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "رقم الشارع:", ref textBoxSouthStreetNumber, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "عرض الشارع:", ref textBoxSouthStreetWidth, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "حدود الموقف:", ref textBoxSouthParkingBoundary, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "بعد الموقف:", ref textBoxSouthParkingDimension, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "مساحة الموقف:", ref textBoxSouthParkingArea, col2X, ref y, textBoxX2, width);
            
            y += 20;
            // East Direction
            AddGroupLabel(panel, "الجهة الشرقية", col1X, ref y);
            AddLabelAndTextBox(panel, "حدود الأرض:", ref textBoxEastLandBoundary, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "بعد الأرض:", ref textBoxEastLandDimension, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "بعد البناء:", ref textBoxEastBuildingDimension, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "الارتداد:", ref textBoxEastBuildingSetback, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "نوع الشارع:", ref textBoxEastStreetType, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "رقم الشارع:", ref textBoxEastStreetNumber, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "عرض الشارع:", ref textBoxEastStreetWidth, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "حدود الموقف:", ref textBoxEastParkingBoundary, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "بعد الموقف:", ref textBoxEastParkingDimension, col1X, ref y, textBoxX1, width);
            AddLabelAndTextBox(panel, "مساحة الموقف:", ref textBoxEastParkingArea, col1X, ref y, textBoxX1, width);
            
            int prevY = y;
            y = prevY - 30 * 10;
            // West Direction
            AddGroupLabel(panel, "الجهة الغربية", col2X, ref y);
            AddLabelAndTextBox(panel, "حدود الأرض:", ref textBoxWestLandBoundary, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "بعد الأرض:", ref textBoxWestLandDimension, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "بعد البناء:", ref textBoxWestBuildingDimension, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "الارتداد:", ref textBoxWestBuildingSetback, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "نوع الشارع:", ref textBoxWestStreetType, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "رقم الشارع:", ref textBoxWestNumber, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "عرض الشارع:", ref textBoxWestStreetWidth, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "حدود الموقف:", ref textBoxWestParkingBoundary, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "بعد الموقف:", ref textBoxWestParkingDimension, col2X, ref y, textBoxX2, width);
            AddLabelAndTextBox(panel, "مساحة الموقف:", ref textBoxWestParkingArea, col2X, ref y, textBoxX2, width);
            
            this.tabPageDirections.Controls.Add(panel);
        }

        private void InitializeSketchTab()
        {
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            
            int y = 20;
            
            var labelType = new System.Windows.Forms.Label();
            labelType.Text = "نوع الكروكي:";
            labelType.Location = new System.Drawing.Point(900, y);
            labelType.AutoSize = true;
            panel.Controls.Add(labelType);
            
            textBoxSketchType = new System.Windows.Forms.TextBox();
            textBoxSketchType.Location = new System.Drawing.Point(600, y);
            textBoxSketchType.Size = new System.Drawing.Size(280, 23);
            panel.Controls.Add(textBoxSketchType);
            
            y += 35;
            
            var labelPath = new System.Windows.Forms.Label();
            labelPath.Text = "مسار الصورة:";
            labelPath.Location = new System.Drawing.Point(900, y);
            labelPath.AutoSize = true;
            panel.Controls.Add(labelPath);
            
            textBoxSketchPath = new System.Windows.Forms.TextBox();
            textBoxSketchPath.Location = new System.Drawing.Point(600, y);
            textBoxSketchPath.Size = new System.Drawing.Size(280, 23);
            textBoxSketchPath.ReadOnly = true;
            panel.Controls.Add(textBoxSketchPath);
            
            buttonBrowseSketch = new System.Windows.Forms.Button();
            buttonBrowseSketch.Text = "...";
            buttonBrowseSketch.Location = new System.Drawing.Point(550, y);
            buttonBrowseSketch.Size = new System.Drawing.Size(40, 23);
            buttonBrowseSketch.Click += new System.EventHandler(this.ButtonBrowseSketch_Click);
            panel.Controls.Add(buttonBrowseSketch);
            
            y += 35;
            
            pictureBoxSketch = new System.Windows.Forms.PictureBox();
            pictureBoxSketch.Location = new System.Drawing.Point(50, y);
            pictureBoxSketch.Size = new System.Drawing.Size(1000, 500);
            pictureBoxSketch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxSketch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            panel.Controls.Add(pictureBoxSketch);
            
            this.tabPageSketch.Controls.Add(panel);
        }

        private void InitializeRecordsTab()
        {
            var panel = new System.Windows.Forms.Panel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            
            var labelSearch = new System.Windows.Forms.Label();
            labelSearch.Text = "بحث:";
            labelSearch.Location = new System.Drawing.Point(950, 20);
            labelSearch.AutoSize = true;
            panel.Controls.Add(labelSearch);
            
            textBoxSearch = new System.Windows.Forms.TextBox();
            textBoxSearch.Location = new System.Drawing.Point(650, 17);
            textBoxSearch.Size = new System.Drawing.Size(280, 23);
            panel.Controls.Add(textBoxSearch);
            
            buttonSearch = new System.Windows.Forms.Button();
            buttonSearch.Text = "بحث";
            buttonSearch.Location = new System.Drawing.Point(550, 15);
            buttonSearch.Size = new System.Drawing.Size(90, 27);
            buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            panel.Controls.Add(buttonSearch);
            
            dataGridViewRecords = new System.Windows.Forms.DataGridView();
            dataGridViewRecords.Location = new System.Drawing.Point(20, 60);
            dataGridViewRecords.Size = new System.Drawing.Size(1150, 540);
            dataGridViewRecords.AllowUserToAddRows = false;
            dataGridViewRecords.AllowUserToDeleteRows = false;
            dataGridViewRecords.ReadOnly = true;
            dataGridViewRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRecords_CellDoubleClick);
            panel.Controls.Add(dataGridViewRecords);
            
            this.tabPageRecords.Controls.Add(panel);
        }

        private void AddGroupLabel(System.Windows.Forms.Panel panel, string text, int x, ref int y)
        {
            var label = new System.Windows.Forms.Label();
            label.Text = text;
            label.Location = new System.Drawing.Point(x, y);
            label.AutoSize = true;
            label.Font = new System.Drawing.Font(label.Font, System.Drawing.FontStyle.Bold);
            panel.Controls.Add(label);
            y += 30;
        }

        private void AddLabelAndTextBox(System.Windows.Forms.Panel panel, string labelText, ref System.Windows.Forms.TextBox textBox, int labelX, ref int y, int textBoxX, int width)
        {
            var label = new System.Windows.Forms.Label();
            label.Text = labelText;
            label.Location = new System.Drawing.Point(labelX, y);
            label.AutoSize = true;
            panel.Controls.Add(label);
            
            textBox = new System.Windows.Forms.TextBox();
            textBox.Location = new System.Drawing.Point(textBoxX, y);
            textBox.Size = new System.Drawing.Size(width, 23);
            panel.Controls.Add(textBox);
            
            y += 30;
        }
    }
}
