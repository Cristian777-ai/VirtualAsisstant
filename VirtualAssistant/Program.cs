using System;
using System.IO;           
using System.Windows.Forms;


namespace WhatsAppVirtualAssistant
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string apiKey = "YOUR_DEFAULT_KEY";

            if (File.Exists("apikey.txt"))
            {
                apiKey = File.ReadAllText("apikey.txt").Trim();
            }

            if (string.IsNullOrWhiteSpace(apiKey) || apiKey.StartsWith("YOUR"))
            {
                MessageBox.Show("⚠️ No se encontró una API Key válida. Por favor, colócala en apikey.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(apiKey));
        }
    }
}