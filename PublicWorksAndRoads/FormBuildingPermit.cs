using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PublicWorksAndRoads.Models;
using PublicWorksAndRoads.Repositories;

namespace PublicWorksAndRoads
{
    public partial class FormBuildingPermit : Form
    {
        private readonly BuildingPermitRepository _permitRepository;
        private readonly LandDirectionRepository _directionRepository;
        private readonly SketchRepository _sketchRepository;
        private int _currentRequestId;
        private bool _isEditMode;

        public FormBuildingPermit()
        {
            InitializeComponent();
            _permitRepository = new BuildingPermitRepository();
            _directionRepository = new LandDirectionRepository();
            _sketchRepository = new SketchRepository();
            LoadAllRecords();
        }

        private void LoadAllRecords()
        {
            try
            {
                var records = _permitRepository.GetAll();
                dataGridViewRecords.DataSource = records;
                ConfigureGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل السجلات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            if (dataGridViewRecords.Columns.Count > 0)
            {
                dataGridViewRecords.Columns["RequestId"].HeaderText = "رقم الطلب";
                dataGridViewRecords.Columns["FormNumber"].HeaderText = "رقم الاستمارة";
                dataGridViewRecords.Columns["ApplicantName"].HeaderText = "اسم مقدم الطلب";
                dataGridViewRecords.Columns["ApplicantPhone"].HeaderText = "رقم الهاتف";
                dataGridViewRecords.Columns["CreatedAt"].HeaderText = "تاريخ الإنشاء";
                
                dataGridViewRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRecords.MultiSelect = false;
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            _isEditMode = false;
            _currentRequestId = 0;
            EnableFormFields(true);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxFormNumber.Text))
                {
                    MessageBox.Show("يرجى إدخال رقم الاستمارة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var request = new BuildingPermitRequest
                {
                    EntityName = textBoxEntityName.Text,
                    FormNumber = textBoxFormNumber.Text,
                    ApplicantName = textBoxApplicantName.Text,
                    ApplicantPhone = textBoxApplicantPhone.Text,
                    LicenseType = textBoxLicenseType.Text,
                    RegionName = textBoxRegionName.Text,
                    UnitName = textBoxUnitName.Text,
                    BuildFloor = textBoxBuildFloor.Text,
                    ApplicantSignature = textBoxApplicantSignature.Text,
                    AreaEngineerName = textBoxAreaEngineerName.Text,
                    AreaEngineerSignature = textBoxAreaEngineerSignature.Text,
                    ReviewEngineerName = textBoxReviewEngineerName.Text,
                    ReviewEngineerSignature = textBoxReviewEngineerSignature.Text,
                    LandAreaSurvey = string.IsNullOrWhiteSpace(textBoxLandAreaSurvey.Text) ? (decimal?)null : decimal.Parse(textBoxLandAreaSurvey.Text),
                    LandAreaProjection = string.IsNullOrWhiteSpace(textBoxLandAreaProjection.Text) ? (decimal?)null : decimal.Parse(textBoxLandAreaProjection.Text),
                    BuildingArea = string.IsNullOrWhiteSpace(textBoxBuildingArea.Text) ? (decimal?)null : decimal.Parse(textBoxBuildingArea.Text),
                    ExistingBuilding = textBoxExistingBuilding.Text,
                    LicensedMaterialPrev = textBoxLicensedMaterialPrev.Text,
                    LicensePurpose = textBoxLicensePurpose.Text,
                    BlockType = textBoxBlockType.Text,
                    FloorsToLicense = textBoxFloorsToLicense.Text,
                    LicensedMaterial = textBoxLicensedMaterial.Text,
                    PreviousShopOpenings = string.IsNullOrWhiteSpace(textBoxPreviousShopOpenings.Text) ? (int?)null : int.Parse(textBoxPreviousShopOpenings.Text),
                    RequestedShopOpenings = string.IsNullOrWhiteSpace(textBoxRequestedShopOpenings.Text) ? (int?)null : int.Parse(textBoxRequestedShopOpenings.Text),
                    ParkingAreaTotal = string.IsNullOrWhiteSpace(textBoxParkingAreaTotal.Text) ? (decimal?)null : decimal.Parse(textBoxParkingAreaTotal.Text),
                    LandLayer = textBoxLandLayer.Text,
                    Curb = textBoxCurb.Text,
                    MiddleSetback = textBoxMiddleSetback.Text,
                    LandLocationFromFlood = textBoxLandLocationFromFlood.Text,
                    CreatedAt = DateTime.Now
                };

                if (_isEditMode && _currentRequestId > 0)
                {
                    request.RequestId = _currentRequestId;
                    _permitRepository.Update(request);
                    
                    // Update directions
                    _directionRepository.DeleteByRequestId(_currentRequestId);
                    SaveDirections(_currentRequestId);
                    
                    // Update sketch
                    _sketchRepository.DeleteByRequestId(_currentRequestId);
                    SaveSketch(_currentRequestId);
                    
                    MessageBox.Show("تم تحديث الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var requestId = _permitRepository.Insert(request);
                    _currentRequestId = requestId;
                    
                    // Save directions
                    SaveDirections(requestId);
                    
                    // Save sketch
                    SaveSketch(requestId);
                    
                    MessageBox.Show("تم حفظ الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _isEditMode = true;
                }

                LoadAllRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDirections(int requestId)
        {
            SaveDirection(requestId, "شمال", textBoxNorthLandBoundary, textBoxNorthLandDimension, textBoxNorthBuildingDimension,
                textBoxNorthBuildingSetback, textBoxNorthStreetType, textBoxNorthStreetNumber, textBoxNorthStreetWidth,
                textBoxNorthParkingBoundary, textBoxNorthParkingDimension, textBoxNorthParkingArea);

            SaveDirection(requestId, "جنوب", textBoxSouthLandBoundary, textBoxSouthLandDimension, textBoxSouthBuildingDimension,
                textBoxSouthBuildingSetback, textBoxSouthStreetType, textBoxSouthStreetNumber, textBoxSouthStreetWidth,
                textBoxSouthParkingBoundary, textBoxSouthParkingDimension, textBoxSouthParkingArea);

            SaveDirection(requestId, "شرق", textBoxEastLandBoundary, textBoxEastLandDimension, textBoxEastBuildingDimension,
                textBoxEastBuildingSetback, textBoxEastStreetType, textBoxEastStreetNumber, textBoxEastStreetWidth,
                textBoxEastParkingBoundary, textBoxEastParkingDimension, textBoxEastParkingArea);

            SaveDirection(requestId, "غرب", textBoxWestLandBoundary, textBoxWestLandDimension, textBoxWestBuildingDimension,
                textBoxWestBuildingSetback, textBoxWestStreetType, textBoxWestStreetNumber, textBoxWestStreetWidth,
                textBoxWestParkingBoundary, textBoxWestParkingDimension, textBoxWestParkingArea);
        }

        private void SaveDirection(int requestId, string directionName,
            TextBox landBoundary, TextBox landDimension, TextBox buildingDimension,
            TextBox buildingSetback, TextBox streetType, TextBox streetNumber, TextBox streetWidth,
            TextBox parkingBoundary, TextBox parkingDimension, TextBox parkingArea)
        {
            var direction = new LandDirection
            {
                RequestId = requestId,
                DirectionName = directionName,
                LandBoundary = landBoundary.Text,
                LandDimension = string.IsNullOrWhiteSpace(landDimension.Text) ? (decimal?)null : decimal.Parse(landDimension.Text),
                BuildingDimension = string.IsNullOrWhiteSpace(buildingDimension.Text) ? (decimal?)null : decimal.Parse(buildingDimension.Text),
                BuildingSetback = string.IsNullOrWhiteSpace(buildingSetback.Text) ? (decimal?)null : decimal.Parse(buildingSetback.Text),
                StreetType = streetType.Text,
                StreetNumber = streetNumber.Text,
                StreetWidth = string.IsNullOrWhiteSpace(streetWidth.Text) ? (decimal?)null : decimal.Parse(streetWidth.Text),
                ParkingBoundary = parkingBoundary.Text,
                ParkingDimension = string.IsNullOrWhiteSpace(parkingDimension.Text) ? (decimal?)null : decimal.Parse(parkingDimension.Text),
                ParkingArea = string.IsNullOrWhiteSpace(parkingArea.Text) ? (decimal?)null : decimal.Parse(parkingArea.Text)
            };

            _directionRepository.Insert(direction);
        }

        private void SaveSketch(int requestId)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSketchPath.Text) && File.Exists(textBoxSketchPath.Text))
            {
                var sketch = new Sketch
                {
                    RequestId = requestId,
                    SketchType = textBoxSketchType.Text,
                    SketchImage = File.ReadAllBytes(textBoxSketchPath.Text)
                };
                _sketchRepository.Insert(sketch);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_currentRequestId <= 0)
            {
                MessageBox.Show("يرجى اختيار سجل للحذف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _permitRepository.Delete(_currentRequestId);
                    MessageBox.Show("تم حذف السجل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadAllRecords();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ في حذف السجل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                LoadAllRecords();
                return;
            }

            try
            {
                var results = _permitRepository.Search(textBoxSearch.Text);
                dataGridViewRecords.DataSource = results;
                ConfigureGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في البحث: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadRecord(e.RowIndex);
            }
        }

        private void LoadRecord(int rowIndex)
        {
            try
            {
                var requestId = Convert.ToInt32(dataGridViewRecords.Rows[rowIndex].Cells["RequestId"].Value);
                var request = _permitRepository.GetById(requestId);

                if (request != null)
                {
                    _currentRequestId = request.RequestId;
                    _isEditMode = true;

                    textBoxEntityName.Text = request.EntityName;
                    textBoxFormNumber.Text = request.FormNumber;
                    textBoxApplicantName.Text = request.ApplicantName;
                    textBoxApplicantPhone.Text = request.ApplicantPhone;
                    textBoxLicenseType.Text = request.LicenseType;
                    textBoxRegionName.Text = request.RegionName;
                    textBoxUnitName.Text = request.UnitName;
                    textBoxBuildFloor.Text = request.BuildFloor;
                    textBoxApplicantSignature.Text = request.ApplicantSignature;
                    textBoxAreaEngineerName.Text = request.AreaEngineerName;
                    textBoxAreaEngineerSignature.Text = request.AreaEngineerSignature;
                    textBoxReviewEngineerName.Text = request.ReviewEngineerName;
                    textBoxReviewEngineerSignature.Text = request.ReviewEngineerSignature;
                    textBoxLandAreaSurvey.Text = request.LandAreaSurvey?.ToString() ?? "";
                    textBoxLandAreaProjection.Text = request.LandAreaProjection?.ToString() ?? "";
                    textBoxBuildingArea.Text = request.BuildingArea?.ToString() ?? "";
                    textBoxExistingBuilding.Text = request.ExistingBuilding;
                    textBoxLicensedMaterialPrev.Text = request.LicensedMaterialPrev;
                    textBoxLicensePurpose.Text = request.LicensePurpose;
                    textBoxBlockType.Text = request.BlockType;
                    textBoxFloorsToLicense.Text = request.FloorsToLicense;
                    textBoxLicensedMaterial.Text = request.LicensedMaterial;
                    textBoxPreviousShopOpenings.Text = request.PreviousShopOpenings?.ToString() ?? "";
                    textBoxRequestedShopOpenings.Text = request.RequestedShopOpenings?.ToString() ?? "";
                    textBoxParkingAreaTotal.Text = request.ParkingAreaTotal?.ToString() ?? "";
                    textBoxLandLayer.Text = request.LandLayer;
                    textBoxCurb.Text = request.Curb;
                    textBoxMiddleSetback.Text = request.MiddleSetback;
                    textBoxLandLocationFromFlood.Text = request.LandLocationFromFlood;

                    LoadDirections(requestId);
                    LoadSketch(requestId);
                    EnableFormFields(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل السجل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDirections(int requestId)
        {
            var directions = _directionRepository.GetByRequestId(requestId);
            
            foreach (var direction in directions)
            {
                switch (direction.DirectionName)
                {
                    case "شمال":
                        LoadDirectionData(direction, textBoxNorthLandBoundary, textBoxNorthLandDimension, textBoxNorthBuildingDimension,
                            textBoxNorthBuildingSetback, textBoxNorthStreetType, textBoxNorthStreetNumber, textBoxNorthStreetWidth,
                            textBoxNorthParkingBoundary, textBoxNorthParkingDimension, textBoxNorthParkingArea);
                        break;
                    case "جنوب":
                        LoadDirectionData(direction, textBoxSouthLandBoundary, textBoxSouthLandDimension, textBoxSouthBuildingDimension,
                            textBoxSouthBuildingSetback, textBoxSouthStreetType, textBoxSouthStreetNumber, textBoxSouthStreetWidth,
                            textBoxSouthParkingBoundary, textBoxSouthParkingDimension, textBoxSouthParkingArea);
                        break;
                    case "شرق":
                        LoadDirectionData(direction, textBoxEastLandBoundary, textBoxEastLandDimension, textBoxEastBuildingDimension,
                            textBoxEastBuildingSetback, textBoxEastStreetType, textBoxEastStreetNumber, textBoxEastStreetWidth,
                            textBoxEastParkingBoundary, textBoxEastParkingDimension, textBoxEastParkingArea);
                        break;
                    case "غرب":
                        LoadDirectionData(direction, textBoxWestLandBoundary, textBoxWestLandDimension, textBoxWestBuildingDimension,
                            textBoxWestBuildingSetback, textBoxWestStreetType, textBoxWestNumber, textBoxWestStreetWidth,
                            textBoxWestParkingBoundary, textBoxWestParkingDimension, textBoxWestParkingArea);
                        break;
                }
            }
        }

        private void LoadDirectionData(LandDirection direction,
            TextBox landBoundary, TextBox landDimension, TextBox buildingDimension,
            TextBox buildingSetback, TextBox streetType, TextBox streetNumber, TextBox streetWidth,
            TextBox parkingBoundary, TextBox parkingDimension, TextBox parkingArea)
        {
            landBoundary.Text = direction.LandBoundary;
            landDimension.Text = direction.LandDimension?.ToString() ?? "";
            buildingDimension.Text = direction.BuildingDimension?.ToString() ?? "";
            buildingSetback.Text = direction.BuildingSetback?.ToString() ?? "";
            streetType.Text = direction.StreetType;
            streetNumber.Text = direction.StreetNumber;
            streetWidth.Text = direction.StreetWidth?.ToString() ?? "";
            parkingBoundary.Text = direction.ParkingBoundary;
            parkingDimension.Text = direction.ParkingDimension?.ToString() ?? "";
            parkingArea.Text = direction.ParkingArea?.ToString() ?? "";
        }

        private void LoadSketch(int requestId)
        {
            var sketches = _sketchRepository.GetByRequestId(requestId);
            if (sketches.Any())
            {
                var sketch = sketches.First();
                textBoxSketchType.Text = sketch.SketchType;
                if (sketch.SketchImage != null && sketch.SketchImage.Length > 0)
                {
                    using (var ms = new MemoryStream(sketch.SketchImage))
                    {
                        pictureBoxSketch.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void ButtonBrowseSketch_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "اختر صورة الكروكي";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxSketchPath.Text = openFileDialog.FileName;
                    pictureBoxSketch.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            if (_currentRequestId <= 0)
            {
                MessageBox.Show("يرجى اختيار سجل للطباعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                
                var printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في الطباعة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var font = new Font("Arial", 10);
            var titleFont = new Font("Arial", 14, FontStyle.Bold);
            var y = 50;
            var lineHeight = 20;

            g.DrawString("استمارة طلب ترخيص بناء", titleFont, Brushes.Black, 300, y);
            y += 40;

            g.DrawString($"رقم الاستمارة: {textBoxFormNumber.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"اسم الجهة: {textBoxEntityName.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"اسم مقدم الطلب: {textBoxApplicantName.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"رقم الهاتف: {textBoxApplicantPhone.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"نوع الترخيص: {textBoxLicenseType.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"اسم المنطقة: {textBoxRegionName.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            
            y += 10;
            g.DrawString("بيانات المهندسين:", titleFont, Brushes.Black, 50, y);
            y += 30;
            g.DrawString($"مهندس المنطقة: {textBoxAreaEngineerName.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"مهندس المراجعة: {textBoxReviewEngineerName.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;

            y += 10;
            g.DrawString("بيانات الأرض والبناء:", titleFont, Brushes.Black, 50, y);
            y += 30;
            g.DrawString($"مساحة الأرض (مساحي): {textBoxLandAreaSurvey.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"مساحة الأرض (إسقاط): {textBoxLandAreaProjection.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
            g.DrawString($"مساحة البناء: {textBoxBuildingArea.Text}", font, Brushes.Black, 50, y);
            y += lineHeight;
        }

        private void ClearForm()
        {
            textBoxEntityName.Clear();
            textBoxFormNumber.Clear();
            textBoxApplicantName.Clear();
            textBoxApplicantPhone.Clear();
            textBoxLicenseType.Clear();
            textBoxRegionName.Clear();
            textBoxUnitName.Clear();
            textBoxBuildFloor.Clear();
            textBoxApplicantSignature.Clear();
            textBoxAreaEngineerName.Clear();
            textBoxAreaEngineerSignature.Clear();
            textBoxReviewEngineerName.Clear();
            textBoxReviewEngineerSignature.Clear();
            textBoxLandAreaSurvey.Clear();
            textBoxLandAreaProjection.Clear();
            textBoxBuildingArea.Clear();
            textBoxExistingBuilding.Clear();
            textBoxLicensedMaterialPrev.Clear();
            textBoxLicensePurpose.Clear();
            textBoxBlockType.Clear();
            textBoxFloorsToLicense.Clear();
            textBoxLicensedMaterial.Clear();
            textBoxPreviousShopOpenings.Clear();
            textBoxRequestedShopOpenings.Clear();
            textBoxParkingAreaTotal.Clear();
            textBoxLandLayer.Clear();
            textBoxCurb.Clear();
            textBoxMiddleSetback.Clear();
            textBoxLandLocationFromFlood.Clear();

            // Clear directions
            ClearDirectionFields(textBoxNorthLandBoundary, textBoxNorthLandDimension, textBoxNorthBuildingDimension,
                textBoxNorthBuildingSetback, textBoxNorthStreetType, textBoxNorthStreetNumber, textBoxNorthStreetWidth,
                textBoxNorthParkingBoundary, textBoxNorthParkingDimension, textBoxNorthParkingArea);

            ClearDirectionFields(textBoxSouthLandBoundary, textBoxSouthLandDimension, textBoxSouthBuildingDimension,
                textBoxSouthBuildingSetback, textBoxSouthStreetType, textBoxSouthStreetNumber, textBoxSouthStreetWidth,
                textBoxSouthParkingBoundary, textBoxSouthParkingDimension, textBoxSouthParkingArea);

            ClearDirectionFields(textBoxEastLandBoundary, textBoxEastLandDimension, textBoxEastBuildingDimension,
                textBoxEastBuildingSetback, textBoxEastStreetType, textBoxEastStreetNumber, textBoxEastStreetWidth,
                textBoxEastParkingBoundary, textBoxEastParkingDimension, textBoxEastParkingArea);

            ClearDirectionFields(textBoxWestLandBoundary, textBoxWestLandDimension, textBoxWestBuildingDimension,
                textBoxWestBuildingSetback, textBoxWestStreetType, textBoxWestNumber, textBoxWestStreetWidth,
                textBoxWestParkingBoundary, textBoxWestParkingDimension, textBoxWestParkingArea);

            textBoxSketchType.Clear();
            textBoxSketchPath.Clear();
            pictureBoxSketch.Image = null;

            _currentRequestId = 0;
            _isEditMode = false;
        }

        private void ClearDirectionFields(TextBox landBoundary, TextBox landDimension, TextBox buildingDimension,
            TextBox buildingSetback, TextBox streetType, TextBox streetNumber, TextBox streetWidth,
            TextBox parkingBoundary, TextBox parkingDimension, TextBox parkingArea)
        {
            landBoundary.Clear();
            landDimension.Clear();
            buildingDimension.Clear();
            buildingSetback.Clear();
            streetType.Clear();
            streetNumber.Clear();
            streetWidth.Clear();
            parkingBoundary.Clear();
            parkingDimension.Clear();
            parkingArea.Clear();
        }

        private void EnableFormFields(bool enabled)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is Button)
                {
                    if (control != buttonNew && control != buttonSearch && control != textBoxSearch)
                    {
                        control.Enabled = enabled;
                    }
                }
            }
        }
    }
}
