using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace EDApp{
    public class PhotoHandler
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

        public Image browseUpload(string dir, string empid)
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
    }
}