/////////////////////////////////////////////////////////////////////////////////////////////////
//http://www.bimcad.org 数字建筑
//深入浅出AutoCAD二次开发(李冠亿)
/////////////////////////////////////////////////////////////////////////////////////////////////

using System;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;

[assembly: CommandClass(typeof(Sample.CH6_3_3))]
namespace Sample
{
    class CH6_3_3
    {
        [CommandMethod("ModalDialog")]
        public void ShowModalDialog()
        {
            using (MyForm form = new MyForm())
            {
                form.ShowInTaskbar = false;
                Application.ShowModalDialog(form);
                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                    Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\n" + form.INPUT_LEFTBOTTOM.Text);
            }
        }

        [CommandMethod("ModelessDialog")]
        public void ShowModelessDialog()
        {
            MyForm form = new MyForm();
            form.ShowInTaskbar = false;
            Application.ShowModelessDialog(form);
        }
    }
}