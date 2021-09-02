
using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace EDApp{
    
    
    public class mainProgram: Form {

        //Generating form text box for input
        private TextBox txbID = new TextBox();
        private TextBox txbFname = new TextBox();
        private TextBox txbLname = new TextBox();  
        private TextBox txbAddress = new TextBox();                 
        private TextBox txbPcode = new TextBox();
        private TextBox txbDOB = new TextBox();
        private TextBox txbGender = new TextBox();
        private TextBox txbPhoto = new TextBox();
        private TextBox txbDoc = new TextBox();
        public Panel mainPanel,topPanel;
        
        public mainProgram(){
            menuFrame();
            CRUD.createConnection(CRUD.con);
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
            
            //Generating Menu buttons
            Button btnEdit = new Button();
            Button btnView = new Button();

            //Generating Function buttons 
            Button btnAdd = new Button();
            Button btnDelete = new Button();
            Button btnExit = new Button();
            
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
            //btnDelete.Click += new System.EventHandler(btnDeleteClick);

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

            
            //Adding elements to win form
            this.Controls.Add(topPanel);
            this.Controls.Add(mainPanel);

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

        }
        
        //Edit button event handler   
        public void btnEditClick(object sender, EventArgs e) 
        {
            mainPanel.Visible = true;
            topPanel.Visible = true;
        } 

        //View button event handler
        public void btnViewClick(object sender, EventArgs e) 
        {
            mainPanel.Visible = false;
            topPanel.Visible = true;
        } 

        //Add button event handler
        private void btnAddClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFname.Text.Trim()) || string.IsNullOrEmpty(txbLname.Text.Trim()))
            {
                MessageBox.Show("Please enter information", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO employee(empid, FirstName, LastName) VALUES(@empID, @firstName, @lastName)";

            sqlExecute(CRUD.sql, "Insert");
            MessageBox.Show("Record saved", "Adding Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mainPanel.Visible = true;
            topPanel.Visible = true;
            clearTextbox();
        }

        //Exit button event handler
        private void btnExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Execute SQL Command
        private void sqlExecute (String sqlCommand, string parameter)
        {
            CRUD.cmd = new MySqlCommand(sqlCommand, CRUD.con);
            AddParameters(parameter);
            CRUD.PerformCRUD(CRUD.cmd);
        }

        //Add Parameters
        private void AddParameters(String str)
        {
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("@empID", txbID.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@firstName", txbFname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@lastName", txbLname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@address", txbID.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@postcode", txbFname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@DOB", txbLname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@gender", txbFname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@photo", txbLname.Text.Trim().ToString());
            CRUD.cmd.Parameters.AddWithValue("@document", txbLname.Text.Trim().ToString());
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
        }
    }
        
}
