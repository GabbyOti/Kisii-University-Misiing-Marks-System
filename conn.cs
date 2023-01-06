using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//class imported
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Data;


namespace WindowsFormsApplication1
{

    public class conn
    {
        public MySqlConnection connect;
        public string server;
        public string database;
        public string uid;
        public string password;
        public conn()
        {
            server = "localhost";
            database = "missingmark";
            uid = "root";
            password = "";
            string connectionstring = "";
            connectionstring = "SERVER=" + server + "; DATABASE=" + database + "; UID=" + uid + "; PASSWORD=" + password + ";";
            connect = new MySqlConnection(connectionstring);
        }
        //open database fn
        public bool openConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Connection not successful", "KIAS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        //close database fn
        public bool CloseConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Database not Closed", "KIAS Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}

