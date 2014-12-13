/////////////////////////////////////////////////////////////////////////////////////////////////
//http://www.bimcad.org 数字建筑
//深入浅出AutoCAD二次开发(李冠亿)
/////////////////////////////////////////////////////////////////////////////////////////////////

using System;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;

[assembly: CommandClass(typeof(Sample.CH6_3_1))]
namespace Sample
{
    class CH6_3_1
    {
        [CommandMethod("EditorMessage")]
        public void EditorMessage()
        {
            Message("http://www.bimcad.org");
        }

        [CommandMethod("AlertMessage")]
        public void AlertMessage()
        {
            AlertDialog("http://www.bimcad.org");
        }

        [CommandMethod("WebMessage")]
        public void Message()
        {
            ShowWeb("http://www.bimcad.org");
        }

        /// <summary>
        /// 命令栏中显示字符
        /// </summary>
        /// <param name="word"></param>
        public static void Message(string word)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            ed.WriteMessage(word);
        }

        /// <summary>
        /// 弹出警告框
        /// </summary>
        /// <param name="message"></param>
        public static void AlertDialog(string message)
        {
            Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(message);
        }

        /// <summary>
        /// 弹出帮助网页
        /// </summary>
        /// <param name="web"></param>
        public static void ShowWeb(string url)
        {
            System.Diagnostics.Process.Start("explorer.exe", url);
        }
    }
}