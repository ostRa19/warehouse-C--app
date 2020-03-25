using FirebirdSql.Data.FirebirdClient;
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
    public partial class Acts_STOREKEEPER : Form
    {
       FbConnection conn = DBConnect.GetConnection();
        public Acts_STOREKEEPER()
        {
            InitializeComponent();
        }
        private void Acts_STOREKEEPER_Load(object sender, EventArgs e)
        {
 
        }
        private void button2_Click(object sender, EventArgs e)
        {      
            FbCommand update = new FbCommand("EXECUTE PROCEDURE UPDAT_CATEGORIES(" + (textBox2.Text) + "," + (textBox5.Text) + ")", conn);
            try
            {
                update.ExecuteNonQuery();
                MessageBox.Show("ok");
            }
            catch (FbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FbConnection conn = DBConnect.GetConnection();
                string myQuery = "SELECT * FROM CATEGORIES";
                FbDataAdapter emp = new FbDataAdapter(myQuery, conn);
                FbCommandBuilder commandBuilder = new FbCommandBuilder(emp);
                emp.InsertCommand = new FbCommand("ADD_CATEGORIES", conn);
                emp.InsertCommand.CommandType = CommandType.StoredProcedure;
                emp.InsertCommand.Parameters.Add(new FbParameter("@INP_NAME_CATEGORY", FbDbType.VarChar, 200, "NAME_CATEGORY")); 
                DataSet ds = new DataSet();
                emp.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                newRow["NAME_CATEGORY"] = textBox1.Text;
                dt.Rows.Add(newRow);
                emp.Update(ds);
                ds.AcceptChanges();
                MessageBox.Show("Рядок було зареєстровано в базі даних");
            }
            catch (Exception ec)
            {
                MessageBox.Show("Виняток: " + ec.Message);//Exception
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FbConnection conn = DBConnect.GetConnection();
            FbCommand delete = new FbCommand("EXECUTE PROCEDURE DEL_CATEGORIES (" + textBox4.Text + ")", conn);
            MessageBox.Show(delete.ToString());
            try
            {
                delete.ExecuteNonQuery();
                MessageBox.Show("ok");
            }
            catch (FbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void getReport_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string myQuery = "Select * from GOODS_IN_WAREHOUSE where PRICE>= " + textBox6.Text + " AND PRICE <=" + textBox7.Text;
            FbCommand command = new FbCommand(myQuery, conn);
            FbDataAdapter adapter = new FbDataAdapter(command);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView2.DataSource = table; 
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                FbConnection conn = DBConnect.GetConnection();
                string myQuery = "SELECT * FROM SYPPLY";
                FbDataAdapter emp = new FbDataAdapter(myQuery, conn);
                FbCommandBuilder commandBuilder = new FbCommandBuilder(emp);
                emp.InsertCommand = new FbCommand("ADD_SYPPLY", conn);
                emp.InsertCommand.CommandType = CommandType.StoredProcedure;
                emp.InsertCommand.Parameters.Add(new FbParameter("@INP_NAME", FbDbType.VarChar, 200, "TRADEMARK"));
                emp.InsertCommand.Parameters.Add(new FbParameter("@INP_Date", FbDbType.Date, 11, "DESCRIPTION"));
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
            catch (Exception ec)
            {
                MessageBox.Show("Виняток: " + ec.Message);//Exception
            }
        }
    }
}
