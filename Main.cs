using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace EDApp{

    //test for git
    public class mainProgram: Form {
        
        //Directories for photos and documents
        private String photoDir = "";
        private String docDir = "";
        //ID variables to handle photo upload
        private String id = "";
        //Int variables to count documents
        private int docCount = 0;
        //Generating form text box for input
        private static TextBox txbID = new TextBox();
        private TextBox txbFname = new TextBox();
        private TextBox txbLname = new TextBox();  
        private TextBox txbAddress = new TextBox();                 
        private TextBox txbPcode = new TextBox();
        //private TextBox txbDOB = new TextBox();
        private TextBox txbGender = new TextBox();
        private TextBox txbPhoto = new TextBox();
        private TextBox txbDoc = new TextBox();
        private TextBox txbSearch = new TextBox();
        private Panel viewPanel, formPanel, selectPanel;
        //public Panel topPanel;
        private DataGridView gridViewTable = new DataGridView();

        //Date time picker
        private DateTimePicker dobPicker = new DateTimePicker();

        //Generating Function buttons 
        private Button btnAdd = new Button();
        private Button btnDelete = new Button();
        private Button btnExit = new Button();
        private Button btnSearch = new Button();
        private Button btnUpdate = new Button();
        private Button btnAddNew = new Button();
        private Button btnClear = new Button();
        private Button btnBack = new Button();
        private Button btnBrowse = new Button();
        private Button btnUpload = new Button();
        private Button btnprintToPdf = new Button();
        private Button btnPrintEmp = new Button();
        private Button btnempImg = new Button();
        private Button btndeptImg = new Button();
             
        //Generating form labels
        private Label lblID = new Label();
        private Label lblFname = new Label();
        private Label lblLname = new Label();
        private Label lblAddress = new Label();
        private Label lblPcode = new Label();
        private Label lblDOB = new Label(); 
        private Label lblGender = new Label();
        private Label lblPhoto = new Label();
        private Label lblDoc = new Label();
        
        private Label lblWelcome = new Label();
        private Label lblempTable = new Label();
        private Label lbldeptTable = new Label();
        private Label lblbottom = new Label();
        


        // image 
        System.Drawing.Image empIconImg = System.Drawing.Image.FromFile( @"Resources\emp.PNG" );
        System.Drawing.Image deptIconImg = System.Drawing.Image.FromFile( @"Resources\department.png" );
        System.Drawing.Image homeImg = System.Drawing.Image.FromFile( @"Resources\home.png");

        //Gerating Image box for photos
        private PictureBox empPhoto = new PictureBox();

        //create menu bar 
        private MenuStrip ms;
        private ToolStripMenuItem mnuSelectTable;
        private ToolStripMenuItem mnuEmp,mnuDept;
        
        //Constructor
        public mainProgram(String pD, String dD){
            photoDir = pD;
            docDir = dD; 
            startFrame();
        }
         
        //haven't done for department table 
        public void startFrame()
        {
            //Set the form width & height 
            this.Width = 800;
            this.Height = 600;

            this.StartPosition = FormStartPosition.CenterScreen;

            selectPanel = new Panel();
            selectPanel .Width = 800;
            selectPanel.Height = 580;
            selectPanel .Visible = true;
            

            lblWelcome.Text = "Desktop Application";
            lblWelcome.Font = new System.Drawing.Font("Arial", 24,FontStyle.Bold);
            lblWelcome.Location = new Point(0,0);
            lblWelcome.Size = new Size(800,100);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.BackColor = Color.LightSkyBlue;
            lblWelcome.Image = homeImg;
            lblWelcome.ImageAlign = ContentAlignment.MiddleLeft;

            btnempImg.Location = new Point(160,200);
            btnempImg.Size = new Size(160,160);
            btnempImg.BackgroundImage = empIconImg;
            btnempImg.Click += new System.EventHandler(btnempImgClick);

            lblempTable.Text = "Employee";
            lblempTable.Font = new System.Drawing.Font("Arial", 11,FontStyle.Bold);
            lblempTable.Location = new Point(160,360);
            lblempTable.Size = new Size(160,30);
            lblempTable.TextAlign = ContentAlignment.MiddleCenter;

            lbldeptTable.Text = "Department";
            lbldeptTable.Font = new System.Drawing.Font("Arial", 11,FontStyle.Bold);
            lbldeptTable.Location = new Point(480,360);
            lbldeptTable.Size = new Size(160,30);
            lbldeptTable.TextAlign = ContentAlignment.MiddleCenter;

            lblbottom.Location = new Point(0,520);
            lblbottom.Size = new Size(800,50);
            lblbottom.BackColor = Color.LightSkyBlue;


            btndeptImg .Location = new Point(480,200);
            btndeptImg .Size = new Size(160,160);
            btndeptImg .BackgroundImage = deptIconImg;
            //btndeptImg.Click += new System.EventHandler(btndeptImgClick);

            this.Controls.Add(selectPanel);
            selectPanel.Controls.Add(lblWelcome);
            selectPanel.Controls.Add(btnempImg);
            selectPanel.Controls.Add(btndeptImg );
            selectPanel.Controls.Add(lblempTable);
            selectPanel.Controls.Add(lbldeptTable);
            selectPanel.Controls.Add(lblbottom);
        }

         public void btnempImgClick(object sender, EventArgs e)
        {
            menuFrame();
            createTable();
            viewRecords("");
            selectPanel.Visible = false;
        }

        public void menuFrame()
        {
            //Set the form width & height 
            this.Width = 800;
            this.Height = 600;

            //Set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //Creating the main panel
            viewPanel = new Panel();
            viewPanel.Width = 800;
            viewPanel.Height = 580;
            viewPanel.Visible = true;

            //Creating the sub panel
            formPanel = new Panel();
            formPanel.Width = 800;
            formPanel.Height = 580;
            formPanel.Font = new System.Drawing.Font("Arial", 10);
            formPanel.Visible = false;

            // Create a MenuStrip control 
            ms = new MenuStrip();
            mnuSelectTable = new ToolStripMenuItem("Switch Table");
            mnuSelectTable.Font = new System.Drawing.Font("Arial", 12,FontStyle.Bold);
            ms.BackColor = Color.LightSkyBlue;


            mnuEmp = new ToolStripMenuItem("Employee");
            mnuDept = new ToolStripMenuItem("Department");
            
            ((ToolStripDropDownMenu)(mnuSelectTable.DropDown)).ShowImageMargin = false;
            //((ToolStripDropDownMenu)(mnuSelectTable.DropDown)).ShowCheckMargin = true;

            mnuEmp.Click += new System.EventHandler(mnuEmp_Click);
            //mnuDept.Click += new System.EventHandler(mnuDept_Click);

            // Assign the ToolStripMenuItem that displays 
            ms.MdiWindowListItem = mnuSelectTable;
            
            // Add the window ToolStripMenuItem to the MenuStrip.
            ms.Items.Add(mnuSelectTable);

            // Dock the MenuStrip at the top of the form.
            ms.Dock = DockStyle.Top;

            //Add the ToolStripMenuItem to the MenuStrip
            mnuSelectTable.DropDownItems.Add(mnuEmp);
            mnuSelectTable.DropDownItems.Add(mnuDept);

            // Add the MenuStrip
            viewPanel.Controls.Add(ms);

            //Add button 
            btnAdd.Location = new Point(20,500);
            btnAdd.Text = "Add";
            btnAdd.Size = new Size(80,25);
            btnAdd.Click += new System.EventHandler(btnAddClick);

            //Clear button
            btnClear.Location = new Point(120, 500);
            btnClear.Text = "Clear";
            btnClear.Size = new Size(80,25);
            btnClear.Visible = true;
            btnClear.Click += new System.EventHandler(btnClearClick);

            //Update Button
            btnUpdate.Location = new Point(20,500);
            btnUpdate.Text = "Update";
            btnUpdate.Size = new Size(80,25);
            btnUpdate.Visible = true;
            btnUpdate.Click += new System.EventHandler(btnUpdateClick);

            //Delete button 
            btnDelete.Location = new Point(220,500);
            btnDelete.Text = "Delete";
            btnDelete.Size = new Size(80,25);
            btnDelete.Click += new System.EventHandler(btnDeleteClick);

            //Add new Record button to change to form panel
            btnAddNew.Location = new Point(20, 500);
            btnAddNew.Text = "New Record";
            btnAddNew.Font = new System.Drawing.Font("Arial", 10);
            btnAddNew.Size = new Size(100,25);
            btnAddNew.Visible = true;
            btnAddNew.Click += new System.EventHandler(btnAddNewClick);

            //Go back button 
            btnBack.Location = new Point(570, 500);
            btnBack.Text = "Cancel";
            btnBack.Size = new Size(80,25);
            btnBack.Click += new System.EventHandler(btnBackClick);

            //print to pdf button
            btnprintToPdf.Location = new Point(670, 500);
            btnprintToPdf.Text = "Print to PDF";
            btnprintToPdf.Size = new Size(100,25);
            btnprintToPdf.Visible = true;
            btnprintToPdf.Click += new System.EventHandler(btnprintToPdfClick);

            //Print an individual employee
            btnPrintEmp.Location = new Point(670, 500);     
            btnPrintEmp.Text = "Print";
            btnPrintEmp.Size = new Size(80,25);
            btnPrintEmp.Visible = true;
            btnPrintEmp.Click += new System.EventHandler(btnPrintEmpClick);


            //Browse image button
            btnBrowse.Location = new Point(620, 180);
            btnBrowse.Text = "Browse";
            btnBrowse.Size = new Size(80, 25);
            btnBrowse.Click += new System.EventHandler(btnBrowseClick);

            //Upload document button
            btnUpload.Location = new Point(390, 378);
            btnUpload.Text = "Upload";
            btnUpload.Size = new Size(80, 25);
            btnUpload.Click += new System.EventHandler(btnUploadClick);

            //Exit button 
            btnExit.Location = new Point(680,500);
            btnExit.Text = "Exit";
            btnExit.Size = new Size(80,25);
            btnExit.Click += new System.EventHandler(btnExitClick);

            //Setting labels and text boxes size and location
            //Employee ID
            lblID.Text = "Employee ID";
            lblID.Location = new Point(20,62);
            lblID.Size = new Size(100,20);
    
            txbID.Location = new Point(120,60);
            txbID.Size = new Size(120,25);
            
            //First name 
            lblFname.Text = "First Name";
            lblFname.Location = new Point(20,102);
            lblFname.Size = new Size(100,20);
            
            txbFname.Location = new Point(120,100);
            txbFname.Size = new Size(120,20);

            //Last name
            lblLname.Text = "Last Name";
            lblLname.Location = new Point(20,142);
            lblLname.Size = new Size(100,20);
            
            txbLname.Location = new Point(120,140);
            txbLname.Size = new Size(120,20);

            //Address 
            lblAddress.Text = "Address";
            lblAddress.Location = new Point(20,182);
            lblAddress.Size = new Size(100,20);
            
            txbAddress.Location = new Point(120,180);
            txbAddress.Size = new Size(250,20);

            //Postcode
            lblPcode.Text = "Postcode";
            lblPcode.Location = new Point(20,222);
            lblPcode.Size = new Size(100,20);
            
            txbPcode.Location = new Point(120,220);
            txbPcode.Size = new Size(120,20);
            
            //DoB
            lblDOB.Text = "DOB";
            lblDOB.Location = new Point(20,262);
            lblDOB.Size = new Size(100,20);
            
            //Gender
            lblGender.Text = "Gender";
            lblGender.Location = new Point(20,302);
            lblGender.Size = new Size(100,20);
            
            txbGender.Location = new Point(120,300);
            txbGender.Size = new Size(120,20);

            //Photo
            lblPhoto.Text = "Photo";
            lblPhoto.Location = new Point(20,342);
            lblPhoto.Size = new Size(100,20);
            
            txbPhoto.Location = new Point(120,340);
            txbPhoto.Size = new Size(250,20);
            //txbPhoto.ReadOnly = fasle;

            //Document
            lblDoc.Text = "Document";
            lblDoc.Location = new Point(20,382);
            lblDoc.Size = new Size(100,20);
            
            txbDoc.Location = new Point(120,380);
            txbDoc.Size = new Size(250,20);
            txbDoc.ReadOnly = true;

            //Photo box
            empPhoto.Location = new Point(600,52);
            empPhoto.Size = new Size(120, 120);
            empPhoto.BorderStyle = BorderStyle.Fixed3D;
            empPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //Search box for view sub panel
            txbSearch.Location = new Point(20,50);
            txbSearch.Size = new Size(250,25);
            txbSearch.KeyDown += App_KeyDown;

            btnSearch.Location = new Point(280,49);
            btnSearch.Text = "Search";
            btnSearch.Font = new System.Drawing.Font("Arial", 10);
            btnSearch.Size = new Size(80,25);
            btnSearch.Click += new System.EventHandler(btnSearchClick);
            
            //Generate the grid view table for sub panel
            gridViewTable.Name = "dataTableGridView";
            gridViewTable.Location = new Point(20,100);
            gridViewTable.Size = new Size(750,380);
            gridViewTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            gridViewTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridViewTable.AllowUserToAddRows = false; 
            gridViewTable.CellClick += gridViewTable_CellClick;

            //Date Time Picker
            dobPicker.Location = new Point(120,260);
            dobPicker.Format = DateTimePickerFormat.Custom;
            dobPicker.CustomFormat = "dd/MMM/yyyy";
            dobPicker.MinDate = new DateTime(1930, 01, 01);
            dobPicker.MaxDate = DateTime.Now;
            
            //Adding elements to win form
            //this.Controls.Add(topPanel);
            this.Controls.Add(viewPanel);
            this.Controls.Add(formPanel);

            // adding labels in form panel
            formPanel.Controls.Add(lblID);
            formPanel.Controls.Add(lblFname);
            formPanel.Controls.Add(lblLname);
            formPanel.Controls.Add(lblPcode);
            formPanel.Controls.Add(lblAddress);
            formPanel.Controls.Add(lblDOB);
            formPanel.Controls.Add(lblGender);
            formPanel.Controls.Add(lblPhoto);
            formPanel.Controls.Add(lblDoc);  

            // adding text field in form panel 
            formPanel.Controls.Add(txbID);
            formPanel.Controls.Add(txbFname);
            formPanel.Controls.Add(txbLname);       
            formPanel.Controls.Add(txbAddress);
            formPanel.Controls.Add(txbPcode);
            formPanel.Controls.Add(dobPicker);
            formPanel.Controls.Add(txbGender);
            formPanel.Controls.Add(txbPhoto);
            formPanel.Controls.Add(txbDoc);

            // adding function buttons in form panel
            formPanel.Controls.Add(btnAdd);
            formPanel.Controls.Add(btnDelete);
            
            // formPanel.Controls.Add(btnExit);
            formPanel.Controls.Add(btnUpdate);
            formPanel.Controls.Add(btnBack);
            formPanel.Controls.Add(btnClear);
            formPanel.Controls.Add(btnBrowse);
            formPanel.Controls.Add(btnUpload);
            formPanel.Controls.Add(btnPrintEmp);
            
            // adding photo box in form panel
            formPanel.Controls.Add(empPhoto);

            //Add grid table to the view panel
            viewPanel.Controls.Add(gridViewTable);
            viewPanel.Controls.Add(txbSearch);
            viewPanel.Controls.Add(btnSearch);
            viewPanel.Controls.Add(btnAddNew);
            //viewPanel.Controls.Add(btnExit);
            viewPanel.Controls.Add(btnprintToPdf);    
        }

        //create function when employee table is clicked
        public void mnuEmp_Click(object sender, EventArgs e)
        {
            viewPanel.Visible =true;
        }
        
        //create function when employee table is clicked 
        //need to be done for department table!!
//         public void mnuDept_Click(object sender, EventArgs e)
//         {
            
//         }
        
        
        //Add button event handler
        private void btnAddClick(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txbID.Text.Trim())||
                string.IsNullOrEmpty(txbFname.Text.Trim())||
                string.IsNullOrEmpty(txbLname.Text.Trim())|| 
                string.IsNullOrEmpty(txbPcode.Text.Trim())|| 
                string.IsNullOrEmpty(txbAddress.Text.Trim())|| 
                string.IsNullOrEmpty(dobPicker.Text.Trim())|| 
                string.IsNullOrEmpty(txbGender.Text.Trim()))
             
            {
                MessageBox.Show("Please enter information", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (searchEmployeeID()>0)
            {
                
                MessageBox.Show("Employee ID exists");
                return;
            }

            try
            {
                this.id = txbID.Text.Trim();
                CRUD.sql = "INSERT INTO employee(empid, FirstName, LastName,address,postcode, DOB ,gender,photo,document) VALUES(@empID, @firstName, @lastName,@address,@postcode,@DOB,@gender,@photo,@document)";
                sqlExecute(CRUD.sql);
                clearTextbox("clean");
                
                try
                {
                    File.Delete(photoDir+"\\"+this.id+".png");
                    File.Move(photoDir+"\\"+this.id+"_new.png", photoDir+"\\"+this.id+".png");
                }
                catch(FileNotFoundException)
                {
                    //Do nothing
                }
                clearTextbox("clean");
                viewRecords("");
                DialogResult dialogResult = MessageBox.Show("Record saved! Add another record?", "Adding Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);         
                
                if (dialogResult == DialogResult.Yes)
                {
                    btnAddNew.PerformClick();
                }
                
                else 
                {
                    viewPanel.Visible = true;
                    viewRecords("");
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // check for the entered empid, see if it already exists
        private int searchEmployeeID()
        {
            CRUD.sql = "select * from employee where empid = @empID";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("@empID", txbID.Text.Trim().ToString());
            DataTable table = CRUD.PerformCRUD(CRUD.cmd);
            
            return table.Rows.Count;
            
            
        }

        //Search button event handler
        private void btnSearchClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearch.Text.Trim()))
            {
                viewRecords("");
            }
            else
            {
                viewRecords(txbSearch.Text.Trim());
            }
            clearTextbox("clean");
        }
        
        //Update button event Handler
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbID.Text.Trim())||
            string.IsNullOrEmpty(txbFname.Text.Trim()) ||
             string.IsNullOrEmpty(txbLname.Text.Trim())|| 
             string.IsNullOrEmpty(txbPcode.Text.Trim())|| 
             string.IsNullOrEmpty(txbAddress.Text.Trim())|| 
             string.IsNullOrEmpty(dobPicker.Text.Trim())|| 
             string.IsNullOrEmpty(txbGender.Text.Trim()))
             
            {
                MessageBox.Show("Please enter information", "Updating Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try 
            {
                CRUD.sql = "UPDATE employee SET FirstName = @firstName, LastName = @lastName, " + 
                "address = @address, postcode = @postcode, DOB = @DOB, gender = @gender, photo = @photo, document = @document " +
                "WHERE empid = @empid";
                sqlExecute(CRUD.sql);
                MessageBox.Show("Record saved", "Updating Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewPanel.Visible = true;
                //topPanel.Visible = true;
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
                txbID.ReadOnly = false;
                this.id = txbID.Text;
                try{
                    File.Move(docDir+"\\"+this.id+"_new.pdf", docDir+"\\"+this.id+".pdf");
                }
                catch(FileNotFoundException)
                {
                    //MessageBox.Show("Cannot update doc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Do nothing
                }
                //The employee already have a document
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if(ex.Message.Contains("exists"))
                    {
                        
                        File.Delete(docDir+"\\"+this.id+".pdf");
                        File.Move(docDir+"\\"+this.id+"_new.pdf", docDir+"\\"+this.id+".pdf");
                    }
                }
                try{
                    File.Move(photoDir+"\\"+this.id+"_new.png", photoDir+"\\"+this.id+".png");
                }
                catch(FileNotFoundException)
                {
                    //MessageBox.Show("Cannot update photos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Do nothing
                }
                //The employee already have an image
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if(ex.Message.Contains("exists"))
                    {
                        
                        File.Delete(photoDir+"\\"+this.id+".png");
                        File.Move(photoDir+"\\"+this.id+"_new.png", photoDir+"\\"+this.id+".png");
                    }
                }
                clearTextbox("clean");
                viewRecords("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Delete button event handler 
        private void btnDeleteClick(object sender, EventArgs e)
        { 
            try
            {
                DialogResult dialogResult = MessageBox.Show("You are about to delete the record of " + txbID.Text, "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                    {
                        CRUD.sql= "Delete from employee where empid = @empID;";
                        sqlExecute(CRUD.sql);  
                        MessageBox.Show("Record deleted!" , "Deleting Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        viewPanel.Visible = true;
                        //topPanel.Visible = true;
                        clearTextbox("clean");
                        txbID.ReadOnly = false;
                        try{
                            File.Delete(photoDir+"\\"+this.id+".png");
                        }
                        catch(FileNotFoundException)
                        {
                            //MessageBox.Show("Cannot update photos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Do nothing
                        }
                clearTextbox("clean");
                viewRecords("");
                        viewRecords("");
                    }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Clear button event handler
        private void btnBackClick(object sender, EventArgs e)
        {
            clearTextbox("clean");
            txbID.ReadOnly = false;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            viewPanel.Visible = true;
            viewRecords("");

        }

        //Add new record (change to form panel) button event handler
        private void btnAddNewClick(object sender, EventArgs e)
        {
            empPhoto.Image = null;
            clearTextbox("clean");
            viewPanel.Visible = false;
            formPanel.Visible = true;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            btnDelete.Visible = false;

        }

        //Clear form button
        private void btnClearClick (object sender, EventArgs e)
        {  
            if (btnUpdate.Visible == true)
                clearTextbox("");
            else
                clearTextbox("clean");

            try
            {
                File.Delete(photoDir+"\\"+this.id+"_new.png");
            }
            catch(FileNotFoundException)
            {
                //MessageBox.Show("Cannot update photos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Do nothing

            }
        }


        //Upload image - Browse button event handler
        private void btnBrowseClick (object sender, EventArgs e)
        {
            this.id = txbID.Text;
            FileHandler upload = new FileHandler();
            if (txbID.Text != "")
            {
                System.Drawing.Image newImage;
                newImage = upload.browseUpload(photoDir, txbID.Text+"_new");
                if (newImage != null)
                {
                    txbPhoto.Text = photoDir + "\\" + txbID.Text+".png";
                    empPhoto.Image = newImage;
                }
                else
                {
                    return;
                }
            }
            else{
                MessageBox.Show("Please enter the Employee ID", "Uploading photo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //Upload document - Upload button event handler
        private void btnUploadClick (object sender, EventArgs e)
        {
            this.id = txbID.Text;
            FileHandler upload = new FileHandler();
            if (txbID.Text != "")
            {
                String newDoc = upload.docUpload(docDir, txbID.Text+"_new");
                if (newDoc != "")
                {
                    txbDoc.Text = docDir + "\\" + txbID.Text+".pdf";
                    //For multiple docs
                    //this.docCount = docCount + newDoc;
                    //txbDoc.Text = docCount.ToString();
                }

                else
                {
                    return;
                }
                
            }
            else{
                MessageBox.Show("Please enter the Employee ID", "Uploading documents", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }  
        //Print one employee button event handler
        private void btnPrintEmpClick(object sender, EventArgs e) 
        {
            PrintForm print = new PrintForm();
            print.ValueID.Text = txbID.Text;
            print.ValueName.Text = txbFname.Text + " " + txbLname.Text;
            print.ValueGender.Text = txbGender.Text;
            print.ValueDOB.Text = dobPicker.Text;
            print.ValueAddress.Text = txbAddress.Text;
            print.ValuePcode.Text = txbPcode.Text;
            print.EmpPhoto.Image = empPhoto.Image;
            print.ShowDialog();
        }

        //Exit button event handler
        private void btnExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void App_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();              
                e.SuppressKeyPress = true;
            }
        }
        
        // clear textbox
        private void clearTextbox(string function)
        {
            //If call from Update function won't use "Clean"
            if (function == "clean")
            {
                txbID.Text = "";
            }
            txbFname.Text = "";
            txbLname.Text = "";
            txbPcode.Text = "";
            txbAddress.Text = "";
            dobPicker.Value = dobPicker.MaxDate;
            txbGender.Text = "";
            txbPhoto.Text = "";
            txbDoc.Text = "";
            txbSearch.Text = "";
            empPhoto.Image = null;
            
        }

        // create table
        private void createTable()
        {
            try
            {
                CRUD.sql= "CREATE TABLE IF NOT EXISTS `employee`(empid char(20) not null, FirstName char(255), LastName char(255),address char(255),postcode char(255), DOB char(255), gender char(255) ,photo char(255),document char(255), primary key(empid));";
                sqlExecute(CRUD.sql);  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Creating table" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //View record, accept search keyword as parameter to show results
        private void viewRecords(string search)
        {
            try{      
                CRUD.sql = "SELECT empid, FirstName, LastName, address, postcode, DOB, gender, photo, document FROM Employee " +
                            "WHERE empid LIKE @kwExact OR CONCAT(FirstName, ' ', LastName) LIKE @kw OR address LIKE @kw OR postcode LIKE @kwExact " +
                            "OR DOB LIKE @kw OR gender LIKE @kw ORDER BY empid ASC";
                string kw = String.Format("%{0}%", search);
                
                CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                CRUD.cmd.Parameters.Clear();
                CRUD.cmd.Parameters.AddWithValue("kw", kw);
                CRUD.cmd.Parameters.AddWithValue("kwExact", search);


                DataTable table = CRUD.PerformCRUD(CRUD.cmd);


                gridViewTable.MultiSelect = false;
                gridViewTable.AutoGenerateColumns = true;
                gridViewTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridViewTable.DataSource = table;

                gridViewTable.Columns[0].HeaderText = "EmpID";
                gridViewTable.Columns[1].HeaderText = "First Name";
                gridViewTable.Columns[2].HeaderText = "Last Name";
                gridViewTable.Columns[3].HeaderText = "Address";
                gridViewTable.Columns[4].HeaderText = "Postcode";
                gridViewTable.Columns[5].HeaderText = "DOB";
                gridViewTable.Columns[6].HeaderText = "Gender";
                gridViewTable.Columns[7].HeaderText = "Photo";
                gridViewTable.Columns[8].HeaderText = "Document";

                gridViewTable.Columns[0].Width = 50;
                gridViewTable.Columns[1].Width = 80;
                gridViewTable.Columns[2].Width = 80;
                gridViewTable.Columns[3].Width = 170;
                gridViewTable.Columns[4].Width = 60;
                gridViewTable.Columns[5].Width = 80;
                gridViewTable.Columns[6].Width = 50;
                gridViewTable.Columns[7].Width = 50;
                gridViewTable.Columns[8].Width = 85;
            

                try
                {
                    File.Delete(photoDir + "\\"+ this.id+"_new.png");
                    File.Delete(docDir + "\\"+ this.id+"_new.pdf");
                }
                
                catch (FileNotFoundException)
                {
                    //Do nothing
                    return;
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("Generating table... Click search again for the new table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CRUD.sql= "CREATE TABLE IF NOT EXISTS `employee`(empid char(20) not null, FirstName char(255), LastName char(255),address char(255),postcode char(255), DOB char(255), gender char(255) ,photo char(255),document char(255), primary key(empid));";
                sqlExecute(CRUD.sql);              
            }
            

        }

        //Grid cell click handler for update function
        private void gridViewTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                
                empPhoto.Image = null;
                clearTextbox("clean");
                //topPanel.Visible = true;
                formPanel.Visible = true;
                viewPanel.Visible = false;
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                
                txbID.ReadOnly = true;
                txbID.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[0].Value);
                txbFname.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[1].Value);
                txbLname.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[2].Value);
                txbAddress.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[3].Value);
                txbPcode.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[4].Value);
                dobPicker.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[5].Value);
                txbGender.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[6].Value);
                txbPhoto.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[7].Value);
                txbDoc.Text = Convert.ToString(gridViewTable.CurrentRow.Cells[8].Value);
                this.id = txbID.Text;
                //if (txbDoc.Text == "")
                //{
                //    txbDoc.Text = "0 files";
                //    this.docCount = Convert.ToInt32(new String(txbDoc.Text[0], 1));
                //}
                //else if (txbDoc.Text != "" && txbDoc.Text != "0 files"){
                //    try
                //    {
                //        this.docCount = Directory.GetFiles(docDir+"\\"+id+" Docs", "*", SearchOption.TopDirectoryOnly).Length;
                //    }
                //    catch (Exception ex)
                //    {
                //       MessageBox.Show("The employee document directory not found", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        this.docCount = 0;
                //    }
                //}
                //txbDoc.Text = docCount.ToString() + " files";
                if (txbPhoto.Text != "")
                    try
                    {
                        //Config to your photos directory
                        FileHandler photoHandler = new FileHandler();
                        System.Drawing.Image photo;
                        byte[] photoBytes;
                        photoBytes = File.ReadAllBytes(txbPhoto.Text);
                        photo = photoHandler.ConvertByteArrayToImage(photoBytes);            
                        empPhoto.Image = photo;
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Photo not found in directory, Please add a photo or delete the Photo field", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbPhoto.Text = "";
                        empPhoto.Image = null;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        MessageBox.Show("Directory not found, Please add the directory or delete the Photo field", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txbPhoto.Text = "";
                        empPhoto.Image = null;
                    }
                else
                    empPhoto.Image = null;
            }
        }

        //Execute SQL add Command
        private void sqlExecute (String sqlCommand)
        {
            CRUD.cmd = new MySqlCommand(sqlCommand, CRUD.con);
            AddParameters();
            CRUD.PerformCRUD(CRUD.cmd);
        }

        //save employee table to pdf 
        public void saveToPDF()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = "";

            try
            {
                if (saveFileDialog.ShowDialog()==DialogResult.OK)
                {
                    PdfPTable PdfTable = new PdfPTable(gridViewTable.Columns.Count);
                    PdfTable.DefaultCell.Padding = 2;
                    PdfTable.WidthPercentage = 100;

                    foreach (DataGridViewColumn col in gridViewTable.Columns)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(col.HeaderText));
                        PdfTable.AddCell(pdfCell);
                    }
                    foreach (DataGridViewRow row in gridViewTable.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfTable.AddCell(cell.Value.ToString());
                        }
                    }

                    using (FileStream fileStream=new FileStream(saveFileDialog.FileName,FileMode.Create))
                    {
                        Document document = new Document();
                        document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                        PdfWriter.GetInstance(document, fileStream);
                        document.Open();
                        document.Add(PdfTable);
                        document.Close();
                        fileStream.Close();
                    }  
                    MessageBox.Show("Print to PDF Successfully");
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to PDF " + ex.Message);
            }

        }
        
        //print to pdf event handler
        private void btnprintToPdfClick(object sender, EventArgs e)
        {
           saveToPDF();

        }

        

        //Add Parameters
        private void AddParameters()
        {
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("@empID", txbID.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@firstName", txbFname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@lastName", txbLname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@address", txbAddress.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@postcode", txbPcode.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@DOB", dobPicker.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@gender", txbGender.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@photo", txbPhoto.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@document", txbDoc.Text.Trim().ToString());
        }     
    }
        
}
