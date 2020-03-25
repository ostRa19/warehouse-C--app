using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouse
{
    class DBConnect
    {
        private static FbConnection conn;

        public static FbConnection GetConnection()
        {
            if (conn == null)
            {
                FbConnectionStringBuilder sb = new FbConnectionStringBuilder
                {
                    //DataSource = "localhost",
                    Database = "WAREHOUSE.fdb",
                    UserID = "SYSDBA",
                    Password = "masterkey",
                    Charset = "UTF8",
                    Pooling = false,
                    ServerType = FbServerType.Embedded,
                };
                conn = new FbConnection(sb.ToString());
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        return conn;
                    }
                    else
                    {
                        throw new Exception("Не удалось подключиться к БД!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла ошибка:\n" + e.ToString(),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                return null;
            }
            else
            {
                return conn;
            }
        }
    }
}
