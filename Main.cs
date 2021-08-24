
using System;
using System.Windows.Forms;
using System.Drawing;

namespace EDAP{
    
    public class mainProgram: Form {
        public Panel mainPanel,topPanel;
        
        public mainProgram(){
            menuFrame();
        }

        public void menuFrame()
        {
            //Set the form width & height 
            this.Width = 500;
            this.Height = 500;

             //Creating the top panel
            topPanel = new Panel();
            topPanel.Width = 500;
            topPanel.Height = 20;
            
            //Creating the main panel
            mainPanel = new Panel();
            mainPanel.Width = 500;
            mainPanel.Height = 480;
            
            //Generating Menu buttons
            Button btnEdit = new Button();
            Button btnView = new Button();
            
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

            //Generating form text box for input
            TextBox txbID = new TextBox();
            TextBox txbFname = new TextBox();
            TextBox txbLname = new TextBox();  
            TextBox txbAddress = new TextBox();                 
            TextBox txbPcode = new TextBox();
            TextBox txbDOB = new TextBox();
            TextBox txbGender = new TextBox();
            TextBox txbPhoto = new TextBox();
            TextBox txbDoc = new TextBox();

            //Setting menu buttons size and locations

            //Edit button
            btnEdit.Location = new Point(0,0);
            btnEdit.Text = "Edit";
            btnEdit.Size = new Size(250,20);
            btnEdit.Click += new System.EventHandler(btnEditClick);

            //View button          
            btnView.Location = new Point(250,0);
            btnView.Text = "View";
            btnView.Size = new Size(250,20);
            btnView.Click += new System.EventHandler(btnViewClick);

            //Setting labels and text boxes size and location

            //Employee ID
            lblID.Text = "Employee ID";
            lblID.Location = new Point(10,42);
            lblID.Size = new Size(100,20);
    
            txbID.Location = new Point(120,40);
            txbID.Size = new Size(120,20);
            
            //First name 
            lblFname.Text = "First Name";
            lblFname.Location = new Point(10,82);
            lblFname.Size = new Size(100,20);
            
            txbFname.Location = new Point(120,80);
            txbFname.Size = new Size(120,20);

            //Last name
            lblLname.Text = "Last Name";
            lblLname.Location = new Point(10,122);
            lblLname.Size = new Size(100,20);
            
            txbLname.Location = new Point(120,120);
            txbLname.Size = new Size(120,20);

            //Address 
            lblAddress.Text = "Address";
            lblAddress.Location = new Point(10,162);
            lblAddress.Size = new Size(100,20);
            
            txbAddress.Location = new Point(120,160);
            txbAddress.Size = new Size(250,20);

            //Postcode
            lblPcode.Text = "Postcode";
            lblPcode.Location = new Point(10,202);
            lblPcode.Size = new Size(100,20);
            
            txbPcode.Location = new Point(120,200);
            txbPcode.Size = new Size(120,20);
            
            //DoB
            lblDOB.Text = "DOB";
            lblDOB.Location = new Point(10,242);
            lblDOB.Size = new Size(100,20);
            
            txbDOB.Location = new Point(120,240);
            txbDOB.Size = new Size(120,20);

            //Gender
            lblGender.Text = "Gender";
            lblGender.Location = new Point(10,282);
            lblGender.Size = new Size(100,20);
            
            txbGender.Location = new Point(120,280);
            txbGender.Size = new Size(120,20);

            //Photo
            lblPhoto.Text = "Photo";
            lblPhoto.Location = new Point(10,322);
            lblPhoto.Size = new Size(100,20);
            
            txbPhoto.Location = new Point(120,320);
            txbPhoto.Size = new Size(250,20);

            //Document
            lblDoc.Text = "Document";
            lblDoc.Location = new Point(10,362);
            lblDoc.Size = new Size(100,20);
            
            txbDoc.Location = new Point(120,360);
            txbDoc.Size = new Size(250,20);
            
            //Adding elements to win form

            this.Controls.Add(topPanel);

            this.Controls.Add(mainPanel);

            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnView);

            mainPanel.Controls.Add(lblID);
            mainPanel.Controls.Add(lblFname);
            mainPanel.Controls.Add(lblLname);
            mainPanel.Controls.Add(lblPcode);
            mainPanel.Controls.Add(lblAddress);
            mainPanel.Controls.Add(lblDOB);
            mainPanel.Controls.Add(lblGender);
            mainPanel.Controls.Add(lblPhoto);
            mainPanel.Controls.Add(lblDoc);  

            mainPanel.Controls.Add(txbID);
            mainPanel.Controls.Add(txbFname);
            mainPanel.Controls.Add(txbLname);
            mainPanel.Controls.Add(txbPcode);
            mainPanel.Controls.Add(txbAddress);
            mainPanel.Controls.Add(txbDOB);
            mainPanel.Controls.Add(txbGender);
            mainPanel.Controls.Add(txbPhoto);
            mainPanel.Controls.Add(txbDoc);
        }
        
        //Edit button event handler   
        public void btnEditClick(object sender, EventArgs e) 
        {
            menuFrame();
        } 


        //View button event handler
        public void btnViewClick(object sender, EventArgs e) 
        {
            mainPanel.Visible = false;
            topPanel.Visible = true;

        }  
           
    }
}
