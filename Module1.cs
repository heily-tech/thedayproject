using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace 로그인
{
    static class Module1
    {
        private static OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\database.accdb");

        public static void Connect()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }

        public static bool InsertUpdateDelete(string sql)
        {
            Connect();
            var cmd = new OleDbCommand(sql, cn);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool IsConfirm(string message)
        {
            return MessageBox.Show(message, "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static DataTable QueryAsDataTable(string sql)
        {
            var da = new OleDbDataAdapter(sql, cn);
            var ds = new DataSet();
            da.Fill(ds, "result");
            return ds.Tables["result"];
        }
    }
}