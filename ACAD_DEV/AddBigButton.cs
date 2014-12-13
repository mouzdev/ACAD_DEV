using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Windows;
//using Autodesk.Windows;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Ribbon;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.PlottingServices;
using Autodesk.AutoCAD.Customization;

namespace Sample
{
    class AddBigButton
    {
        [CommandMethod("AddRibbonBigButtons")]
        public static void AddRibbonBigButtons_Method()
        {
            Editor ed = MgdAcApplication.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                CustomizationSection cs = new CustomizationSection((string)MgdAcApplication.GetSystemVariable("MENUNAME"));
                string curWorkspace = (string)MgdAcApplication.GetSystemVariable("WSCURRENT");

                RibbonPanelSource panelSrc = AddRibbonPanelToTab(cs, "ANAW", "AcadNetAddinWizard2");
                MacroGroup macGroup = cs.MenuGroup.MacroGroups[0];

                RibbonRow row = new RibbonRow();
                panelSrc.Items.Add((RibbonItem)row);

                RibbonCommandButton button1 = new RibbonCommandButton(row);
                button1.Text = "Button 1";
                MenuMacro menuMac1 = macGroup.CreateMenuMacro("Button1_Macro", "^C^CButton1_Command ", "Button1_Tag", "Button1_Help",
                                    MacroType.Any, "ANAW_16x16.bmp", "ANAW_32x32.bmp", "Button1_Label_Id");
                button1.MacroID = menuMac1.ElementID;
                button1.ButtonStyle = RibbonButtonStyle.LargeWithText;
                button1.KeyTip = "Button1 Key Tip";
                button1.TooltipTitle = "Button1 Tooltip Title!";
                row.Items.Add((RibbonItem)button1);

                RibbonCommandButton button2 = new RibbonCommandButton(row);
                button2.Text = "Button 2";
                MenuMacro menuMac2 = macGroup.CreateMenuMacro("Button2_Macro", "^C^CButton2_Command ", "Button2_Tag", "Button2_Help",
                                    MacroType.Any, "ANAW_16x16.bmp", "ANAW_32x32.bmp", "Button2_Label_Id");
                button2.MacroID = menuMac2.ElementID;
                button2.ButtonStyle = RibbonButtonStyle.LargeWithText;
                button2.KeyTip = "Button2 Key Tip";
                button2.TooltipTitle = "Button2 Tooltip Title!";
                row.Items.Add((RibbonItem)button2);

                RibbonCommandButton button3 = new RibbonCommandButton(row);
                button3.Text = "Button 3";
                MenuMacro menuMac3 = macGroup.CreateMenuMacro("Button3_Macro", "^C^CButton3_Command ", "Button3_Tag", "Button3_Help",
                                    MacroType.Any, "ANAW_16x16.bmp", "ANAW_32x32.bmp", "Button3_Label_Id");
                button3.MacroID = menuMac3.ElementID;
                button3.ButtonStyle = RibbonButtonStyle.LargeWithText;
                button3.KeyTip = "Button3 Key Tip";
                button3.TooltipTitle = "Button3 Tooltip Title!";
                row.Items.Add((RibbonItem)button3);

                cs.Save();
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage(Environment.NewLine + ex.Message);
            }
        }

        public static RibbonPanelSource AddRibbonPanelToTab(CustomizationSection cs, string tabName, string panelName)
        {
            RibbonRoot root = cs.MenuGroup.RibbonRoot;
            RibbonPanelSourceCollection panels = root.RibbonPanelSources;

            foreach (RibbonTabSource rts in root.RibbonTabSources)
                if (rts.Name == tabName)
                {
                    //Create the ribbon panel source and add it to the ribbon panel source collection
                    RibbonPanelSource panelSrc = new RibbonPanelSource(root);
                    panelSrc.Text = panelSrc.Name = panelName;
                    panelSrc.ElementID = panelSrc.Id = panelName + "_PanelSourceID";
                    panels.Add(panelSrc);

                    //Create the ribbon panel source reference and add it to the ribbon panel source reference collection
                    RibbonPanelSourceReference ribPanelSourceRef = new RibbonPanelSourceReference(rts);
                    ribPanelSourceRef.PanelId = panelSrc.ElementID;
                    rts.Items.Add(ribPanelSourceRef);

                    return panelSrc;
                }

            return null;
        }
    }
}
