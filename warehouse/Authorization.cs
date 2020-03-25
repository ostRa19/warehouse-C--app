using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
namespace warehouse
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private Authorization _f1;
        private Storekeeper _f2;
        private Manager _f3;
        private Accountant _f4;
        private NewSupply _f5;
        
        private void Form1_Load(object sender, EventArgs e)
        {
           FbConnection conn = DBConnect.GetConnection();
            LoginField.ForeColor = Color.FromArgb(35, 58, 128);
            passField.ForeColor = Color.FromArgb(35, 58, 128);
            buttonLogin.ForeColor = Color.WhiteSmoke;
            passField.PasswordChar = '*';
             pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FbConnection conn = DBConnect.GetConnection();
            String LoginUser = LoginField.Text;
            String passUser = passField.Text;
             
            DataTable table = new DataTable();
            string myQuery = "Select * from USERS WHERE LOGIN = @ul AND PASSWORD = @up";            
            FbCommand command = new FbCommand(myQuery, conn); 
            command.Parameters.Add("@ul", FbDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@up", FbDbType.VarChar).Value = passUser;
            FbDataAdapter adapter = new FbDataAdapter(command); 
            adapter.SelectCommand = command;
            adapter.Fill(table); 
            dataGridView1.DataSource = table;
            if (table.Rows.Count > 0)
            {
                switch (dataGridView1[1, 0].Value.ToString())
                {
                    case "1":
                        _f2 = new Storekeeper();
                        _f2.Show(this);
                        this.Hide();
                        break;
                    case "2":
                        _f3 = new Manager();
                        _f3.Show(this);
                        this.Hide();
                        break;
                    case "3":
                        _f3 = new Manager();
                        _f3.Show(this);
                        this.Hide();
                        break;
                    case "4":
                        _f4 = new Accountant();
                        _f4.Show(this);
                        this.Hide();
                        break;
                }
            }
            else
                MessageBox.Show("Такий користувач не зараєстрований в базі даних"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
        }
    }
}
 
