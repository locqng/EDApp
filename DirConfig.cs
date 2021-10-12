using System.Windows.Forms;
using System.Configuration;


namespace EDApp
{
    public class DirConfig
    {
        private string photoDir;
        private string docDir;
        

        
        public string getPhotoDir()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the photos folder";
            dialog.UseDescriptionForTitle = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Photo directory saved!", "Directory Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try{
                    config.AppSettings.Settings["Key0"].Value = dialog.SelectedPath;
                    config.Save(ConfigurationSaveMode.Modified);
                    //MessageBox.Show("Photo directory saved!", "Directory Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ConfigurationErrorsException)
                {
                    MessageBox.Show("Error Writing Configuration File", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                photoDir = dialog.SelectedPath;
                
            
            }

            return photoDir;
        }
        public string getDocDir()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the documents folder";
            dialog.UseDescriptionForTitle = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Document directory saved!", "Directory Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try{
                    config.AppSettings.Settings["Key1"].Value = dialog.SelectedPath;
                    config.Save(ConfigurationSaveMode.Modified);
                    //MessageBox.Show("Document directory saved!", "Directory Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ConfigurationErrorsException)
                {
                    MessageBox.Show("Error Writing Configuration File", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                docDir = dialog.SelectedPath;
                
            }
            return docDir;
        }
    }
}