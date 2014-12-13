using System;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.PlottingServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Threading;



namespace Sample
{
    public class LayerPrint
    {
        //定义打印是否完成
        public static bool printFlag = false;
        //查询和修改当前布局的打印设备

        [CommandMethod("ChangePlotSetting")]
        public static void ChangePlotSetting()
        {
            // 获取当前文档和数据库，启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // 引用布局管理器LayoutManager
                LayoutManager acLayoutMgr;
                acLayoutMgr = LayoutManager.Current;

                // 获取当前布局，在命令行窗口显示布局名
                Layout acLayout;
                acLayout = acTrans.GetObject(acLayoutMgr.GetLayoutId(acLayoutMgr.CurrentLayout),
                                             OpenMode.ForRead) as Layout;

                // 输出当前布局名和设备名
                acDoc.Editor.WriteMessage("\nCurrent layout: " +
                                          acLayout.LayoutName);

                acDoc.Editor.WriteMessage("\nCurrent device name: " +
                                          acLayout.PlotConfigurationName);

                // 从布局中获取PlotInfo
                PlotInfo acPlInfo = new PlotInfo();
                acPlInfo.Layout = acLayout.ObjectId;

                // 复制布局中的PlotSettings
                PlotSettings acPlSet = new PlotSettings(acLayout.ModelType);
                acPlSet.CopyFrom(acLayout);

                // 更新PlotSettings对象的PlotConfigurationName属性
                PlotSettingsValidator acPlSetVdr = PlotSettingsValidator.Current;
                acPlSetVdr.SetPlotConfigurationName(acPlSet, "DWF6 ePlot.pc3",
                                                    "ANSI_A_(8.50_x_11.00_Inches)");

                // 更新布局
                acLayout.UpgradeOpen();
                acLayout.CopyFrom(acPlSet);

                // 输出已更新的布局设备名
                acDoc.Editor.WriteMessage("\nNew device name: " +
                                          acLayout.PlotConfigurationName);

                // 将新对象保存到数据库
                acTrans.Commit();
            }
        }


        //演示如何在模型空间和图纸空间之间切换

        [CommandMethod("ToggleSpace")]
        public static void ToggleSpace()
        {
            // 获取当前文档
            Document acDoc = Application.DocumentManager.MdiActiveDocument;

            // 获取系统变量CVPORT和TILEMODE的当前值
            object oCvports = Application.GetSystemVariable("CVPORT");
            object oTilemode = Application.GetSystemVariable("TILEMODE");

            // 检查Model布局是否为活动的（TILEMODE=1为活动）
            // the Model layout is active
            if (System.Convert.ToInt16(oTilemode) == 0)
            {
                // 检查Model空间是否为活动的（CVPORT=2为活动）
                // CVPORT is 2 if Model space is active 
                if (System.Convert.ToInt16(oCvports) == 2)
                {
                    acDoc.Editor.SwitchToPaperSpace();
                }
                else
                {
                    acDoc.Editor.SwitchToModelSpace();
                }
            }
            else
            {
                // 切换到Paper空间布局
                Application.SetSystemVariable("TILEMODE", 0);
            }
        }


        //本例设置图纸空间为活动空间，
        //然后创建一个浮动视口，定义视口的视图，并激活该视口。
        //导入外部函数acedSetCurrentVPort。对2012版，该函数在acad.exe内。
        [DllImport("accore.dll", CallingConvention = CallingConvention.Cdecl,
 EntryPoint = "?acedSetCurrentVPort@@YA?AW4ErrorStatus@Acad@@PBVAcDbViewport@@@Z")]
        extern static private int acedSetCurrentVPort(IntPtr AcDbVport);

        [CommandMethod("CreateFloatingViewport")]
        public static void CreateFloatingViewport()
        {
            // 获取当前文档和数据库，启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // 以读模式打开块表
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                             OpenMode.ForRead) as BlockTable;

                // 以写模式打开块表记录Paper空间
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.PaperSpace],
                                                OpenMode.ForWrite) as BlockTableRecord;

                // 切换到Paper空间布局
                Application.SetSystemVariable("TILEMODE", 0);
                acDoc.Editor.SwitchToPaperSpace();

                // 创建一个视口
                Viewport acVport = new Viewport();
                acVport.CenterPoint = new Point3d(3.25, 3, 0);
                acVport.Width = 6;
                acVport.Height = 5;

                // 添加新对象到块表记录和事务
                acBlkTblRec.AppendEntity(acVport);
                acTrans.AddNewlyCreatedDBObject(acVport, true);

                // 修改观察方向
                acVport.ViewDirection = new Vector3d(1, 1, 1);

                // 激活视口
                acVport.On = true;

                // 激活视口的模型空间
                acDoc.Editor.SwitchToModelSpace();

                // 使用导入的ObjectARX函数设置新视口为当前视口
                acedSetCurrentVPort(acVport.UnmanagedObject);

                // 将新对象保存到数据库
                acTrans.Commit();
            }
        }


        //创建4个浮动视口

        [CommandMethod("FourFloatingViewports")]
        public static void FourFloatingViewports()
        {
            // 获取当前文档和数据库，启动事务
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // 以读模式打开块表
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                             OpenMode.ForRead) as BlockTable;

                // 以写模式打开块表记录Paper空间
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.PaperSpace],
                                                OpenMode.ForWrite) as BlockTableRecord;

                // 切换到Paper空间布局
                Application.SetSystemVariable("TILEMODE", 0);
                acDoc.Editor.SwitchToPaperSpace();

                Point3dCollection acPt3dCol = new Point3dCollection();
                acPt3dCol.Add(new Point3d(2.5, 5.5, 0));
                acPt3dCol.Add(new Point3d(2.5, 2.5, 0));
                acPt3dCol.Add(new Point3d(5.5, 5.5, 0));
                acPt3dCol.Add(new Point3d(5.5, 2.5, 0));

                Vector3dCollection acVec3dCol = new Vector3dCollection();
                acVec3dCol.Add(new Vector3d(0, 0, 1));
                acVec3dCol.Add(new Vector3d(0, 1, 0));
                acVec3dCol.Add(new Vector3d(1, 0, 0));
                acVec3dCol.Add(new Vector3d(1, 1, 1));

                double dWidth = 2.5;
                double dHeight = 2.5;

                Viewport acVportLast = null;
                int nCnt = 0;

                foreach (Point3d acPt3d in acPt3dCol)
                {
                    Viewport acVport = new Viewport();
                    acVport.CenterPoint = acPt3d;
                    acVport.Width = dWidth;
                    acVport.Height = dHeight;

                    // 添加新对象到块表记录和事务
                    acBlkTblRec.AppendEntity(acVport);
                    acTrans.AddNewlyCreatedDBObject(acVport, true);

                    // 修改观察方向
                    acVport.ViewDirection = acVec3dCol[nCnt];

                    // 激活视口
                    acVport.On = true;

                    // 记录创建的最后视口
                    acVportLast = acVport;

                    // 计数器加1
                    nCnt = nCnt + 1;
                }

                if (acVportLast != null)
                {
                    // 激活视口的模型空间
                    acDoc.Editor.SwitchToModelSpace();

                    // 使用导入的ObjectARX函数设置新视口为当前视口
                    acedSetCurrentVPort(acVportLast.UnmanagedObject);
                }

                // 将新对象保存到数据库
                acTrans.Commit();
            }
        }

        //打印所有图层，每一图层都打印输出一个文件
        [CommandMethod("PrintAllLayer")]
        public static void PrintAllLayer()
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
                printFlag = false;
                string layerName = sLayerNames[i].ToString();
                string outputFileName = outputFileList[i].ToString();
                PlotCurrentLayout(layerName, outputFileName, outputPath, printDevice, mediaDevice);

                while (PlotFactory.ProcessPlotState != ProcessPlotState.NotPlotting)
                {
                    ed.WriteMessage("Be Printing, Please Wait.\n");
                }                
            }
            ed.WriteMessage("文档打印完成。\n");
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
                printFlag = true;
                //ed.WriteMessage("打印完成 \n");

            }
        }
        


    }
}
