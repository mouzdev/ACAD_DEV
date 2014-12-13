using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    public partial class PrintFrm : Form
    {
        public PrintFrm()
        {
            InitializeComponent();
        }

        private void PrintFrm_Load(object sender, EventArgs e)
        {
            //添加打印设备，设置默认打印设备
            this.CB_PRINTDEV.Items.Add("DWF6 ePlot.pc3");
            this.CB_PRINTDEV.Items.Add("DWG To PDF.pc3");
            this.CB_PRINTDEV.Items.Add("PublishToWeb JPG.pc3");
            this.CB_PRINTDEV.Items.Add("PublishToWeb PNG.pc3");
            this.CB_PRINTDEV.Items.Add("PostScript Level 2.pc3");
            this.CB_PRINTDEV.SelectedIndex = 0;

            //添加图纸尺寸，设置默认尺寸
            this.CB_PAPERSIZE.Items.Add("ANSI_A_(8.50_x_11.00_Inches)");
            this.CB_PAPERSIZE.Items.Add("ANSI_A_(11.00_x_8.50_Inches)");
            this.CB_PAPERSIZE.Items.Add("ANSI_B_(17.00_x_11.00_Inches)");
            this.CB_PAPERSIZE.Items.Add("ANSI_B_(11.00_x_17.00_Inches)");
            this.CB_PAPERSIZE.Items.Add("ANSI_C_(22.00_x_17.00_Inches)");
            this.CB_PAPERSIZE.Items.Add("ANSI_C_(17.00_x_22.00_Inches)");
            this.CB_PAPERSIZE.SelectedIndex = 0;

            //打印到文件设置为默认
            this.CB_PRINT2FILE.Checked = true;
            this.CB_PRINT2FILE.Enabled = false;
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
