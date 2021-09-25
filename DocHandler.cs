using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace EDApp{
    public class DocHandler
    {
        //private File doc;
        

        public int browseUpload(String dir, string empid)
        {
            int docsCount = 0;
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf", Multiselect = true })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                byte[] bytes = System.IO.File.ReadAllBytes(dialog.FileName);
                //Config to your photos directory
                String path = dir+"\\"+"\\"+empid+" Docs";
               
                Directory.CreateDirectory(path);
                foreach(String file in dialog.SafeFileNames)
                {
                    File.WriteAllBytes(dir+"\\"+"\\"+empid+" Docs" + "\\" + file, bytes);
                    docsCount++;
                }
                
               }
               return docsCount;  
            }
        }
    }
}