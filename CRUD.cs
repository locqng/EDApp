using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



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

            string connectString = ("Server=localhost,3306;Database=employee_database;user=root;password=1234;TrustServerCertificate=true;");
            //string connectString = string.Format("{0}{1}{2}{3}{4}", host, db, user, password, trust);
            return connectString;
        }

        public static SqlConnection con = new SqlConnection(getConnectionString());
        public static SqlCommand cmd = default(SqlCommand);
        public static string sql = string.Empty;
        public static DataTable PerformCRUD(SqlCommand command)
        {
            
            SqlDataAdapter adptr = default (SqlDataAdapter);
            DataTable table = new DataTable();
            try
            {
                adptr = new SqlDataAdapter();
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