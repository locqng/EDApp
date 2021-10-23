using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace EDApp{
    public class FileHandler
    {

        private Image photo;
        public byte[] ConvertImageToBytes(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }


        public Image ConvertByteArrayToImage(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }


        //Image upload
        public Image browseUpload(String dir, String name)
        {
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;*png;*.gif)|*.jpg;*.jpeg*;*.png*;*.gif", Multiselect = false, Title = "Upload Employee's Image" })
            {
            
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                   photo = Image.FromFile(dialog.FileName);
                   //Config to your photos directory
                   File.WriteAllBytes(dir+"\\"+name+".png", ConvertImageToBytes(photo));
                                                    
                   return photo;
               } 
               return null;
            }
        }

        //Handle upload mutiple doc files
        public int docsUpload(String dir, String name)
        {
            int docsCount = 0;
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf", Multiselect = true, Title = "Upload Employee's Documents" })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                byte[] bytes = File.ReadAllBytes(dialog.FileName);
                //Config to your doc directory
                String path = dir+"\\"+name+" Docs";
               
                Directory.CreateDirectory(path);
                foreach(String file in dialog.SafeFileNames)
                {
                    File.WriteAllBytes(dir+"\\"+name+" Docs" + "\\" + file, bytes);
                    docsCount++;
                }
                
               }
               return docsCount;  
            }
        }

        public String docUpload(String dir, String name)
        {
            String path = "";
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf", Multiselect = false, Title = "Upload Employee's Document" })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                   byte[] bytes = File.ReadAllBytes(dialog.FileName);
                   path = dir+"\\"+name+".pdf";
                   try{
                        File.WriteAllBytes(path, bytes);
                   }catch (Exception ex)
                   {
                       Console.WriteLine(ex);
                   }
               }
            }
            return path; 
        }
    }
}