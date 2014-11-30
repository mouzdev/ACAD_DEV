/////////////////////////////////////////////////////////////////////////////////////////////////
//http://www.bimcad.org 数字建筑
//深入浅出AutoCAD二次开发(李冠亿)
/////////////////////////////////////////////////////////////////////////////////////////////////

using System;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.ApplicationServices;

[assembly: CommandClass(typeof(Sample.CH6_3_6))]
namespace Sample
{
    class CH6_3_6
    {
        [CommandMethod("AddContextMenu")]
        public void AddContextMenu()
        {
            ContextMenuExtension ce = new ContextMenuExtension();
            ce.Title="快捷菜单";
            MenuItem mi1 = new MenuItem("创建线");
            mi1.Click += new EventHandler(mi1_Click);
            MenuItem mi2 = new MenuItem("创建圆");
            mi2.Click += new EventHandler(mi2_Click);
            ce.MenuItems.Add(mi1);
            ce.MenuItems.Add(mi2);
            Autodesk.AutoCAD.ApplicationServices.Application.AddDefaultContextMenuExtension(ce);
        }
        void mi1_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("Line \n", true, false, true);
        }
        void mi2_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("Circle \n", true, false, true);
        }
    }
}
