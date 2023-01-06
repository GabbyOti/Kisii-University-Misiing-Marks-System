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
using WindowsFormsApplication1;

namespace KMMMS
{
    public partial class frmlecture : Form
    {
        public frmlecture()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmlecture_Load(object sender, EventArgs e)
        {
            conn cn = new conn();
            string query = "";
            query = "SELECT * FROM department ORDER BY department_ID ASC";
            if (cn.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cbodptid.Items.Clear();
                while (dataReader.Read())
                {
                    this.cbodptid.Items.Add(dataReader["department_ID"].ToString());
                }


            }
            cn.CloseConnection();
        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "KUMMMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        public void Clean()
        {
            txTPF.Text = "";
            txtname.Text = "";
            txtphone.Text = "";
            cbodptid.Text = "--select department--";
            txtemail.Text = "";
            cboemp.Text = "Select employment year";

        }
        private void btnReset_Click(object sender, System.EventArgs e)
        {
            Clean();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            string gender = "";
            if (rbtnmale.Checked == true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            if (txTPF.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txTPF.Focus();
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtname.Focus();
            }
            else if (txtphone.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtphone.Focus();

            }
            else if (cbodptid.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbodptid.Focus();

            }
            else if (txtemail.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtemail.Focus();

            }
            else if (cboemp.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cboemp.Focus();

            }

            else
            {
                conn cn = new conn();

                string query3 = "";
                query3 = "INSERT INTO lecturer VALUES('" + txTPF.Text + "','" + txtname.Text + "','" + txtphone.Text + "','" + cbodptid.Text + "','" + txtemail.Text + "','" + cboemp.Text + "','" + gender + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
                    cmd.ExecuteNonQuery();

                    txTPF.Text = "";
                    txtname.Text = "";
                    txtphone.Text = "";
                    cbodptid.Text = "";
                    txtemail.Text = "";
                    cboemp.Text = "";
                    txTPF.Focus();
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }
    }
}

