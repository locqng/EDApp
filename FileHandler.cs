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
        public Image browseUpload(String dir, String empid)
        {
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*.jpeg*", Multiselect = false })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                   photo = Image.FromFile(dialog.FileName);
                   //Config to your photos directory
                   File.WriteAllBytes(dir+"\\"+empid+".png", ConvertImageToBytes(photo));
                                                    
                   return photo;
               } 
               return null;
            }
        }

        //Handle upload mutiple doc files
        public int docsUpload(String dir, String empid)
        {
            int docsCount = 0;
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf", Multiselect = true })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                byte[] bytes = File.ReadAllBytes(dialog.FileName);
                //Config to your doc directory
                String path = dir+"\\"+empid+" Docs";
               
                Directory.CreateDirectory(path);
                foreach(String file in dialog.SafeFileNames)
                {
                    File.WriteAllBytes(dir+"\\"+empid+" Docs" + "\\" + file, bytes);
                    docsCount++;
                }
                
               }
               return docsCount;  
            }
        }

        public String docUpload(String dir, String empid)
        {
            String path = "";
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "PDF Files (*.pdf)|*.pdf", Multiselect = true })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                   byte[] bytes = File.ReadAllBytes(dialog.FileName);
                   path = dir+"\\"+empid+".pdf";
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