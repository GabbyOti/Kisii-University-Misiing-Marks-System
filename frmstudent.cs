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
    public partial class frmstudent : Form
    {
        public frmstudent()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int sts;
            if (checkst.CheckState == CheckState.Checked)
            {
                sts = 1;
            }
            else
            {
                sts = 0;
            }

            string gender = "";
            if (rbtnmale.Checked == true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            if (txtreg.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtreg.Focus();
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

            else
            {
                conn cn = new conn();

                string query3 = "";
                query3 = "INSERT INTO student VALUES('" + txtreg.Text + "','" + txtname.Text + "','" + txtphone.Text + "','" + gender + "','" + sts + "','" + cbodptid.Text + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtreg.Text = "";
                    txtname.Text = "";
                    txtphone.Text = "";
                    checkst.Text = null;
                    cbodptid.Text = "";
                    txtreg.Focus();
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        public void Clean()
        {
            txtreg.Text = "";
            txtname.Text = "";
            txtphone.Text = "";
            checkst.Text = null;
            cbodptid.Text = "";


        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "KUMMMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void frmstudent_Load(object sender, System.EventArgs e)
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

        private void txtreg_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}

