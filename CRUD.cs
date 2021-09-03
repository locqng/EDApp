using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace EDApp
{
    class CRUD
    {

        //Config Connection String
        private static string connectionStringBuilder()
        {

            string host = "server=localhost;";
            string port = "port=3306;";
            string db = "database=employee_database;";
            string user = "user=root;";
            string password = "password=1234";

            //string connectString = ("server=localhost;port=3306;database=employee_database;user=root;password=1234");
            string connectString = string.Format("{0}{1}{2}{3}{4}", host, port, db, user, password);
            return connectString;
        }

        public static MySqlConnection con = new MySqlConnection(connectionStringBuilder());
        
        //create connection & employee table
        public static void createConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionStringBuilder());
            try
            {
                conn.Open();
                string createTableCmd = @"CREATE TABLE IF NOT EXISTS `employee`(empid varchar(20) not null, FirstName varchar(255), LastName varchar(255),address varchar(255),postcode varchar(255), DOB varchar(255), gender varchar(255) ,photo varchar(255),document varchar(255), primary key(empid));";
                MySqlCommand createCmd = new MySqlCommand(createTableCmd,conn);
                createCmd.ExecuteNonQuery();
                MessageBox.Show("created");

            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        public static MySqlCommand cmd = default(MySqlCommand);
        public static string sql = string.Empty;
        
        public static DataTable PerformCRUD(MySqlCommand command)
        {
            
            MySqlDataAdapter adptr = default (MySqlDataAdapter);
            DataTable table = new DataTable();
            try
            {
                adptr = new MySqlDataAdapter();
                adptr.SelectCommand = command;
                adptr.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                table = null;
            }
            return table;
        }
        
        public static MySqlCommand deleteCmd = default(MySqlCommand);
        public static string deleteQuery = string.Empty;
        public static DataTable deleteEmployee(MySqlCommand command)
        {
            MySqlDataAdapter adptr = default (MySqlDataAdapter);
            DataTable table = new DataTable();
            try
            {
                adptr = new MySqlDataAdapter();
                adptr.SelectCommand = command;
                adptr.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                table = null;
            }
            return table;
        }
    }
}