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
        private Panel printPanel;
        private Label lblID, lblName, lblAddress, lblPcode, lblDOB, lblGender, lblDoc;
        private Label valueID, valueName, valueAddress, valuePcode, valueDOB, valueGender, valueDoc;
        private Bitmap memoryImage;

        private PictureBox empPhoto = new PictureBox();

        private Button btnPrint = new Button();

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
        }

        //create the print frame 
        private void printFrame()
        {
            initializeElements();
            Console.WriteLine("Cool!");
            
            //set the form width & height 
            this.Width = 750;
            this.Height = 850;

            //set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //create the main panel
            printPanel = new Panel();
            printPanel.Width = 750;
            printPanel.Height = 850;
            printPanel.BackColor = Color.White;
            printPanel.Visible = true;

            //add print panel in the frame 
            this.Controls.Add(printPanel);

            //set location and font for Employee ID label
            lblID.Location = new Point(400,150);
            lblID.Text = "Employee ID: ";
            lblID.MaximumSize = new Size(120, 20);
            lblID.AutoSize = true;
            lblID.Font = new System.Drawing.Font("Century Gothic", 11, FontStyle.Bold);
            lblID.Visible = true;

            //set location and font for Employee ID value
            valueID.Location = new Point(520,149);
            valueID.Text = "Testing ID";
            valueID.MaximumSize = new Size(120, 20);
            valueID.AutoSize = true;
            valueID.Font = new System.Drawing.Font("Century Gothic", 11);
            valueID.Visible = true;

            //set location and font for Name label
            lblName.Location = new Point(400, 200);
            lblName.Text = "Name: ";
            lblName.MaximumSize = new Size (120, 20);
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Century Gothic", 11, FontStyle.Bold);
            lblName.Visible = true;

            //set location and font for Name value
            valueName.Location = new Point(520, 199);
            valueName.Text = "Testing Name";
            valueName.MaximumSize = new Size (200, 20);
            valueName.AutoSize = true;
            valueName.Font = new System.Drawing.Font("Century Gothic", 11);
            valueName.Visible = true;

            //set location and font for Gender label
            lblGender.Location = new Point(400, 250);
            lblGender.Text = "Gender: ";
            lblGender.MaximumSize = new Size (120, 20);
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Century Gothic", 11, FontStyle.Bold);
            lblGender.Visible = true;
            
            //set location and font for Gender value
            valueGender.Location = new Point(520, 249);
            valueGender.Text = "Female";
            valueGender.MaximumSize = new Size (120, 20);
            valueGender.AutoSize = true;
            valueGender.Font = new System.Drawing.Font("Century Gothic", 11);
            valueGender.Visible = true;

            //set location and font for DOB label
            lblDOB.Location = new Point(400, 300);
            lblDOB.Text = "DOB: ";
            lblDOB.MaximumSize = new Size (120, 20);
            lblDOB.AutoSize = true;
            lblDOB.Font = new System.Drawing.Font("Century Gothic", 11, FontStyle.Bold);
            lblDOB.Visible = true;

            //set location and font for DOB value
            valueDOB.Location = new Point(520, 299);
            valueDOB.Text = "21/Jan/1996";
            valueDOB.MaximumSize = new Size (120, 20);
            valueDOB.AutoSize = true;
            valueDOB.Font = new System.Drawing.Font("Century Gothic", 11);
            valueDOB.Visible = true;

            //set location and font for Address label
            lblAddress.Location = new Point(400, 350);
            lblAddress.Text = "Address: ";
            lblAddress.MaximumSize = new Size (120, 20);
            lblAddress.AutoSize = true;
            lblAddress.Font = new System.Drawing.Font("Century Gothic", 11, FontStyle.Bold);
            lblAddress.Visible = true;

            //set location and font for Address value
            valueAddress.Location = new Point(520, 349);
            valueAddress.Text = "Testing Address";
            valueAddress.MaximumSize = new Size (120, 20);
            valueAddress.AutoSize = true;
            valueAddress.Font = new System.Drawing.Font("Century Gothic", 11);
            valueAddress.Visible = true;

            //set location and font for Postcode label
            lblPcode.Location = new Point(400, 400);
            lblPcode.Text = "Postcode: ";
            lblPcode.MaximumSize = new Size (120, 20);
            lblPcode.AutoSize = true;
            lblPcode.Font = new System.Drawing.Font("Century Gothic", 11, FontStyle.Bold);
            lblPcode.Visible = true;

            //set location and font for Postcode value
            valuePcode.Location = new Point(520, 399);
            valuePcode.Text = "Testing Postcode";
            valuePcode.MaximumSize = new Size (120, 20);
            valuePcode.AutoSize = true;
            valuePcode.Font = new System.Drawing.Font("Century Gothic", 11);
            valuePcode.Visible = true;

            //set location for employee profile picture
            empPhoto.Location = new Point(120,160);
            empPhoto.Size = new Size(150, 150);
            empPhoto.BorderStyle = BorderStyle.Fixed3D;
            empPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            empPhoto.Image = empPhoto.InitialImage;

            //set location for print button 
            btnPrint.Location = new Point(600, 750);
            btnPrint.Text = "Print";
            btnPrint.MaximumSize = new Size(80,25);
            btnPrint.Click += new System.EventHandler(btnPrintClick);
            btnPrint.Show();
            
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
            printPanel.Controls.Add(btnPrint);
        }

        // event handler for print button 
        private void btnPrintClick(object sender, EventArgs e)
        {
            btnPrint.Hide();
            PrinterSettings printer = new PrinterSettings();
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            PrintDocument printDoc = new PrintDocument();
            getPrintArea(this.printPanel);
            printPreview.Document = printDoc;
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printPreview.ShowDialog();
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle printPage = e.PageBounds;
            e.Graphics.DrawImage(memoryImage, this.printPanel.Location.X, this.printPanel.Location.Y);            
        }

        // set printing area
        private void getPrintArea(Panel panel)
        {
            int width = panel.Width;
            int height = panel.Height;
            memoryImage = new Bitmap(width, height);
            panel.DrawToBitmap(memoryImage, new Rectangle(0, 0, width, height));
        }
    }

}