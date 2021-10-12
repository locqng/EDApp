using System;
using System.Windows.Forms;
using System.Configuration;

// start the program 
namespace EDApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DirConfig dirConfig = new DirConfig();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String photoDir = ConfigurationManager.AppSettings.Get("Key0");
            String docDir = ConfigurationManager.AppSettings.Get("Key1");
            if (photoDir == "")
            {
                Console.WriteLine("Photo empty");
                MessageBox.Show("Please setup the photos directory", "First time running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                photoDir = dirConfig.getPhotoDir();
            }
            if(docDir == "")
            {
                Console.WriteLine("Doc empty");
                MessageBox.Show("Please setup the document directory", "First time running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                docDir = dirConfig.getDocDir();
            }
            if (photoDir != "" && docDir != "")
            
                Application.Run(new mainProgram(photoDir, docDir));
            else
                return;
        }
    }
}
