using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace EDApp
{
    public class PrintForm : Form
    {

        private ToolStripButton closeButton = new ToolStripButton();
        //Generate ToolStrip to reconfig the ToolStrip buttons for printer
        private ToolStrip toolBar = new ToolStrip();
        private ToolStripButton printButton = new ToolStripButton();
        private ToolStripComboBox printersList = new ToolStripComboBox();
    
        private PrintPreviewDialog printPreview = new PrintPreviewDialog();
        private PrintDocument printDoc = new PrintDocument();
        private Panel printPanel;
        private Label lblID, lblName, lblAddress, lblPcode, lblDOB, lblGender, lblDoc;
        private Label valueID, valueName, valueAddress, valuePcode, valueDOB, valueGender, valueDoc;
        private Bitmap btmPhoto;

        private PictureBox empPhoto = new PictureBox();

        private Button btnPrint = new Button();
        private Button btnCancel = new Button();

        public Label ValueID { get => valueID; set => valueID = value; }
        public Label ValueName { get => valueName; set => valueName = value; }
        public Label ValueAddress { get => valueAddress; set => valueAddress = value; }
        public Label ValuePcode { get => valuePcode; set => valuePcode = value; }
        public Label ValueDOB { get => valueDOB; set => valueDOB = value; }
        public Label ValueGender { get => valueGender; set => valueGender = value; }
        public Label ValueDoc { get => valueDoc; set => valueDoc = value; }
        public PictureBox EmpPhoto { get => empPhoto; set => empPhoto = value; }

        public PrintForm()
        {
            printFrame();
        }
        
        // create lables
        private void initializeElements()
        {
            lblID = new Label();
            lblName = new Label();
            lblAddress = new Label();
            lblPcode = new Label();
            lblDOB = new Label();
            lblGender = new Label();
            lblDoc = new Label();

            valueID = new Label();
            valueName = new Label();
            valueAddress = new Label();
            valuePcode = new Label();
            valueDOB = new Label();
            valueGender = new Label();
            valueDoc = new Label();

            printersList.Text = "Select a printer";
            printersList.TextChanged += new System.EventHandler(printersList_SelectionChanged);
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                printersList.Items.Add(printer);
            }
        }

        //create the print frame 
        private void printFrame()
        {
            initializeElements();
            Console.WriteLine("Cool!");
            
            //set the form width & height 
            this.Width = 768;
            this.Height = 1024;
            this.BackColor = Color.White;

            //set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //create the main panel
            printPanel = new Panel();
            printPanel.Width = 768;
            printPanel.Height = 824;
            printPanel.BackColor = Color.White;
            printPanel.Visible = true;

            //add print panel in the frame 
            this.Controls.Add(printPanel);

            //set location and font for Employee ID label
            lblID.Location = new Point(320, 250);
            lblID.Text = "Employee ID: ";
            lblID.MaximumSize = new Size(150, 50);
            lblID.AutoSize = true;
            lblID.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblID.Visible = true;

            //set location and font for Employee ID value
            valueID.Location = new Point(520, 250);
            valueID.Text = "Testing ID";
            valueID.MaximumSize = new Size(150, 50);
            valueID.AutoSize = true;
            valueID.Font = new System.Drawing.Font("Century Gothic", 15);
            valueID.Visible = true;

            //set location and font for Name label
            lblName.Location = new Point(320, 300);
            lblName.Text = "Name: ";
            lblName.MaximumSize = new Size (150, 50);
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblName.Visible = true;

            //set location and font for Name value
            valueName.Location = new Point(520, 300);
            valueName.Text = "Testing Name";
            valueName.MaximumSize = new Size (200, 20);
            valueName.AutoSize = true;
            valueName.Font = new System.Drawing.Font("Century Gothic", 15);
            valueName.Visible = true;

            //set location and font for Gender label
            lblGender.Location = new Point(320, 350);
            lblGender.Text = "Gender: ";
            lblGender.MaximumSize = new Size (150, 50);
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblGender.Visible = true;
            
            //set location and font for Gender value
            valueGender.Location = new Point(520, 349);
            valueGender.Text = "Female";
            valueGender.MaximumSize = new Size (150, 50);
            valueGender.AutoSize = true;
            valueGender.Font = new System.Drawing.Font("Century Gothic", 15);
            valueGender.Visible = true;

            //set location and font for DOB label
            lblDOB.Location = new Point(320, 400);
            lblDOB.Text = "DOB: ";
            lblDOB.MaximumSize = new Size (150, 50);
            lblDOB.AutoSize = true;
            lblDOB.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblDOB.Visible = true;

            //set location and font for DOB value
            valueDOB.Location = new Point(520, 400);
            valueDOB.Text = "21/Jan/1996";
            valueDOB.MaximumSize = new Size (150, 50);
            valueDOB.AutoSize = true;
            valueDOB.Font = new System.Drawing.Font("Century Gothic", 15);
            valueDOB.Visible = true;

            //set location and font for Address label
            lblAddress.Location = new Point(320, 450);
            lblAddress.Text = "Address: ";
            lblAddress.MaximumSize = new Size (150, 50);
            lblAddress.AutoSize = true;
            lblAddress.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblAddress.Visible = true;

            //set location and font for Address value
            valueAddress.Location = new Point(520, 449);
            valueAddress.Text = "Testing Address";
            valueAddress.MaximumSize = new Size (250, 50);
            valueAddress.AutoSize = true;
            valueAddress.Font = new System.Drawing.Font("Century Gothic", 15);
            valueAddress.Visible = true;

            //set location and font for Postcode label
            lblPcode.Location = new Point(320, 500);
            lblPcode.Text = "Postcode: ";
            lblPcode.MaximumSize = new Size (150, 50);
            lblPcode.AutoSize = true;
            lblPcode.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblPcode.Visible = true;

            //set location and font for Postcode value
            valuePcode.Location = new Point(520, 500);
            valuePcode.Text = "Testing Postcode";
            valuePcode.MaximumSize = new Size (150, 50);
            valuePcode.AutoSize = true;
            valuePcode.Font = new System.Drawing.Font("Century Gothic", 15);
            valuePcode.Visible = true;

            //set location for employee profile picture
            empPhoto.Location = new Point(30,260);
            empPhoto.Size = new Size(250, 250);
            empPhoto.BorderStyle = BorderStyle.Fixed3D;
            empPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            empPhoto.Image = empPhoto.InitialImage;

            //set location for print button 
            btnPrint.Location = new Point(520, 850);
            btnPrint.Text = "Print";
            btnPrint.MaximumSize = new Size(80,25);
            btnPrint.Click += new System.EventHandler(btnPrintClick);
            

            btnCancel.Location = new Point(620, 850);
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(80,25);
            btnCancel.Click += new System.EventHandler(btnCancelClick);
            
            
            // add labels and values in the print panel
            printPanel.Controls.Add(lblID);
            printPanel.Controls.Add(valueID);
            printPanel.Controls.Add(lblName);
            printPanel.Controls.Add(valueName);
            printPanel.Controls.Add(lblGender);
            printPanel.Controls.Add(valueGender);
            printPanel.Controls.Add(lblDOB);
            printPanel.Controls.Add(valueDOB);
            printPanel.Controls.Add(lblAddress);
            printPanel.Controls.Add(valueAddress);
            printPanel.Controls.Add(lblPcode);
            printPanel.Controls.Add(valuePcode);
            printPanel.Controls.Add(empPhoto);
            
            this.Controls.Add(btnPrint);
            this.Controls.Add(btnCancel);
        }

        // event handler for print button 
        private void btnPrintClick(object sender, EventArgs e)
        {
            
            
            
            foreach (Control control in printPreview.Controls)
            {
                Console.WriteLine(control.Name);
                if (control.Name.Equals("toolStrip1"))
                    toolBar = control as ToolStrip;
            }
            toolBar.Items.Add(printersList);

            
            foreach (ToolStripItem item in toolBar.Items)
            {
                Console.WriteLine(item.Name);
                if (item.Name.Equals("printToolStripButton"))
                {
                    printButton = item as ToolStripButton;
                    
                }
                else if(item.Name.Equals("closeToolStripButton"))
                {
                    closeButton = item as ToolStripButton;
                }
            }

            //getPrintArea(this.printPanel);
            printPreview.Document = printDoc;
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printPreview.UseAntiAlias = true;
            printButton.Click += new EventHandler(printButton_Click);
            
            printPreview.ShowDialog();   
            
            printButton.CheckOnClick = true;      
            
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font_bold = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            Font font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Regular);
            Brush blackBrush = new SolidBrush(Color.Black);
            Graphics graphics = e.Graphics;
            Rectangle printPage = e.PageBounds;
            graphics.DrawString("Employee ID:", font_bold, blackBrush, lblID.Location.X, lblID.Location.Y);
            graphics.DrawString(valueID.Text, font, blackBrush, valueID.Location.X, valueID.Location.Y);
            graphics.DrawString("Name:" ,font_bold, blackBrush, lblName.Location.X, lblName.Location.Y);
            graphics.DrawString(valueName.Text, font, blackBrush, valueName.Location.X, valueName.Location.Y);
            graphics.DrawString("Gender:", font_bold, blackBrush, lblGender.Location.X, lblGender.Location.Y);
            graphics.DrawString(valueGender.Text, font, blackBrush, valueGender.Location.X, valueGender.Location.Y);
            graphics.DrawString("DOB", font_bold, blackBrush, lblDOB.Location.X, lblDOB.Location.Y);
            graphics.DrawString(valueDOB.Text, font, blackBrush, valueDOB.Location.X, valueDOB.Location.Y);
            graphics.DrawString("Address", font_bold, blackBrush, lblAddress.Location.X, lblAddress.Location.Y);
            graphics.DrawString(valueAddress.Text, font, blackBrush, valueAddress.Location.X, valueAddress.Location.Y);
            graphics.DrawString("Postcode", font_bold, blackBrush, lblPcode.Location.X, lblPcode.Location.Y);
            graphics.DrawString(valuePcode.Text, font, blackBrush, valuePcode.Location.X, valuePcode.Location.Y);
            btmPhoto = new Bitmap(empPhoto.Image, empPhoto.Size);
            graphics.DrawImage(btmPhoto, empPhoto.Location.X, empPhoto.Location.Y);            
        }

        // set printing area
        //private void getPrintArea(Panel panel)
        //{
        //    memoryImage = new Bitmap(panel.Width, panel.Height);
        //    panel.DrawToBitmap(memoryImage, new Rectangle(0, 0, panel.Width, panel.Height));
        //}

        private void printButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Close clicked");
            printersList.SelectedIndex = -1;
            printersList.Text = "Select a printer";
            closeButton.PerformClick();
        }

        private void printersList_SelectionChanged(object sender, System.EventArgs e)
        {
            if (printersList.SelectedIndex != -1)
            {
                printDoc.PrinterSettings.PrinterName = printersList.Text;
                Console.WriteLine(printersList.Text);
            }
        }

    }

}