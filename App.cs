using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RevitNanoBanana
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel panel = application.CreateRibbonPanel("Nano Banana Tools");

            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            // Create push button data
            PushButtonData buttonData = new PushButtonData(
                "NanoBananaImageGen",
                "Generate\nImage",   // \n = text wraps nicely
                assemblyPath,
                "RevitNanoBanana.ImageGeneratorCommand"
            );

            // Create the button and add it to the panel
            PushButton pushButton = panel.AddItem(buttonData) as PushButton;

            // Assign icons (16x16 and 32x32 PNGs)
            string iconsFolder = Path.GetDirectoryName(assemblyPath);
            pushButton.LargeImage = new BitmapImage(new Uri(Path.Combine(iconsFolder, "img32.png")));
            pushButton.Image = new BitmapImage(new Uri(Path.Combine(iconsFolder, "img16.png")));

            // Optional tooltip and description
            pushButton.ToolTip = "Generate an image using Nano Banana";
            pushButton.LongDescription = "This tool allows you to generate images directly inside Revit.";


            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // Shutdown logic here
            return Result.Succeeded;
        }
    }
}

