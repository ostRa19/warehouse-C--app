using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouse
{
    public partial class Accountant : Form
    {
        public Accountant()
        {
            InitializeComponent();
        }
        private Acts_Accountant _f_A_M;
        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ActsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _f_A_M = new Acts_Accountant(); _f_A_M.Show(this);
        }

        private void certificate_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void about_app_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
