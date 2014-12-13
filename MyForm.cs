using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;


namespace Sample
{
    public partial class MyForm : Form
    {
        public Point3d pointLeftB = new Point3d();
        public Point3d pointUpT = new Point3d();
        public double recArea = 0;
        public MyForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 提示用户拾取点
        /// </summary>
        /// <param name="word">提示</param>
        /// <returns>返回Point3d</returns>
        public Point3d GetPoint(string word)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            PromptPointResult pt = ed.GetPoint(word);
            if (pt.Status == PromptStatus.OK)
            {
                return (Point3d)pt.Value;
            }
            else
            {
                return new Point3d();
            }
        }

        public double CalculateArea()
        {
            double area;
            area = System.Math.Sqrt(Math.Pow((pointUpT.X-pointLeftB.X),2)+Math.Pow((pointUpT.Y-pointLeftB.Y),2));
            return area;
        }

        private void BTN_LEFTBOTTOM_Click(object sender, EventArgs e)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            using (EditorUserInteraction edUsrInt = ed.StartUserInteraction(this))
            {
                Point3d pt = GetPoint("\n选择点：");
                pointLeftB = pt;
                this.INPUT_LEFTBOTTOM.Text = "(" + pt.X.ToString() + "," + pt.Y.ToString() + "," + pt.Z.ToString() + ")";
                edUsrInt.End(); // End the UserInteraction. 
                this.Focus();
            }
        }

        private void BTN_UPTOP_Click(object sender, EventArgs e)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            using (EditorUserInteraction edUsrInt = ed.StartUserInteraction(this))
            {
                Point3d pt = GetPoint("\n选择点：");
                pointUpT = pt;
                this.INPUT_UPTOP.Text = "(" + pt.X.ToString() + "," + pt.Y.ToString() + "," + pt.Z.ToString() + ")";
                edUsrInt.End(); // End the UserInteraction. 
                this.Focus();
            }
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            recArea = CalculateArea();
            this.Close();

        }

        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
