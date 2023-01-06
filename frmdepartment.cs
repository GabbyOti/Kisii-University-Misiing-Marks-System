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
    public partial class frmdepartment : Form
    {
        public frmdepartment()
        {
            InitializeComponent();
        }

        private void frmdepartment_Load(object sender, EventArgs e)
        {
            //COMBOBOX POPULATING DATA FROM DATABASE
            conn cn = new conn();
            string query = "";
            query = "SELECT * FROM faculty ORDER BY faculty_ID ASC";
            if (cn.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                cmd.ExecuteNonQuery();
                this.cboSchoolID.Items.Clear();
               /* while (dataReader.Read())
                {
                    this.cboSchoolID.Items.Add(dataReader["faculty_ID"].ToString());
                }*/


            }
            cn.CloseConnection();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (txtDpartmentID.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDpartmentID.Focus();
            }
            else if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDepartmentName.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDescription.Focus();

            }
            else if (cboSchoolID.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cboSchoolID.Focus();
            }

            else
            {
                conn cn = new conn();
                string query3 = "";
                query3 = "INSERT INTO department VALUES('" + txtDpartmentID.Text + "','" + txtDepartmentName.Text + "','" + txtDescription.Text + "','" + cboSchoolID.Text + "')";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtDescription.Text = "";
                    txtDepartmentName.Text = "";
                    txtDescription.Text = "";
                    txtDpartmentID.Focus();
                    MessageBox.Show("Record Saved", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        private void Clean()
        {
            txtDpartmentID.Text = "";
            txtDepartmentName.Text = "";
            txtDescription.Text = "";
            cboSchoolID.Text = "....Select faculty....";
        }
        private void btnReset_Click(object sender, System.EventArgs e)
        {
            Clean();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {

            if (txtDpartmentID.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDpartmentID.Focus();
            }
            else if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDepartmentName.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDescription.Focus();

            }
            else if (txtDpartmentID.Text == "")
            {
                MessageBox.Show("Ensure all fieds are filled", "KUMMMS message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtDpartmentID.Focus();

            }


            else
            {
                conn cn = new conn();
                string query1 = "";
                query1 = "UPDATE department SET department_ID='" + txtDpartmentID.Text + "',department_Name='" + txtDepartmentName.Text + "',office='" + txtDescription.Text + "',faculty_ID='" + cboSchoolID.Text + "' WHERE department_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query1, cn.connect);
                    cmd.ExecuteNonQuery();

                    txtDpartmentID.Text = "";
                    txtDepartmentName.Text = "";
                    txtDescription.Text = "";
                    cboSchoolID.Text = "";
                    txtDpartmentID.Focus();
                    MessageBox.Show("Record updated!", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }





        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            if (txtDpartmentID.Text == "")
            {
                MessageBox.Show("Please Enter School ID", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDpartmentID.Focus();
            }
            else if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("Please Enter School Name", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentName.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Please Enter Description", "KUMMMS Dialog Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
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

                    txtDpartmentID.Text = "";
                    txtDepartmentName.Text = "";
                    txtDescription.Text = "";
                    txtDpartmentID.Focus();
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
                query5 = "SELECT *FROM department WHERE department_ID='" + txtSearch.Text + "'";
                if (cn.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query5, cn.connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        txtDpartmentID.Text = dataReader["department_ID"].ToString();
                        txtDepartmentName.Text = dataReader["department_Name"].ToString();
                        txtDescription.Text = dataReader["office"].ToString();
                        cboSchoolID.Text = dataReader["faculty_ID"].ToString();
                    }
                    else
                    {

                        txtDpartmentID.Text = "";
                        txtDepartmentName.Text = "";
                        txtDescription.Text = "";
                        cboSchoolID.Text = " Select Department";

                    }


                }

            }
        }

        private void cboSchoolID_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}

