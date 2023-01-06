using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMMMS
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void facultyschoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfaculty fsf = new frmfaculty();
            fsf.MdiParent = this;
            fsf.Visible = true;
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdepartment fd = new frmdepartment();
            fd.MdiParent = this;
            fd.Visible = true;
        }

        private void programmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmprogramme fp = new frmprogramme();
            fp.MdiParent = this;
            fp.Visible = true;
        }

        private void lecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlecture fl = new frmlecture();
            fl.MdiParent = this;
            fl.Visible = true;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmstudent ft = new frmstudent();
            ft.MdiParent = this;
            ft.Visible = true;
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcourse fc = new frmcourse();
            fc.MdiParent = this;
            fc.Visible = true;
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmapplication fa = new frmapplication();
            fa.MdiParent = this;
            fa.Visible = true;

        }
    }
}
