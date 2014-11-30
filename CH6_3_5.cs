/////////////////////////////////////////////////////////////////////////////////////////////////
//http://www.bimcad.org 数字建筑
//深入浅出AutoCAD二次开发(李冠亿)
/////////////////////////////////////////////////////////////////////////////////////////////////

using System;

using Autodesk.AutoCAD.Windows;
using Autodesk.Windows;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Ribbon;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
//using Autodesk.AutoCAD.Customization;


[assembly: CommandClass(typeof(Sample.CH6_3_5))]
namespace Sample
{
    class CH6_3_5
    {
        [CommandMethod("AddRibbon")]
        public void AddRibbon()
        {
            RibbonControl rc = RibbonControl();
            RibbonTab rt = RibbonTab("自定义菜单", "1");
            RibbonPanel rp = RibbonPanel("自定义块操作");
            RibbonButton rb = RibbonButton("加载块", "加载专业块");
           
            rb.IsActive = true;
            rb.ShowText = true;
            rb.CommandParameter = "OutputMessage ";
            rb.CommandHandler = new AdskCommandHandler();

            rp.Source.Items.Add(rb);
            rt.Panels.Add(rp);
            rc.Tabs.Add(rt);
            rc.UpdateLayout();

        }

        [CommandMethod("OutputMessage")]
        public void OutputMessage()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("菜单命令执行测试！");
        }

        /// <summary>
        /// 获得菜单控制
        /// </summary>
        /// <returns></returns>
        public static RibbonControl RibbonControl()
        {
            if (Autodesk.Windows.ComponentManager.Ribbon == null)
                Autodesk.Windows.ComponentManager.ItemInitialized += new EventHandler<RibbonItemEventArgs>(ComponentManager_ItemInitialized);
            return ComponentManager.Ribbon; //Autodesk.AutoCAD.Ribbon.RibbonServices.RibbonPaletteSet.RibbonControl; //
        }

        /// <summary>
        /// 创建菜单标签
        /// </summary>
        /// <param name="Name">标签名</param>
        /// <param name="id">标签ID</param>
        /// <returns></returns>
        public static RibbonTab RibbonTab(string Name, string id)
        {
            RibbonTab ribTab = new Autodesk.Windows.RibbonTab();
            ribTab.Title = Name;
            ribTab.Id = id;
            ribTab.IsActive = true;            
            return ribTab;
        }

        /// <summary>
        /// 创建菜单面板
        /// </summary>
        /// <param name="Title">面板名</param>
        /// <returns></returns>
        public static RibbonPanel RibbonPanel(string Title)
        {
            RibbonPanelSource ribSourcePanel = new RibbonPanelSource(); // Autodesk.Windows
            ribSourcePanel.Title = Title;//now the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribSourcePanel;
            return ribPanel;
        }

        /// <summary>
        /// 创建菜单按钮
        /// </summary>
        /// <param name="btName">按钮名</param>
        /// <param name="cmdName">命令名</param>
        /// <returns></returns>
        public static RibbonButton RibbonButton(string btName, string cmdName)
        {
            RibbonButton ribButton = new RibbonButton();
            ribButton.Text = btName;
            ribButton.CommandParameter = cmdName;
            ribButton.ShowText = true;
            ribButton.CommandHandler = new AdskCommandHandler();
            return ribButton;
        }

        /// <summary>
        /// 用于激活菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void ComponentManager_ItemInitialized(object sender, RibbonItemEventArgs e)
        {
            if (Autodesk.Windows.ComponentManager.Ribbon != null)
                Autodesk.Windows.ComponentManager.ItemInitialized -= new EventHandler<RibbonItemEventArgs>(ComponentManager_ItemInitialized);
        }

        /// <summary>
        /// 执行按钮的命令
        /// </summary>
        public class AdskCommandHandler : System.Windows.Input.ICommand
        {
            /// <summary>
            /// 是否可执行(接口)
            /// </summary>
            /// <param name="parameter">命令名</param>
            /// <returns></returns>
            public bool CanExecute(object parameter)
            {
                return true;
            }
            /// <summary>
            /// 改变可执行状态
            /// </summary>
            public event EventHandler CanExecuteChanged;
            /// <summary>
            /// 执行命令
            /// </summary>
            /// <param name="parameter">命令的名字</param>
            public void Execute(object parameter)
            {
                //is from a Ribbon Button?
                RibbonButton ribBtn = parameter as RibbonButton;
                if (ribBtn != null)
                    Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.SendStringToExecute((String)ribBtn.CommandParameter, true, false, true);

                //is from s Ribbon Textbox?
                RibbonTextBox ribTxt = parameter as RibbonTextBox;
                if (ribTxt != null)
                    System.Windows.Forms.MessageBox.Show(ribTxt.TextValue);
            }
        }
    }
}
