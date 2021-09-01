using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace EDApp
{
    class CRUD
    {
        private static string getConnectionString()
        {
           // string host = "server=localhost,3306;";
            
            //string db = "Database=employee_test;";
            //string user = "user=root;";
            //string password = "password='';";
            //string trust = "TrustServerCertificate=true;";

            string connectString = ("server=localhost;port=3306;database=employee_database;user=root;password=1234");
            //string connectString = string.Format("{0}{1}{2}{3}{4}", host, db, user, password, trust);
            return connectString;
        }

        public static MySqlConnection con = new MySqlConnection(getConnectionString());
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
    }
}