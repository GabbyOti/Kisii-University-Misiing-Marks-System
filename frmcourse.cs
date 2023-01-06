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
    public partial class frmcourse : Form
    {
        public frmcourse()
        {
            InitializeComponent();
        }

        private void cbodptid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            conn cn = new conn();
            string query6 = "";
            query6 = "SELECT * FROM programme ORDER BY programme_ID ASC";
            if (cn.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query6, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cbopid.Items.Clear();
                while (dataReader.Read())
                {
                    this.cbopid.Items.Add(dataReader["programme_ID"].ToString());
                }


            }
            cn.CloseConnection();
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmcourse_Load(object sender, EventArgs e)
        {
            conn cn = new conn();
            string query = "";
            query = "SELECT * FROM lecturer ORDER BY lecturer_Name ASC";
            if (cn.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cbolname.Items.Clear();
                while (dataReader.Read())
                {
                    this.cbolname.Items.Add(dataReader["lecturer_Name"].ToString());
                }


            }
            cn.CloseConnection();

        }
        public void Clean()
        {
            txtcid.Text = "";
            txtname.Text = "";
            cbolname.Text = "";
            cboyear.Text = "";
            cbosem.Text = "";

        }
        private void btnReset_Click(object sender, System.EventArgs e)
        {
            Clean();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (txtcid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcid.Focus();
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtname.Focus();
            }
            else if (cbolname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbolname.Focus();

            }
            else if (cboyear.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cboyear.Focus();

            }
            else if (cbosem.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbosem.Focus();

            }

            else if (cbopid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbosem.Focus();

            }

            else
            {
                conn cn = new conn();

                string query3 = "";
                query3 = "INSERT INTO course VALUES('" + txtcid.Text + "','" + txtname.Text + "','" + cbolname.Text + "','" + cboyear.Text + "','" + cbosem.Text + "','" + cbopid.Text + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtcid.Text = "";
                    txtname.Text = "";
                    cbolname.Text = "";
                    cboyear.Text = "";
                    cbosem.Text = "";
                    cbopid.Text = "";
                    txtSearch.Text = "";
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (txtcid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcid.Focus();
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtname.Focus();
            }
            else if (cbolname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbolname.Focus();

            }
            else if (cboyear.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cboyear.Focus();

            }
            else if (cbosem.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbosem.Focus();

            }
            else if (cbopid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbosem.Focus();
            }
            else
            {
                conn cn = new conn();

                string query1 = "";
                query1 = "UPDATE course SET course_ID='" + txtcid.Text + "',course_Name='" + txtname.Text + "',lecturer_name='" + cbolname.Text + "',year='" + cboyear.Text + "',sem='" + cbosem.Text + "',programme_ID='" + cbopid.Text + "' WHERE course_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtcid.Text = "";
                    txtname.Text = "";
                    cbolname.Text = "";
                    cboyear.Text = "";
                    cbosem.Text = "";
                    cbopid.Text = "";
                    txtSearch.Text = "";
                    MessageBox.Show("Record updated!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (txtcid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcid.Focus();
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtname.Focus();
            }
            else if (cbolname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbolname.Focus();

            }
            else if (cboyear.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cboyear.Focus();

            }
            else if (cbosem.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbosem.Focus();

            }
            else if (cbopid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbosem.Focus();
            }
            else
            {
                conn cn = new conn();
                string query1 = "";
                query1 = "DELETE FROM course WHERE course_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtcid.Text = "";
                    txtname.Text = "";
                    cbolname.Text = "";
                    cboyear.Text = "";
                    cbosem.Text = "";
                    cbopid.Text = "";
                    txtSearch.Focus();
                    MessageBox.Show("Record deleted!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
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
                query5 = "SELECT *FROM course WHERE course_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query5, cn.connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtcid.Text = dataReader["course_ID"].ToString();
                        txtname.Text = dataReader["course_Name"].ToString();
                        cbolname.Text = dataReader["lecturer_name"].ToString();
                        cboyear.Text = dataReader["year"].ToString();
                        cbosem.Text = dataReader["sem"].ToString();
                        cbopid.Text = dataReader["programme_ID"].ToString();
                    }
                    else
                    {

                        txtcid.Text = "";
                        txtname.Text = "";
                        cbolname.Text = "";
                        cboyear.Text = "";
                        cbosem.Text = "";
                        txtSearch.Focus();

                    }


                }

            }
        }

        private void cboyear_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void label5_Click(object sender, System.EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to quit?", "KUMMMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

    }
}

