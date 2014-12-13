
namespace Sample
{
    partial class MyForm
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
            this.INPUT_LEFTBOTTOM = new System.Windows.Forms.TextBox();
            this.BTN_LEFTBOTTOM = new System.Windows.Forms.Button();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_CANCEL = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.INPUT_UPTOP = new System.Windows.Forms.TextBox();
            this.BTN_UPTOP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // INPUT_LEFTBOTTOM
            // 
            this.INPUT_LEFTBOTTOM.Location = new System.Drawing.Point(89, 33);
            this.INPUT_LEFTBOTTOM.Name = "INPUT_LEFTBOTTOM";
            this.INPUT_LEFTBOTTOM.Size = new System.Drawing.Size(230, 23);
            this.INPUT_LEFTBOTTOM.TabIndex = 0;
            // 
            // BTN_LEFTBOTTOM
            // 
            this.BTN_LEFTBOTTOM.Location = new System.Drawing.Point(89, 60);
            this.BTN_LEFTBOTTOM.Name = "BTN_LEFTBOTTOM";
            this.BTN_LEFTBOTTOM.Size = new System.Drawing.Size(230, 22);
            this.BTN_LEFTBOTTOM.TabIndex = 1;
            this.BTN_LEFTBOTTOM.Text = "切入到AutoCAD拾取点";
            this.BTN_LEFTBOTTOM.UseVisualStyleBackColor = true;
            this.BTN_LEFTBOTTOM.Click += new System.EventHandler(this.BTN_LEFTBOTTOM_Click);
            // 
            // BTN_OK
            // 
            this.BTN_OK.Font = new System.Drawing.Font("宋体", 10F);
            this.BTN_OK.Location = new System.Drawing.Point(96, 215);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(69, 43);
            this.BTN_OK.TabIndex = 2;
            this.BTN_OK.Text = "确定";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_CANCEL
            // 
            this.BTN_CANCEL.Font = new System.Drawing.Font("宋体", 10F);
            this.BTN_CANCEL.Location = new System.Drawing.Point(192, 215);
            this.BTN_CANCEL.Name = "BTN_CANCEL";
            this.BTN_CANCEL.Size = new System.Drawing.Size(69, 43);
            this.BTN_CANCEL.TabIndex = 3;
            this.BTN_CANCEL.Text = "取消";
            this.BTN_CANCEL.UseVisualStyleBackColor = true;
            this.BTN_CANCEL.Click += new System.EventHandler(this.BTN_CANCEL_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.INPUT_UPTOP);
            this.groupBox1.Controls.Add(this.BTN_UPTOP);
            this.groupBox1.Controls.Add(this.INPUT_LEFTBOTTOM);
            this.groupBox1.Controls.Add(this.BTN_LEFTBOTTOM);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 179);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "矩形范围定义";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "右上角点：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "左下角点：";
            // 
            // INPUT_UPTOP
            // 
            this.INPUT_UPTOP.Location = new System.Drawing.Point(89, 100);
            this.INPUT_UPTOP.Name = "INPUT_UPTOP";
            this.INPUT_UPTOP.Size = new System.Drawing.Size(230, 23);
            this.INPUT_UPTOP.TabIndex = 0;
            // 
            // BTN_UPTOP
            // 
            this.BTN_UPTOP.Location = new System.Drawing.Point(89, 127);
            this.BTN_UPTOP.Name = "BTN_UPTOP";
            this.BTN_UPTOP.Size = new System.Drawing.Size(230, 22);
            this.BTN_UPTOP.TabIndex = 1;
            this.BTN_UPTOP.Text = "切入到AutoCAD拾取点";
            this.BTN_UPTOP.UseVisualStyleBackColor = true;
            this.BTN_UPTOP.Click += new System.EventHandler(this.BTN_UPTOP_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(377, 270);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTN_CANCEL);
            this.Controls.Add(this.BTN_OK);
            this.Name = "MyForm";
            this.ShowInTaskbar = false;
            this.Text = "自动填充块";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox INPUT_LEFTBOTTOM;
        private System.Windows.Forms.Button BTN_LEFTBOTTOM;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_CANCEL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox INPUT_UPTOP;
        private System.Windows.Forms.Button BTN_UPTOP;
    }
}