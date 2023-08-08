using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\RevitAPITraining\";

            var panel = application.CreateRibbonPanel(tabName, "Трубы");

            var button = new PushButtonData("Система", "Смена системы труб",
                Path.Combine(utilsFolderPath, "RevitAPITrainingFloatingList.dll"),
                "RevitAPITrainingFloatingList.Main");



            panel.AddItem(button);

            return Result.Succeeded;
        }
    }
}
