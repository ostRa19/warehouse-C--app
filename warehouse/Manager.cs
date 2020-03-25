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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }
        private Acts_MANAGER _f_A_M;
        private About_application _About_application;
        private void Warehouse_manager_Load(object sender, EventArgs e)
        {
 



        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();              
        }
//MessageBox.Show("dtujtgf");
        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _About_application = new About_application();
            _About_application.Show(this);
            this.Hide();
        }

        private void ActsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _f_A_M = new Acts_MANAGER(); _f_A_M.Show(this);
        }
    }
}
