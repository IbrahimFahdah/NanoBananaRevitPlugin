using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;

namespace RevitNanoBanana
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        Document doc;
        byte[] imageBytes;
        public MainForm(UIApplication uiApp)
        {
            InitializeComponent();
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            doc = uiDoc.Document;
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            string prompt = promptBox.Text;

            // 🔹 Here you should replace this mock with your actual logic (e.g., calling Gemini API, Revit API export, etc.)
            imageBytes = GenerateImage(prompt);

            // Convert byte[] to Image
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                pictureBox.Image = System.Drawing.Image.FromStream(ms);
            }

            saveButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (imageBytes == null) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
            dlg.Title = "Save Image";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dlg.FileName, imageBytes);
                MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private byte[] GenerateImage(string prompt)
        {
            try
            {
                // Take Screenshot of Current View
                Autodesk.Revit.DB.View activeView = doc.ActiveView;
                if (activeView == null)
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Error", "No active view found.");
                    return null;
                }

                string tempImagePath = Path.Combine(Path.GetTempPath(), "RevitViewScreenshot.png");

                ImageExportOptions options = new ImageExportOptions
                {

                    ExportRange = ExportRange.CurrentView, // Only the active view
                    HLRandWFViewsFileType = ImageFileType.PNG, // File type (PNG, JPG, BMP, etc.)
                    FilePath = tempImagePath, // Output path without extension
                    FitDirection = FitDirectionType.Horizontal, // Fit to width
                    PixelSize = 1000, // Approximate width in pixels (height auto-calculated)
                    ZoomType = ZoomFitType.FitToPage, // Fit view to page
                    ImageResolution = ImageResolution.DPI_300
                };
                doc.ExportImage(options);

                //  Get User Prompt
                if (string.IsNullOrWhiteSpace(prompt))
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Info", "No prompt entered. Operation cancelled.");
                    return null;
                }

                // 4. Call Hypothetical Gemini Flash API
                byte[] newImg = CallGeminiFlashAPI(tempImagePath, prompt);

                return newImg;
            }
            catch (Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Error", ex.Message);
                return null;
            }
        }

        private byte[] CallGeminiFlashAPI(string imageFilePath, string prompt)
        {
            string apiKey = txtApiKey.Text;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                byte[] imageBytes = File.ReadAllBytes(imageFilePath);
                string base64Image = Convert.ToBase64String(imageBytes);


                var requestBody = new
                {
                    contents = new[]
                   {
                    new
                    {
                        parts = new object[]
                        {
                            new { text = prompt },
                            new
                            {
                                inline_data = new
                                {
                                    mime_type = "image/jpeg",
                                    data = base64Image
                                }
                            }
                        }
                    }
                }
                };

                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                try
                {
                    var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-image-preview:generateContent?key={apiKey}";

                    HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        var err = $"Error: {response.StatusCode} - {response.Content.ReadAsStringAsync().Result}";
                        Autodesk.Revit.UI.TaskDialog.Show("Failed", err);
                    }

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    dynamic apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
                    var parts = apiResponse["candidates"]?[0]?["content"]?["parts"];
                    var outputFilePath = Path.Combine("C:\\Users\\ibrah\\Desktop\\del", "AI_Generated_Image.png");
                    foreach (var part in parts)
                    {
                        if (part["text"] != null)
                        {
                            Console.WriteLine($"Text response: {part["text"]}");
                        }
                        else if (part["inlineData"]?["data"] != null)
                        {
                            string generatedImageData = (string)part["inlineData"]["data"];
                            byte[] generatedImageBytes = Convert.FromBase64String(generatedImageData);

                            return generatedImageBytes;
                        }
                    }
                }
                catch (Exception e)
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Failed", e.Message);
                }
                return null;
            }
        }
    }
}
