using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace EDApp{
    public class PhotoUpload
    {
        private Image photo;
        byte[] ConvertImageToBytes(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image browseUpload(string empid)
        {
            using(OpenFileDialog dialog = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpeg;*", Multiselect = false })
            {
               if(dialog.ShowDialog() == DialogResult.OK)
               {
                   photo = Image.FromFile(dialog.FileName);
                   File.WriteAllBytes("D:/EmpPhotos/"+empid+".png", ConvertImageToBytes(photo));
                                                    
                   return photo;
               } 
               return null;
            }
        }
    }
}