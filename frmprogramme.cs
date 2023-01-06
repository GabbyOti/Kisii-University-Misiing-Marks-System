using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using MySql.Data;
using WindowsFormsApplication1;

namespace KMMMS
{
    public partial class frmprogramme : Form
    {
        public frmprogramme()
        {
            InitializeComponent();
        }


        private void frmprogramme_Load(object sender, System.EventArgs e)
        {
            conn cn = new conn();
            string query = "";
            query = "SELECT * FROM department ORDER BY department_ID ASC";
            if (cn.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cbodpt.Items.Clear();
                while (dataReader.Read())
                {
                    this.cbodpt.Items.Add(dataReader["department_ID"].ToString());
                }


            }
            cn.CloseConnection();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (txtproid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtproid.Focus();
            }
            else if (txtprona.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtprona.Focus();
            }
            else if (cbodptid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbodptid.Focus();

            }


            else
            {
                conn cn = new conn();
                string query1 = "";

                query1 = "UPDATE programme SET programme_ID='" + txtproid.Text + "',programme_Name='" + txtprona.Text + "',department_ID='" + cbodpt.Text + "' WHERE programme_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtproid.Text = "";
                    txtprona.Text = "";
                    cbodpt.Text = "";
                    MessageBox.Show("Record updated!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (txtproid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtproid.Focus();
            }
            else if (txtprona.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtprona.Focus();
            }
            else if (cbodptid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbodptid.Focus();

            }
            else
            {
                conn cn = new conn();
                string query1 = "";

                query1 = "DELETE FROM department WHERE department_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();


                    txtproid.Text = "";
                    txtprona.Text = "";
                    cbodpt.Text = "";
                    txtproid.Focus();
                    MessageBox.Show("Record deleted!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        }
        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "KUMMMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Focus();
            }
            else
            {
                conn cn = new conn();
                string query5 = "";
                query5 = "SELECT *FROM programme WHERE programme_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query5, cn.connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtproid.Text = dataReader["programme_ID"].ToString();
                        txtprona.Text = dataReader["programme_Name"].ToString();
                        cbodpt.Text = dataReader["department_ID"].ToString();

                    }
                    else
                    {

                        txtproid.Text = "";
                        txtprona.Text = "";
                        cbodpt.Text = "";


                    }


                }

            }


        }
        public void Clean()
        {
            txtproid.Text = "";
            txtprona.Text = "";
            cbodpt.Text = "--select department--";
            txtSearch.Text = "";
        }
        private void btnReset_Click_1(object sender, System.EventArgs e)
        {
            Clean();
        }

        private void btnSave_Click_1(object sender, System.EventArgs e)
        {
            if (txtproid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtproid.Focus();
            }
            else if (txtprona.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtprona.Focus();
            }
            else if (cbodpt.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbodptid.Focus();

            }
            else
            {
                conn cn = new conn();
                string query3 = "";
                query3 = "INSERT INTO programme VALUES('" + txtproid.Text + "','" + txtprona.Text + "','" + cbodpt.Text + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
                    cmd.ExecuteNonQuery();


                    txtproid.Text = "";
                    txtprona.Text = "";
                    cbodpt.Text = "";
                    txtproid.Focus();
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }
    }
}

