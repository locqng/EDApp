using System;
using System.Windows.Forms;
using System.Drawing;

// start the program 
namespace EDApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DirConfig config = new DirConfig();
            String photoDir = config.getPhotoDir();
            String docDir = config.getDocDir();
            Console.WriteLine(photoDir + " " + docDir);
            if (photoDir != "" && docDir != "")
            
                Application.Run(new mainProgram(photoDir, docDir));
            else
                return;
        }
    }
}
