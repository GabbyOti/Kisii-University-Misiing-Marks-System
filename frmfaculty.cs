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
    public partial class frmfaculty : Form
    {
        public frmfaculty()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSchoolID.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSchoolID.Focus();
            }
            else if (txtSchoolName.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtSchoolName.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDescription.Focus();

            }

            else
            {
                conn cn = new conn();
                string query1 = "";
                query1 = "INSERT INTO faculty VALUES('" + txtSchoolID.Text + "','" + txtSchoolName.Text + "','" + txtDescription.Text + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtSchoolID.Text = "";
                    txtSchoolName.Text = "";
                    txtDescription.Text = "";
                    txtSchoolID.Focus();
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }


        }
        private void Clean()
        {
            txtSchoolID.Text = "";
            txtSchoolName.Text = "";
            txtDescription.Text = "";
            txtSchoolID.Focus();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtSchoolID.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSchoolID.Focus();
            }
            else if (txtSchoolName.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtSchoolName.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDescription.Focus();

            }

            else
            {
                conn cn = new conn();
                string query1 = "";
                query1 = "UPDATE faculty SET faculty_ID='" + txtSchoolID.Text + "',faculty_Name='" + txtSchoolName.Text + "',office='" + txtDescription.Text + "' WHERE faculty_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtSchoolID.Text = "";
                    txtSchoolName.Text = "";
                    txtDescription.Text = "";
                    txtSchoolID.Focus();
                    MessageBox.Show("Record updated!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtSchoolID.Text == "")
            {
                MessageBox.Show("Please Enter faculty ID", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSchoolID.Focus();
            }
            else if (txtSchoolName.Text == "")
            {
                MessageBox.Show("Please Enter faculty Name", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSchoolName.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Please Enter office", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
            }
            else
            {
                conn cn = new conn();
                string query1 = "";
                query1 = "DELETE FROM faculty WHERE faculty_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MessageBox.Show("Are you sure you want to Delete Record?", "KUMMMS Message", MessageBoxButtons.YesNo);
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtSchoolID.Text = "";
                    txtSchoolName.Text = "";
                    txtDescription.Text = "";

                    txtSchoolID.Focus();
                    MessageBox.Show("Record deleted!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }



        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "KUMMMS Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Focus();
            }
            else
            {
                conn cn = new conn();
                string query2 = "";
                query2 = "SELECT *FROM faculty WHERE faculty_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query2, cn.connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtSchoolID.Text = dataReader["faculty_ID"].ToString();
                        txtSchoolName.Text = dataReader["faculty_Name"].ToString();
                        txtDescription.Text = dataReader["office"].ToString();
                    }
                    else
                    {

                        txtSchoolID.Text = "";
                        txtSchoolName.Text = "";
                        txtDescription.Text = "";

                    }


                }


            }
        }
    }
}


