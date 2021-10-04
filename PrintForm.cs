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
        //New print button variable to add new action to the button
        private ToolStripButton printButton = new ToolStripButton();
        
        //Variable to store installed printers in the system
        private ToolStripComboBox printersList = new ToolStripComboBox();
    
        private PrintPreviewDialog printPreview = new PrintPreviewDialog();
        private PrintDocument printDoc = new PrintDocument();
        private Panel printPanel;
        private Label lblID, lblName, lblAddress, lblPcode, lblDOB, lblGender, lblDoc,lblTitle;
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
            lblTitle = new Label();
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
            this.Width = 825;
            this.Height = 1024;
            this.BackColor = Color.White;

            //set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //create the main panel
            printPanel = new Panel();
            printPanel.Width = 825;
            printPanel.Height = 600;
            printPanel.BackColor = Color.White;
            printPanel.Visible = true;

            //add print panel in the frame 
            this.Controls.Add(printPanel);

            // title for employee information details
            lblTitle.Location = new Point(0, 50);
            lblTitle.Text = "Employee Information Details";
            lblTitle.Size = new Size(825, 50);
            lblTitle.Font = new System.Drawing.Font("Century Gothic", 22, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.BackColor = Color.DodgerBlue;
            lblTitle.ForeColor = Color.White;
            lblTitle.Visible = true;

            //set location and font for Employee ID label
            lblID.Location = new Point(320, 150);
            lblID.Text = "Employee ID: ";
            lblID.MaximumSize = new Size(150, 50);
            lblID.AutoSize = true;
            lblID.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblID.Visible = true;

            //set location and font for Employee ID value
            valueID.Location = new Point(520, 150);
            valueID.Text = "Testing ID";
            valueID.Size = new Size(150, 50);
            //valueID.AutoSize = true;
            valueID.Font = new System.Drawing.Font("Century Gothic", 15);
            valueID.Visible = true;

            //set location and font for Name label
            lblName.Location = new Point(320, 220);
            lblName.Text = "Name: ";
            lblName.MaximumSize = new Size (150, 50);
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblName.Visible = true;

            //set location and font for Name value
            valueName.Location = new Point(520, 220);
            valueName.Text = "Testing Name";
            valueName.Size = new Size (200, 20);
           // valueName.AutoSize = true;
            valueName.Font = new System.Drawing.Font("Century Gothic", 15);
            valueName.Visible = true;

            //set location and font for Gender label
            lblGender.Location = new Point(320, 290);
            lblGender.Text = "Gender: ";
            lblGender.MaximumSize = new Size (150, 50);
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblGender.Visible = true;
            
            //set location and font for Gender value
            valueGender.Location = new Point(520, 289);
            valueGender.Text = "Female";
            valueGender.Size = new Size (150, 50);
            //valueGender.AutoSize = true;
            valueGender.Font = new System.Drawing.Font("Century Gothic", 15);
            valueGender.Visible = true;

            //set location and font for DOB label
            lblDOB.Location = new Point(320, 360);
            lblDOB.Text = "DOB: ";
            lblDOB.MaximumSize = new Size (150, 50);
            lblDOB.AutoSize = true;
            lblDOB.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblDOB.Visible = true;

            //set location and font for DOB value
            valueDOB.Location = new Point(520, 360);
            valueDOB.Text = "21/Jan/1996";
            valueDOB.Size = new Size (150, 50);
            //valueDOB.AutoSize = true;
            valueDOB.Font = new System.Drawing.Font("Century Gothic", 15);
            valueDOB.Visible = true;

            //set location and font for Address label
            lblAddress.Location = new Point(320, 430);
            lblAddress.Text = "Address: ";
            lblAddress.MaximumSize = new Size (150, 50);
            lblAddress.AutoSize = true;
            lblAddress.Font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            lblAddress.Visible = true;

            //set location and font for Address value
            valueAddress.Location = new Point(520, 430);
            valueAddress.Text = "Testing Address";
            valueAddress.Size = new Size (200, 50);
            //valueAddress.AutoSize = true;
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
            valuePcode.Size = new Size (150, 50);
            //valuePcode.AutoSize = true;
            valuePcode.Font = new System.Drawing.Font("Century Gothic", 15);
            valuePcode.Visible = true;

            //set location for employee profile picture
            empPhoto.Location = new Point(30,150);
            empPhoto.Size = new Size(250, 250);
            empPhoto.BorderStyle = BorderStyle.Fixed3D;
            empPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            empPhoto.Image = empPhoto.InitialImage;

            //set location for print button 
            btnPrint.Location = new Point(500, 680);
            btnPrint.Text = "Print";
            btnPrint.Size = new Size(100,25);
            btnPrint.Font = new System.Drawing.Font("Century Gothic", 13);
            btnPrint.Click += new System.EventHandler(btnPrintClick);
            

            btnCancel.Location = new Point(620, 680);
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100,25);
            btnCancel.Font = new System.Drawing.Font("Century Gothic", 13);
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
            printPanel.Controls.Add(lblTitle);
            
            this.Controls.Add(btnPrint);
            this.Controls.Add(btnCancel);
        }

        // event handler for print button 
        private void btnPrintClick(object sender, EventArgs e)
        {
            
            
            //Find the default control of the print preview dialogue
            foreach (Control control in printPreview.Controls)
            {
                Console.WriteLine(control.Name);
                //Get the exact name of the control we need
                if (control.Name.Equals("toolStrip1"))
                    toolBar = control as ToolStrip;
            }
            //Add installed printers to the newly created control
            toolBar.Items.Add(printersList);

            //Find the two buttons from the tool bar to add new action to add new actions to them
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

        //Print page setup, print strings instead of the form
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            printersList.Size= new System.Drawing.Size(180, 30);
            Graphics graphics = e.Graphics;

            //Set font for the print
            Font font_bold = new System.Drawing.Font("Century Gothic", 15, FontStyle.Bold);
            Font font = new System.Drawing.Font("Century Gothic", 15, FontStyle.Regular);

            //Calculate string size
            

            //Color the string
            Brush blackBrush = new SolidBrush(Color.Black);
            
            RectangleF printPage = e.PageBounds;

            //Drawing the print page
            graphics.DrawString("Employee ID:", font_bold, blackBrush, new RectangleF(lblID.Location, lblID.Size));
            graphics.DrawString(valueID.Text, font, blackBrush, new RectangleF(valueID.Location, valueID.Size));
            graphics.DrawString("Name:" ,font_bold, blackBrush, new RectangleF(lblName.Location, lblName.Size));
            graphics.DrawString(valueName.Text, font, blackBrush, new RectangleF(valueName.Location, valueName.Size));
            graphics.DrawString("Gender:", font_bold, blackBrush, new RectangleF(lblGender.Location, lblGender.Size));
            graphics.DrawString(valueGender.Text, font, blackBrush, new RectangleF(valueGender.Location, valueGender.Size));
            graphics.DrawString("DOB", font_bold, blackBrush, new RectangleF(lblDOB.Location, lblDOB.Size));
            graphics.DrawString(valueDOB.Text, font, blackBrush, new RectangleF(valueDOB.Location, valueDOB.Size));
            graphics.DrawString("Address", font_bold, blackBrush, new RectangleF(lblAddress.Location, lblAddress.Size));
            graphics.DrawString(valueAddress.Text, font, blackBrush, new RectangleF(valueAddress.Location, valueAddress.Size));
            graphics.DrawString("Postcode", font_bold, blackBrush, new RectangleF(lblPcode.Location, lblPcode.Size));
            graphics.DrawString(valuePcode.Text, font, blackBrush, new RectangleF(valuePcode.Location, valuePcode.Size));
            btmPhoto = new Bitmap(empPhoto.Image, empPhoto.Size);
            graphics.DrawImage(btmPhoto, empPhoto.Location.X, empPhoto.Location.Y);    

            // drawing for title 
            SolidBrush titleBackgroundBrush = new SolidBrush(Color.DodgerBlue);
            SolidBrush  titleTextBrush = new SolidBrush(Color.White);
            RectangleF rectTitle = new Rectangle(lblTitle.Location, lblTitle.Size);
            graphics.FillRectangle(titleBackgroundBrush, rectTitle);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(lblTitle.Text, lblTitle.Font, titleTextBrush, rectTitle,sf);
        
        }

        // set printing area
        //private void getPrintArea(Panel panel)
        //{
        //    memoryImage = new Bitmap(panel.Width, panel.Height);
        //    panel.DrawToBitmap(memoryImage, new Rectangle(0, 0, panel.Width, panel.Height));
        //}


        //Close the preview after printing
        private void printButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Close clicked");
            printersList.SelectedIndex = -1;
            printersList.Text = "Select a printer";
            closeButton.PerformClick();
        }

        //Change the target printer to the selected option
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