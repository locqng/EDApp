using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace EDApp{
    
    
    public class mainProgram: Form {

        int row = 0;
        //Generating form text box for input
        private static TextBox txbID = new TextBox();
        private TextBox txbFname = new TextBox();
        private TextBox txbLname = new TextBox();  
        private TextBox txbAddress = new TextBox();                 
        private TextBox txbPcode = new TextBox();
        private TextBox txbDOB = new TextBox();
        private TextBox txbGender = new TextBox();
        private TextBox txbPhoto = new TextBox();
        private TextBox txbDoc = new TextBox();
        private TextBox txbSearch = new TextBox();
        public Panel mainPanel, topPanel, subPanel;
        private DataGridView gridViewTable = new DataGridView();
        
        public mainProgram(){
            menuFrame();
            createTable();
        }

        public void menuFrame()
        {
            //Set the form width & height 
            this.Width = 800;
            this.Height = 600;

            //Set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            //Creating the top panel
            topPanel = new Panel();
            topPanel.Width = 800;
            topPanel.Height = 30;
            
            //Creating the main panel
            mainPanel = new Panel();
            mainPanel.Width = 800;
            mainPanel.Height = 580;

            //Creating the sub panel
            subPanel = new Panel();
            subPanel.Width = 800;
            subPanel.Height = 580;
            
            //Generating Menu buttons
            Button btnEdit = new Button();
            Button btnView = new Button();

            //Generating Function buttons 
            Button btnAdd = new Button();
            Button btnDelete = new Button();
            Button btnExit = new Button();
            Button btnSearch = new Button();
            
            //Generating form labels
            Label lblID = new Label();
            Label lblFname = new Label();
            Label lblLname = new Label();
            Label lblAddress = new Label();
            Label lblPcode = new Label();
            Label lblDOB = new Label(); 
            Label lblGender = new Label();
            Label lblPhoto = new Label();
            Label lblDoc = new Label();

            //Setting menu buttons size and locations
            //Edit button
            btnEdit.Location = new Point(0,0);
            btnEdit.Text = "Edit";
            btnEdit.Size = new Size(400,30);
            btnEdit.Click += new System.EventHandler(btnEditClick);

            //View button          
            btnView.Location = new Point(400,0);
            btnView.Text = "View";
            btnView.Size = new Size(400,30);
            btnView.Click += new System.EventHandler(btnViewClick);

            //Add button 
            btnAdd.Location = new Point(20,500);
            btnAdd.Text = "Add";
            btnAdd.Size = new Size(80,20);
            btnAdd.Click += new System.EventHandler(btnAddClick);
            
            //Delete button 
            btnDelete.Location = new Point(130,500);
            btnDelete.Text = "Delete";
            btnDelete.Size = new Size(80,20);
            btnDelete.Click += new System.EventHandler(btnDeleteClick);

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
            
            txbDOB.Location = new Point(120,250);
            txbDOB.Size = new Size(120,20);

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

            //Document
            lblDoc.Text = "Document";
            lblDoc.Location = new Point(20,372);
            lblDoc.Size = new Size(100,20);
            
            txbDoc.Location = new Point(120,370);
            txbDoc.Size = new Size(250,20);
            
            //Search box for view sub panel
            txbSearch.Location = new Point(20,50);
            txbSearch.Size = new Size(100,20);

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
            

            //Adding elements to win form
            this.Controls.Add(topPanel);
            this.Controls.Add(mainPanel);
            this.Controls.Add(subPanel);

            // adding buttons in top panel
            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnView);

            // adding labels in main panel
            mainPanel.Controls.Add(lblID);
            mainPanel.Controls.Add(lblFname);
            mainPanel.Controls.Add(lblLname);
            mainPanel.Controls.Add(lblPcode);
            mainPanel.Controls.Add(lblAddress);
            mainPanel.Controls.Add(lblDOB);
            mainPanel.Controls.Add(lblGender);
            mainPanel.Controls.Add(lblPhoto);
            mainPanel.Controls.Add(lblDoc);  

            // adding text field in main panel 
            mainPanel.Controls.Add(txbID);
            mainPanel.Controls.Add(txbFname);
            mainPanel.Controls.Add(txbLname);
            mainPanel.Controls.Add(txbPcode);
            mainPanel.Controls.Add(txbAddress);
            mainPanel.Controls.Add(txbDOB);
            mainPanel.Controls.Add(txbGender);
            mainPanel.Controls.Add(txbPhoto);
            mainPanel.Controls.Add(txbDoc);

            // adding function buttons in main panel
            mainPanel.Controls.Add(btnAdd);
            mainPanel.Controls.Add(btnDelete);
            mainPanel.Controls.Add(btnExit);

            //Add grid table to the sub view panel
            subPanel.Controls.Add(gridViewTable);
            subPanel.Controls.Add(txbSearch);
            subPanel.Controls.Add(btnSearch);
            

        }
        
        //Edit button event handler   
        public void btnEditClick(object sender, EventArgs e) 
        {
            
            mainPanel.Visible = true;
            topPanel.Visible = true;
            subPanel.Visible = false;
        } 

        //View button event handler
        public void btnViewClick(object sender, EventArgs e) 
        {
            
            mainPanel.Visible = false;
            topPanel.Visible = true;
            subPanel.Visible = true;
            viewRecords("");

        } 
        
        //Add button event handler
        private void btnAddClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbID.Text.Trim())||
            string.IsNullOrEmpty(txbFname.Text.Trim()) ||
             string.IsNullOrEmpty(txbLname.Text.Trim())|| 
             string.IsNullOrEmpty(txbPcode.Text.Trim())|| 
             string.IsNullOrEmpty(txbAddress.Text.Trim())|| 
             string.IsNullOrEmpty(txbDOB.Text.Trim())|| 
             string.IsNullOrEmpty(txbGender.Text.Trim())|| 
             string.IsNullOrEmpty(txbPhoto.Text.Trim())|| 
             string.IsNullOrEmpty(txbDoc.Text.Trim()))
            {
                MessageBox.Show("Please enter information", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                CRUD.sql = "INSERT INTO employee(empid, FirstName, LastName,address,postcode, DOB ,gender,photo,document) VALUES(@empID, @firstName, @lastName,@address,@postcode,@DOB,@gender,@photo,@document)";
                sqlExecute(CRUD.sql);
                MessageBox.Show("Record saved", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainPanel.Visible = true;
                topPanel.Visible = true;
                clearTextbox();
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
            clearTextbox();
            
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
            CRUD.cmd.Parameters.AddWithValue("@address", txbPcode.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@postcode", txbAddress.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@DOB", txbDOB.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@gender", txbGender.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@photo", txbPhoto.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@document", txbDoc.Text.Trim().ToString());
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
                CRUD.sql= "Delete from employee where empid = @empID;";
                sqlExecute(CRUD.sql);  
                MessageBox.Show("Record Deleted", "Deleting Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainPanel.Visible = true;
                topPanel.Visible = true;
                clearTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
        //Exit button event handler
        private void btnExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // clear textbox
        private void clearTextbox()
        {
            txbID.Text = "";
            txbFname.Text = "";
            txbLname.Text = "";
            txbPcode.Text = "";
            txbAddress.Text = "";
            txbDOB.Text = "";
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
            CRUD.sql = "SELECT empid, FirstName, LastName, address, postcode, DOB, gender, photo, document FROM Employee " +
                        "WHERE empid LIKE @kw1 OR CONCAT(FirstName, ' ', LastName) LIKE @kw2 ORDER BY empid ASC";

            string kw2 = String.Format("%{0}%", search);
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("kw1", search);
            CRUD.cmd.Parameters.AddWithValue("kw2", kw2);

            DataTable table = CRUD.PerformCRUD(CRUD.cmd);
            if (table.Rows.Count > 0)
            {
                row = Convert.ToInt32(table.Rows.Count.ToString());
            }
            else
            {
                row = 0;
            }
    
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
            gridViewTable.Columns[3].Width = 190;
            gridViewTable.Columns[4].Width = 60;
            gridViewTable.Columns[5].Width = 50;
            gridViewTable.Columns[6].Width = 50;
            gridViewTable.Columns[7].Width = 50;
            gridViewTable.Columns[8].Width = 95;

        }
            
    }
        
}
