using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace EDApp{
    
    //test for git
    public class mainProgram: Form {
        //ID variables to handle photo upload
        private String id = "";
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
        private Panel viewPanel, formPanel;
        //public Panel topPanel;
        private DataGridView gridViewTable = new DataGridView();

        //Date time picker
        private DateTimePicker dobPicker = new DateTimePicker();

        //Generating Menu buttons
        //private Button btnEdit = new Button();
        //private Button btnView = new Button();

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

        //Gerating Image box for photos
        private PictureBox empPhoto = new PictureBox();
        
        public mainProgram(){
            menuFrame();
            createTable();
            viewRecords("");
        }

        public void menuFrame()
        {
            //Set the form width & height 
            this.Width = 800;
            this.Height = 600;

            //Set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //Creating the top panel
            //topPanel = new Panel();
            //topPanel.Width = 800;
            //topPanel.Height = 30;
            
            //Creating the main panel
            viewPanel = new Panel();
            viewPanel.Width = 800;
            viewPanel.Height = 580;
            viewPanel.Visible = true;

            //Creating the sub panel
            formPanel = new Panel();
            formPanel.Width = 800;
            formPanel.Height = 580;
            formPanel.Visible = false;
            


            //Setting menu buttons size and locations
            //Edit button
            //btnEdit.Location = new Point(0,0);
            //btnEdit.Text = "Edit";
            //btnEdit.Size = new Size(400,30);
            //btnEdit.Click += new System.EventHandler(btnEditClick);

            //View button          
            //btnView.Location = new Point(400,0);
            //btnView.Text = "View";
            //btnView.Size = new Size(400,30);
            //btnView.Click += new System.EventHandler(btnViewClick);

            //Add button 
            btnAdd.Location = new Point(20,500);
            btnAdd.Text = "Add";
            btnAdd.Size = new Size(80,20);
            btnAdd.Click += new System.EventHandler(btnAddClick);

            //Clear button
            btnClear.Location = new Point(120, 500);
            btnClear.Text = "Clear";
            btnClear.Size = new Size(80,20);
            btnClear.Visible = true;
            btnClear.Click += new System.EventHandler(btnClearClick);

            //Update Button
            btnUpdate.Location = new Point(20,500);
            btnUpdate.Text = "Update";
            btnUpdate.Size = new Size(80,20);
            btnUpdate.Visible = true;
            btnUpdate.Click += new System.EventHandler(btnUpdateClick);

            //Delete button 
            btnDelete.Location = new Point(210,500);
            btnDelete.Text = "Delete";
            btnDelete.Size = new Size(80,20);
            btnDelete.Click += new System.EventHandler(btnDeleteClick);

            //Add new Record button to change to form panel
            btnAddNew.Location = new Point(20, 370);
            btnAddNew.Text = "New Record";
            btnAddNew.Size = new Size(80,20);
            btnAddNew.Visible = true;
            btnAddNew.Click += new System.EventHandler(btnAddNewClick);

            //Go back button 
            btnBack.Location = new Point(20, 20);
            btnBack.Text = "Back";
            btnBack.Size = new Size(80,20);
            btnBack.Click += new System.EventHandler(btnBackClick);

            //Browse image button
            btnBrowse.Location = new Point(620, 180);
            btnBrowse.Text = "Browse";
            btnBrowse.Size = new Size(80, 20);
            btnBrowse.Click += new System.EventHandler(btnBrowseClick);

            //Upload document button
            btnUpload.Location = new Point(380, 370);
            btnUpload.Text = "Upload";
            btnUpload.Size = new Size(80, 20);
            //btnUpload.Click += new System.EventHandler(btnUploadClick);

            //Exit button 
            btnExit.Location = new Point(680,500);
            btnExit.Text = "Exit";
            btnExit.Size = new Size(80,20);
            btnExit.Click += new System.EventHandler(btnExitClick);

            //Setting labels and text boxes size and location
            //Employee ID
            lblID.Text = "Employee ID";
            lblID.Location = new Point(20,52);
            lblID.Size = new Size(100,20);
    
            txbID.Location = new Point(120,50);
            txbID.Size = new Size(120,20);
            
            //First name 
            lblFname.Text = "First Name";
            lblFname.Location = new Point(20,92);
            lblFname.Size = new Size(100,20);
            
            txbFname.Location = new Point(120,90);
            txbFname.Size = new Size(120,20);

            //Last name
            lblLname.Text = "Last Name";
            lblLname.Location = new Point(20,132);
            lblLname.Size = new Size(100,20);
            
            txbLname.Location = new Point(120,130);
            txbLname.Size = new Size(120,20);

            //Address 
            lblAddress.Text = "Address";
            lblAddress.Location = new Point(20,172);
            lblAddress.Size = new Size(100,20);
            
            txbAddress.Location = new Point(120,170);
            txbAddress.Size = new Size(250,20);

            //Postcode
            lblPcode.Text = "Postcode";
            lblPcode.Location = new Point(20,212);
            lblPcode.Size = new Size(100,20);
            
            txbPcode.Location = new Point(120,210);
            txbPcode.Size = new Size(120,20);
            
            //DoB
            lblDOB.Text = "DOB";
            lblDOB.Location = new Point(20,252);
            lblDOB.Size = new Size(100,20);
            
                     

            //Gender
            lblGender.Text = "Gender";
            lblGender.Location = new Point(20,292);
            lblGender.Size = new Size(100,20);
            
            txbGender.Location = new Point(120,290);
            txbGender.Size = new Size(120,20);

            //Photo
            lblPhoto.Text = "Photo";
            lblPhoto.Location = new Point(20,332);
            lblPhoto.Size = new Size(100,20);
            
            txbPhoto.Location = new Point(120,330);
            txbPhoto.Size = new Size(250,20);
            //txbPhoto.ReadOnly = fasle;

            //Document
            lblDoc.Text = "Document";
            lblDoc.Location = new Point(20,372);
            lblDoc.Size = new Size(100,20);
            
            txbDoc.Location = new Point(120,370);
            txbDoc.Size = new Size(250,20);
            txbDoc.ReadOnly = true;

            //Photo box
            empPhoto.Location = new Point(600,52);
            empPhoto.Size = new Size(120, 120);
            empPhoto.BorderStyle = BorderStyle.Fixed3D;
            empPhoto.SizeMode = PictureBoxSizeMode.StretchImage;


            
            //Search box for view sub panel
            txbSearch.Location = new Point(20,50);
            txbSearch.Size = new Size(100,20);
            txbSearch.KeyDown += App_KeyDown;

            btnSearch.Location = new Point(125,51);
            btnSearch.Text = "Search";
            btnSearch.Size = new Size(80,20);
            btnSearch.Click += new System.EventHandler(btnSearchClick);
            
            //Generate the grid view table for sub panel
            gridViewTable.Name = "dataTableGridView";
            gridViewTable.Location = new Point(20,100);
            gridViewTable.Size = new Size(750,250);
            gridViewTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            gridViewTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridViewTable.AllowUserToAddRows = false; 
            gridViewTable.CellClick += gridViewTable_CellClick;

            //Date Time Picker
            dobPicker.Location = new Point(120,250);
            dobPicker.Format = DateTimePickerFormat.Custom;
            dobPicker.CustomFormat = "dd/MMM/yyyy";
            dobPicker.MinDate = new DateTime(1930, 01, 01);
            dobPicker.MaxDate = DateTime.Now;
            
            

            //Adding elements to win form
            //this.Controls.Add(topPanel);
            this.Controls.Add(viewPanel);
            this.Controls.Add(formPanel);
        

            // adding buttons in top panel
            //topPanel.Controls.Add(btnEdit);
            //topPanel.Controls.Add(btnView);

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
            //formPanel.Controls.Add(btnExit);
            formPanel.Controls.Add(btnUpdate);
            formPanel.Controls.Add(btnBack);
            formPanel.Controls.Add(btnClear);
            formPanel.Controls.Add(btnBrowse);
            formPanel.Controls.Add(btnUpload);
            

            // adding photo box in form panel
            formPanel.Controls.Add(empPhoto);

            //Add grid table to the view panel
            viewPanel.Controls.Add(gridViewTable);
            viewPanel.Controls.Add(txbSearch);
            viewPanel.Controls.Add(btnSearch);
            viewPanel.Controls.Add(btnAddNew);
            //viewPanel.Controls.Add(btnExit);

            
            

        }
        
        //Edit button event handler   
        //public void btnEditClick(object sender, EventArgs e) 
        //{
            
        //    viewPanel.Visible = true;
        //    //topPanel.Visible = true;
        //    formPanel.Visible = false;
        //} 

        //View button event handler
        //public void btnViewClick(object sender, EventArgs e) 
        //{
        //    
        //    viewPanel.Visible = false;
           //topPanel.Visible = true;
        //    formPanel.Visible = true;
        //    viewRecords("");

        //} 
        
        //Add button event handler
        private void btnAddClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbID.Text.Trim())||
            string.IsNullOrEmpty(txbFname.Text.Trim()) ||
             string.IsNullOrEmpty(txbLname.Text.Trim())|| 
             string.IsNullOrEmpty(txbPcode.Text.Trim())|| 
             string.IsNullOrEmpty(txbAddress.Text.Trim())|| 
             string.IsNullOrEmpty(dobPicker.Text.Trim())|| 
             string.IsNullOrEmpty(txbGender.Text.Trim()))
             
            {
                MessageBox.Show("Please enter information", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                this.id = txbID.Text.Trim();
                CRUD.sql = "INSERT INTO employee(empid, FirstName, LastName,address,postcode, DOB ,gender,photo,document) VALUES(@empID, @firstName, @lastName,@address,@postcode,@DOB,@gender,@photo,@document)";
                sqlExecute(CRUD.sql);
                clearTextbox("clean");
                try{
                    File.Delete("D:/EmpPhotos/"+this.id+".png");
                    File.Move("D:/EmpPhotos/"+this.id+"_new.png", "D:/EmpPhotos/"+this.id+".png");
                }
                catch(FileNotFoundException)
                {
                    
                }
                clearTextbox("clean");
                viewRecords("");
                DialogResult dialogResult = MessageBox.Show("Record saved! Add another record?", "Adding Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);         
                //topPanel.Visible = true;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
                    File.Delete("D:/EmpPhotos/"+this.id+".png");
                    File.Move("D:/EmpPhotos/"+this.id+"_new.png", "D:/EmpPhotos/"+this.id+".png");
                }
                catch(FileNotFoundException)
                {
                    MessageBox.Show("Cannot update photos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //(need to search whether the id exists or not)
        private void btnDeleteClick(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(txbID.Text.Trim()))
            {
                MessageBox.Show("Please enter information", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                            File.Delete("D:/EmpPhotos/"+this.id+".png");
                        }
                            catch(FileNotFoundException)
                        {
                    MessageBox.Show("Cannot update photos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnBrowseClick (object sender, EventArgs e)
        {
            PhotoHandler upload = new PhotoHandler();
            if (txbID.Text != "")
            {
                Image newImage;
                newImage = upload.browseUpload(txbID.Text+"_new");
                if (newImage != null)
                {
                    txbPhoto.Text = "D:/EmpPhotos/"+txbID.Text+".png";
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            

                try{
                    File.Delete("D:/EmpPhotos/"+this.id+"_new.png");
                }catch (FileNotFoundException)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Generating table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txbPhoto.Text != "")
                    try{
                        //Config to your photos directory
                        PhotoHandler photoHandler = new PhotoHandler();
                        Image photo;
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
