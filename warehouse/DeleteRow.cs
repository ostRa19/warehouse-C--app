using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouse
{
    public static class DeleteRow
    {
        public static void DeleteFromTable(string tB)
        {
            FbConnection conn = DBConnect.GetConnection();
            FbCommand delete = new FbCommand("EXECUTE PROCEDURE DEL_TRADEMARKK (" + tB+ ")", conn);
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
         //   return null;
        }
    }
}
