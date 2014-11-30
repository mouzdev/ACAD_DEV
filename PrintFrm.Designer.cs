namespace Sample
{
    partial class PrintFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_PRINTDEV = new System.Windows.Forms.ComboBox();
            this.CB_PRINT2FILE = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_PAPERSIZE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_OFFSETX = new System.Windows.Forms.TextBox();
            this.TB_OFFSETY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_CENTER_PRINT = new System.Windows.Forms.CheckBox();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_CANCEL = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_PRINT2FILE);
            this.groupBox1.Controls.Add(this.CB_PRINTDEV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印机/绘图仪";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // CB_PRINTDEV
            // 
            this.CB_PRINTDEV.FormattingEnabled = true;
            this.CB_PRINTDEV.Location = new System.Drawing.Point(57, 25);
            this.CB_PRINTDEV.Name = "CB_PRINTDEV";
            this.CB_PRINTDEV.Size = new System.Drawing.Size(235, 21);
            this.CB_PRINTDEV.TabIndex = 1;
            // 
            // CB_PRINT2FILE
            // 
            this.CB_PRINT2FILE.AutoSize = true;
            this.CB_PRINT2FILE.Font = new System.Drawing.Font("宋体", 10F);
            this.CB_PRINT2FILE.Location = new System.Drawing.Point(5, 56);
            this.CB_PRINT2FILE.Name = "CB_PRINT2FILE";
            this.CB_PRINT2FILE.Size = new System.Drawing.Size(96, 18);
            this.CB_PRINT2FILE.TabIndex = 2;
            this.CB_PRINT2FILE.Text = "打印到文件";
            this.CB_PRINT2FILE.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_PAPERSIZE);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox2.Location = new System.Drawing.Point(10, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图纸尺寸";
            // 
            // CB_PAPERSIZE
            // 
            this.CB_PAPERSIZE.FormattingEnabled = true;
            this.CB_PAPERSIZE.Location = new System.Drawing.Point(59, 33);
            this.CB_PAPERSIZE.Name = "CB_PAPERSIZE";
            this.CB_PAPERSIZE.Size = new System.Drawing.Size(235, 21);
            this.CB_PAPERSIZE.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "类型：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CB_CENTER_PRINT);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TB_OFFSETY);
            this.groupBox3.Controls.Add(this.TB_OFFSETX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox3.Location = new System.Drawing.Point(10, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 95);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "打印偏移";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(16, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.Location = new System.Drawing.Point(16, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "：";
            // 
            // TB_OFFSETX
            // 
            this.TB_OFFSETX.Location = new System.Drawing.Point(40, 24);
            this.TB_OFFSETX.Name = "TB_OFFSETX";
            this.TB_OFFSETX.Size = new System.Drawing.Size(74, 23);
            this.TB_OFFSETX.TabIndex = 1;
            this.TB_OFFSETX.Text = "0.454724";
            // 
            // TB_OFFSETY
            // 
            this.TB_OFFSETY.Location = new System.Drawing.Point(40, 59);
            this.TB_OFFSETY.Name = "TB_OFFSETY";
            this.TB_OFFSETY.Size = new System.Drawing.Size(74, 23);
            this.TB_OFFSETY.TabIndex = 1;
            this.TB_OFFSETY.Text = "-0.537402";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 2;
            this.label7.Text = "英寸";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "英寸";
            // 
            // CB_CENTER_PRINT
            // 
            this.CB_CENTER_PRINT.AutoSize = true;
            this.CB_CENTER_PRINT.Location = new System.Drawing.Point(203, 29);
            this.CB_CENTER_PRINT.Name = "CB_CENTER_PRINT";
            this.CB_CENTER_PRINT.Size = new System.Drawing.Size(82, 18);
            this.CB_CENTER_PRINT.TabIndex = 3;
            this.CB_CENTER_PRINT.Text = "居中打印";
            this.CB_CENTER_PRINT.UseVisualStyleBackColor = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.Font = new System.Drawing.Font("宋体", 10F);
            this.BTN_OK.Location = new System.Drawing.Point(65, 287);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(74, 33);
            this.BTN_OK.TabIndex = 1;
            this.BTN_OK.Text = "确定";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_CANCEL
            // 
            this.BTN_CANCEL.Font = new System.Drawing.Font("宋体", 10F);
            this.BTN_CANCEL.Location = new System.Drawing.Point(177, 287);
            this.BTN_CANCEL.Name = "BTN_CANCEL";
            this.BTN_CANCEL.Size = new System.Drawing.Size(74, 33);
            this.BTN_CANCEL.TabIndex = 1;
            this.BTN_CANCEL.Text = "取消";
            this.BTN_CANCEL.UseVisualStyleBackColor = true;
            this.BTN_CANCEL.Click += new System.EventHandler(this.BTN_CANCEL_Click);
            // 
            // PrintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 331);
            this.Controls.Add(this.BTN_CANCEL);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PrintFrm";
            this.Text = "PrintFrm";
            this.Load += new System.EventHandler(this.PrintFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CB_PRINT2FILE;
        private System.Windows.Forms.ComboBox CB_PRINTDEV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_PAPERSIZE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CB_CENTER_PRINT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_OFFSETY;
        private System.Windows.Forms.TextBox TB_OFFSETX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_CANCEL;
    }
}