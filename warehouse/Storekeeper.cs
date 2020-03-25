using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouse
{
    public partial class Storekeeper : Form
    {
        FbConnection conn = DBConnect.GetConnection();
        public Storekeeper()
        {
            InitializeComponent();
        }
        private NewSupply _f5;
        private Acts_STOREKEEPER _f_A_S;
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void buttonNewSupply_Click(object sender, EventArgs e)
        {
            _f5 = new NewSupply();
            _f5.Show(this);
            this.Hide();
        }
        private void buttonNewGoods_Click(object sender, EventArgs e)
        {
            // var DeleteRow1 = new DeleteRow();
            //    DeleteRow yh = DeleteRow.DeleteFromTable(textBox4.Text);

           // DeleteRow tom = new DeleteRow (tB =3);
        }
        private void buttonCreateReport_Click(object sender, EventArgs e)
        {

        }

        private void buttonViewGoods_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FbConnection conn = DBConnect.GetConnection();

            string myQuery = "SELECT * FROM TABLE_2";
            FbDataAdapter emp = new FbDataAdapter(myQuery, conn);
            FbCommandBuilder commandBuilder = new FbCommandBuilder(emp);
            emp.InsertCommand = new FbCommand("ADDRECORD2", conn);
            emp.InsertCommand.CommandType = CommandType.StoredProcedure;
            emp.InsertCommand.Parameters.Add(new FbParameter("@INPTEXT", FbDbType.VarChar, 50, "text"));
            emp.InsertCommand.Parameters.Add(new FbParameter("@INPVALUE", FbDbType.Integer, 50, "value"));
            DataSet ds = new DataSet();
            emp.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow newRow = dt.NewRow();
            newRow["text"] = textBox2.Text;
            newRow["value"] = textBox3.Text;
            dt.Rows.Add(newRow);
            emp.Update(ds);
            ds.AcceptChanges();
        }

        private void documentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("i am oki");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{ 
                FbConnection conn = DBConnect.GetConnection();
                string myQuery = "SELECT * FROM TRADEMARKS";
                FbDataAdapter emp = new FbDataAdapter(myQuery, conn);
                FbCommandBuilder commandBuilder = new FbCommandBuilder(emp);
                emp.InsertCommand = new FbCommand("ADD_TRADEMARKS", conn);
                emp.InsertCommand.CommandType = CommandType.StoredProcedure;
                emp.InsertCommand.Parameters.Add(new FbParameter("@INP_TRADEMARK", FbDbType.VarChar, 200, "TRADEMARK"));
                emp.InsertCommand.Parameters.Add(new FbParameter("@INP_DESCRIPTION", FbDbType.VarChar, 500, "DESCRIPTION"));
                DataSet ds = new DataSet();
                emp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                newRow["TRADEMARK"] = textBox2.Text;
                newRow["DESCRIPTION"] = textBox3.Text;
                dt.Rows.Add(newRow);
                emp.Update(ds);
                ds.AcceptChanges();
                MessageBox.Show("Рядок було зареєстровано в базі даних");
            }
            catch (Exception ec){
                MessageBox.Show("Виняток: " + ec.Message);//Exception
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FbConnection conn = DBConnect.GetConnection();
            DataTable table = new DataTable();
            string myQuery = "Select * from USERS";
            FbCommand command = new FbCommand(myQuery, conn);         
            FbDataAdapter adapter = new FbDataAdapter(command);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table; 
            table.ExportToExcel(@"..\source\repos\warehouse\warehouse\bin\Debug\users.xlsx");      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FbConnection conn = DBConnect.GetConnection();
            FbCommand delete = new FbCommand("EXECUTE PROCEDURE DEL_TRADEMARKK ("+textBox4.Text+")", conn);
            MessageBox.Show(delete.ToString());
            try{
                delete.ExecuteNonQuery();
                MessageBox.Show("ok");
            }
            catch (FbException ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void категоріїТоварівToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string myQuery = "Select * from CATEGORIES";
            FbCommand command = new FbCommand(myQuery, conn);
            FbDataAdapter adapter = new FbDataAdapter(command);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            table.ExportToExcel(@"..\source\repos\warehouse\warehouse\bin\Debug\reports\CATEGORIES.xlsx");
        }
 

        private void ActsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _f_A_S = new Acts_STOREKEEPER(); _f_A_S.Show(this);
        }

        private void certificate_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void about_app_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FAQ_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



    }
}
