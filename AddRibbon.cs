using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

using Autodesk.AutoCAD.Windows;
using Autodesk.Windows;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Ribbon;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.PlottingServices;

[assembly: CommandClass(typeof(Sample.AddRibbon))]
namespace Sample
{
    class AddRibbon
    {
        private const string MY_TAB_ID = "MY_TAB_ID";

        /// <summary>
        /// self-defined command for adding Ribbon Menu
        /// </summary>
        [CommandMethod("addMyRibbon")]
        public void createRibbon()
        {
            Autodesk.Windows.RibbonControl ribCntrl =
                      Autodesk.AutoCAD.Ribbon.RibbonServices.RibbonPaletteSet.RibbonControl;
            //can also be Autodesk.Windows.ComponentManager.Ribbon;     

            //add the tab
            RibbonTab ribTab = new RibbonTab();
            ribTab.Title = "自定义";
            ribTab.Id = MY_TAB_ID;
            ribCntrl.Tabs.Add(ribTab);

            //create and add both panels
            addPanel1(ribTab);
            addPanel2(ribTab);
            

            //set as active tab
            ribTab.IsActive = true;
        }

        /// <summary>
        /// construct the menu panel for Block Operation
        /// </summary>
        /// <param name="ribTab"></param>
        private void addPanel1(RibbonTab ribTab)
        {
            //create the panel source
            RibbonPanelSource ribPanelSource = new RibbonPanelSource();
            ribPanelSource.Title = "块操作";

            //create the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribPanelSource;
            ribTab.Panels.Add(ribPanel);

            //create button1
            RibbonButton ribButtonBlockLoad = new RibbonButton();
            ribButtonBlockLoad.Text = "加载块";
            ribButtonBlockLoad.ShowText = true;
            //ribButtonBlockLoad.LargeImage = GetBitmapImage("D:\\Projects\\AutoCAD\\Code\\MyProject\\image\\block.png");
            //ribButtonBlockLoad.LargeImage = GetBitmapImage(@".\image\\block.png");
            //ribButtonBlockLoad.ShowImage = true;

            //pay attention to the SPACE after the command name
            ribButtonBlockLoad.CommandParameter = "DrawCircle ";
            ribButtonBlockLoad.CommandHandler = new AdskCommandHandler();

            RibbonButton ribButtonBlockArray = new RibbonButton();
            ribButtonBlockArray.Text = "块自动填充";
            ribButtonBlockArray.ShowText = true;
            ribButtonBlockArray.CommandParameter = "BlockArrayFill ";
            ribButtonBlockArray.CommandHandler = new AdskCommandHandler();

            ribPanelSource.Items.Add(ribButtonBlockLoad);
            ribPanelSource.Items.Add(ribButtonBlockArray);

        }

        /// <summary>
        /// construct the menu panel for Layer Print
        /// </summary>
        /// <param name="ribTab"></param>
        private void addPanel2(RibbonTab ribTab)
        {
            //create the panel source
            RibbonPanelSource ribPanelSource = new RibbonPanelSource();
            ribPanelSource.Title = "打印操作";

            //create the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribPanelSource;
            ribTab.Panels.Add(ribPanel);

            //create button1
            RibbonButton ribButtonPrint = new RibbonButton();
            ribButtonPrint.Text = "打印图层";
            ribButtonPrint.ShowText = true;
            //ribButtonPrint.Image = GetBitmapImage("D:\\Projects\\AutoCAD\\Code\\MyProject\\img\\print_32.png");
            //BitmapImage bmi = new BitmapImage(new Uri("D:\\Projects\\AutoCAD\\Code\\MyProject\\img\\printer.png"));
            //double i = bmi.Width;
            //double j = bmi.Height;
            //ribButtonPrint.LargeImage = bmi;            
            ribButtonPrint.ShowImage = true;

            //pay attention to the SPACE after the command name
            ribButtonPrint.CommandParameter = "PrintAllLayer ";
            ribButtonPrint.CommandHandler = new AdskCommandHandler();
                        
            ribPanelSource.Items.Add(ribButtonPrint);
        }

        /// <summary>
        /// GetBitMapImage
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public BitmapImage GetBitmapImage(string imageName)
        {
            return new BitmapImage(new Uri(
             imageName));
        }  

        /// <summary>
        /// draw circle
        /// </summary>
        [CommandMethod("DrawCircle")]
        public void DrawCircle()
        {
            //use command of Autocad 2013
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("Circle\n", true, false, true);
        }

        [CommandMethod("BlockArrayFill")]
        public void BlockArrayFill()
        {
            using (MyForm autoBlockFill = new MyForm())
            {
                autoBlockFill.ShowInTaskbar = false;
                Application.ShowModalDialog(autoBlockFill);
                if (autoBlockFill.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("矩形范围面积为：\n" + autoBlockFill.recArea);

                    Database db = HostApplicationServices.WorkingDatabase;
                    ObjectId refid;

                    using (Transaction trans = db.TransactionManager.StartTransaction())
                    {
                        BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                        BlockTableRecord modelSpace = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        refid = db.OverlayXref(@"d:\Tmp\door.dwg", "name");// 把外部文件转换为块定义
                        //BlockReference br = new BlockReference(Point3d.Origin, refid); // 通过块定义创建块参照

                        for (int i = 0; i < 3; i++)
                        {
                            double baseX = i * 900;
                            for (int j = 0; j < 3; j++)
                            {
                                Point3d baseP = new Point3d(autoBlockFill.pointLeftB.X + baseX, autoBlockFill.pointLeftB.Y + j * 600, 0);
                                BlockReference br = new BlockReference(baseP, refid); // 通过块定义创建块参照
                                modelSpace.AppendEntity(br); //把块参照添加到块表记录
                                trans.AddNewlyCreatedDBObject(br, true); // 通过事务添加块参照到数据库
                                br.Dispose();
                            }
                        }
                        trans.Commit();

                    }

                }
 
            }
 
        }
        /// <summary>
        /// command handler class
        /// </summary>
        class AdskCommandHandler : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                //is from Ribbon Button
                RibbonButton ribBtn = parameter as RibbonButton;
                if (ribBtn != null)
                {
                    //execute the command 
                    Autodesk.AutoCAD.ApplicationServices.Application
                      .DocumentManager.MdiActiveDocument
                      .SendStringToExecute(
                         (string)ribBtn.CommandParameter, true, false, true);
                }
            }
        }

        //添加参考块
        [CommandMethod("AddBlockArray")]
        public void AddBlockArray()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            ObjectId refid;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord modelSpace = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                refid = db.OverlayXref(@"d:\Tmp\door.dwg", "name");// 把外部文件转换为块定义
                //BlockReference br = new BlockReference(Point3d.Origin, refid); // 通过块定义创建块参照

                for (int i = 0; i < 3; i++)
                {   
                    double baseX = i * 900;
                    for (int j = 0; j < 3; j++)
                    {
                        Point3d baseP = new Point3d(baseX, j * 600, 0);
                        BlockReference br = new BlockReference(baseP, refid); // 通过块定义创建块参照
                        modelSpace.AppendEntity(br); //把块参照添加到块表记录
                        trans.AddNewlyCreatedDBObject(br, true); // 通过事务添加块参照到数据库
                        br.Dispose();
                    }
                }
                trans.Commit();

            }
        }

        //打印所有图层，每一图层都打印输出一个文件
        [CommandMethod("PrintAllLayer")]
        public static void PrintAllLayer()
        {
            using (PrintFrm pfrom = new PrintFrm())
            {
                pfrom.ShowInTaskbar = false;
                Application.ShowModalDialog(pfrom);
                if (pfrom.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Document acDoc = Application.DocumentManager.MdiActiveDocument;
                    Database acCurDb = acDoc.Database;
                    Editor ed = acDoc.Editor;
                    string docName = acDoc.Name;
                    docName = docName.Remove(docName.Length - 5);
                    List<string> outputFileList = new List<string>();
                    string outputPath = "D:\\Tmp\\";
                    string printDevice = "DWF6 ePlot.pc3";
                    string mediaDevice = "ANSI_A_(8.50_x_11.00_Inches)";

                    Transaction acTrans = acCurDb.TransactionManager.StartTransaction();
                    // 获取图层
                    LayerTable acLyrTbl;
                    acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;
                    List<string> sLayerNames = new List<string>();

                    // 获取图层列表
                    foreach (ObjectId acObjId in acLyrTbl)
                    {
                        LayerTableRecord acLyrTblRec;
                        acLyrTblRec = acTrans.GetObject(acObjId, OpenMode.ForWrite) as LayerTableRecord;
                        sLayerNames.Add(acLyrTblRec.Name);
                        //outputFileList.Add(String.Concat(docName, acLyrTblRec.Name));
                        outputFileList.Add(acLyrTblRec.Name);
                        acLyrTblRec.IsOff = true;
                    }

                    for (int i = 0; i < sLayerNames.Count; i++)
                    {
                        string layerName = sLayerNames[i].ToString();
                        string outputFileName = outputFileList[i].ToString();
                        PlotCurrentLayout(layerName, outputFileName, outputPath, printDevice, mediaDevice);

                        while (PlotFactory.ProcessPlotState != ProcessPlotState.NotPlotting)
                        {
                            ed.WriteMessage("Be Printing, Please Wait.\n");
                        }
                    }
                    ed.WriteMessage("文档打印完成。\n");

                    // 将活动图层修改为第一个，即图层0
                    acCurDb.Clayer = acLyrTbl["0"];
                    LayerTableRecord acLayerTblRec = acTrans.GetObject(acLyrTbl["0"], OpenMode.ForWrite) as LayerTableRecord;
                    acLayerTblRec.IsOff = false; //显示该图层
                }
                else
                {
                    Application.ShowAlertDialog("您已经选择了放弃打印！");
                }
            }
           
        }

        //打印模型布局的范围
        //打印到DWF文件

        //[CommandMethod("PlotCurrentLayout")]
        /// <summary>
        /// 打印输出单个文件
        /// </summary>
        /// <param name="LayerName"></param>
        /// <param name="FileName"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="printer"></param>
        /// <param name="paperFormat"></param>
        public static void PlotCurrentLayout(string LayerName, string FileName, string outputFilePath, string printer, string paperFormat)
        {
            // 获取当前文档和数据库，启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // 获取图层
                LayerTable acLyrTbl;
                acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;

                // 将活动图层修改为第一个，即图层0
                acCurDb.Clayer = acLyrTbl[LayerName];
                LayerTableRecord acLayerTblRec = acTrans.GetObject(acLyrTbl[LayerName], OpenMode.ForWrite) as LayerTableRecord;
                acLayerTblRec.IsOff = false; //显示该图层

                // 引用布局管理器LayoutManager
                LayoutManager acLayoutMgr;
                acLayoutMgr = LayoutManager.Current;

                // 获取当前布局，在命令行窗口显示布局名字
                Layout acLayout;
                acLayout = acTrans.GetObject(acLayoutMgr.GetLayoutId(acLayoutMgr.CurrentLayout),
                                             OpenMode.ForRead) as Layout;

                // 从布局中获取PlotInfo
                PlotInfo acPlInfo = new PlotInfo();
                acPlInfo.Layout = acLayout.ObjectId;

                // 复制布局中的PlotSettings
                PlotSettings acPlSet = new PlotSettings(acLayout.ModelType);
                acPlSet.CopyFrom(acLayout);

                // 更新PlotSettings对象
                PlotSettingsValidator acPlSetVdr = PlotSettingsValidator.Current;

                //// 获取打印设备
                //StringCollection deviceList = acPlSetVdr.GetPlotDeviceList();

                //// 打印设备列表-MessageBox形式
                //foreach (string d in deviceList)
                //{
                //    ed.WriteMessage("打印设备：" + d + "\n");
                //}

                //// 获取纸张列表
                //StringCollection mediaList = acPlSetVdr.GetCanonicalMediaNameList(acPlSet);

                //ed.WriteMessage("图纸种类：" + Convert.ToString(mediaList.Count) + " 个\n");
                //foreach (string m in mediaList)
                //{
                //    ed.WriteMessage("打印图纸：" + m + "\n");
                //}

                // 设置打印区域
                acPlSetVdr.SetPlotType(acPlSet,
                            Autodesk.AutoCAD.DatabaseServices.PlotType.Extents);

                // 设置打印比例
                acPlSetVdr.SetUseStandardScale(acPlSet, true);
                acPlSetVdr.SetStdScaleType(acPlSet, StdScaleType.ScaleToFit);

                // 居中打印
                acPlSetVdr.SetPlotCentered(acPlSet, true);

                // 设置使用的打印设备
                //acPlSetVdr.SetPlotConfigurationName(acPlSet, "PostScript Level 2.pc3",
                //"ANSI_A_(8.50_x_11.00_Inches)");
                //设置采用的打印设备与纸张格式
                acPlSetVdr.SetPlotConfigurationName(acPlSet, printer,
                                    paperFormat);


                // 用上述设置信息覆盖PlotInfo对象，
                // 不会将修改保存回布局
                acPlInfo.OverrideSettings = acPlSet;

                // 验证打印信息
                PlotInfoValidator acPlInfoVdr = new PlotInfoValidator();
                acPlInfoVdr.MediaMatchingPolicy = MatchingPolicy.MatchEnabled;
                acPlInfoVdr.Validate(acPlInfo);

                // 检查是否有正在处理的打印任务
                if (PlotFactory.ProcessPlotState == ProcessPlotState.NotPlotting)
                {
                    using (PlotEngine acPlEng = PlotFactory.CreatePublishEngine())
                    {
                        // 使用PlotProgressDialog对话框跟踪打印进度
                        PlotProgressDialog acPlProgDlg = new PlotProgressDialog(false,
                                                                                1,
                                                                                true);

                        using (acPlProgDlg)
                        {
                            // 定义打印开始时显示的状态信息
                            acPlProgDlg.set_PlotMsgString(PlotMessageIndex.DialogTitle,
                                                          "Plot Progress");
                            acPlProgDlg.set_PlotMsgString(PlotMessageIndex.CancelJobButtonMessage,
                                                          "Cancel Job");
                            acPlProgDlg.set_PlotMsgString(PlotMessageIndex.CancelSheetButtonMessage,
                                                          "Cancel Sheet");
                            acPlProgDlg.set_PlotMsgString(PlotMessageIndex.SheetSetProgressCaption,
                                                          "Sheet Set Progress");
                            acPlProgDlg.set_PlotMsgString(PlotMessageIndex.SheetProgressCaption,
                                                          "Sheet Progress");

                            // 设置打印进度范围
                            acPlProgDlg.LowerPlotProgressRange = 0;
                            acPlProgDlg.UpperPlotProgressRange = 100;
                            acPlProgDlg.PlotProgressPos = 0;

                            // 显示打印进度对话框
                            acPlProgDlg.OnBeginPlot();
                            acPlProgDlg.IsVisible = true;

                            // 开始打印
                            acPlEng.BeginPlot(acPlProgDlg, null);

                            string opFile = outputFilePath + LayerName;
                            // 定义打印输出
                            acPlEng.BeginDocument(acPlInfo,
                                                  acDoc.Name,
                                                  null,
                                                  1,
                                                  true,
                                                  opFile);

                            // 显示当前打印任务的有关信息
                            //acPlProgDlg.set_PlotMsgString(PlotMessageIndex.Status,
                            //                              "Plotting: " + acDoc.Name + " - " +
                            //                              acLayout.LayoutName);
                            acPlProgDlg.set_PlotMsgString(PlotMessageIndex.Status,
                                                          "Plotting: " + acDoc.Name + " - " +
                                                          LayerName);

                            // 设置图纸进度范围
                            acPlProgDlg.OnBeginSheet();
                            acPlProgDlg.LowerSheetProgressRange = 0;
                            acPlProgDlg.UpperSheetProgressRange = 100;
                            acPlProgDlg.SheetProgressPos = 0;

                            // 打印第一张图/布局
                            PlotPageInfo acPlPageInfo = new PlotPageInfo();
                            acPlEng.BeginPage(acPlPageInfo,
                                              acPlInfo,
                                              true,
                                              null);

                            acPlEng.BeginGenerateGraphics(null);
                            acPlEng.EndGenerateGraphics(null);

                            // 结束第一张图/布局的打印
                            acPlEng.EndPage(null);
                            acPlProgDlg.SheetProgressPos = 100;
                            acPlProgDlg.OnEndSheet();

                            // 结束文档局的打印
                            acPlEng.EndDocument(null);

                            // 打印结束
                            acPlProgDlg.PlotProgressPos = 100;
                            acPlProgDlg.OnEndPlot();
                            acPlEng.EndPlot(null);
                        }
                    }
                }
                acLayerTblRec.IsOff = true; //关闭该图层
            }
        }
    }
}
