using System;
using System.Windows.Forms;

namespace PublicWorksAndRoads
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = Database.CreateConnection())
                {
                    connection.Open();
                    MessageBox.Show(@"تم الاتصال بقاعدة البيانات بنجاح.", @"نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"فشل الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}