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
    public partial class frmapplication : Form
    {
        public frmapplication()
        {
            InitializeComponent();
        }

        private void frmapplication_Load(object sender, EventArgs e)
        {

        }
        public void Clean()
        {
            txtsno.Text = "";
            txtreg.Text = "";
            txtcos.Text = "";
            cbosem.Text = "";
            cboyear.Text = "";

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtsno.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsno.Focus();
            }
            else if (txtreg.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtreg.Focus();
            }
            else if (txtcos.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtcos.Focus();

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

            else
            {
                conn cn = new conn();

                string query3 = "";
                query3 = "INSERT INTO application VALUES('" + txtsno.Text + "','" + txtreg.Text + "','" + txtcos.Text + "','" + cbosem.Text + "','" + cboyear.Text + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtsno.Text = "";
                    txtreg.Text = "";
                    txtcos.Text = "";
                    cbosem.Text = "";
                    cboyear.Text = "";
                    txtsno.Focus();
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}

