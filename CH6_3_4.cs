/////////////////////////////////////////////////////////////////////////////////////////////////
//http://www.bimcad.org 数字建筑
//深入浅出AutoCAD二次开发(李冠亿)
/////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Data;
using System.Windows.Forms;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(Sample.CH6_3_4))]
namespace Sample
{
    class CH6_3_4
    {
        [CommandMethod("AddPalette")]
        public void AddPalette()
        {
            MyControl mycontrol = new MyControl();
            Autodesk.AutoCAD.Windows.PaletteSet ps = new Autodesk.AutoCAD.Windows.PaletteSet("PaletteSet");

            ps.Visible = true;
            ps.Style = PaletteSetStyles.ShowAutoHideButton;
            ps.Dock = DockSides.None;
            ps.MinimumSize = new System.Drawing.Size(200, 100);
            ps.Size = new System.Drawing.Size(200, 100);
            ps.Add("PaletteSet", mycontrol);
            ps.Visible = true;
        }
    }
}
