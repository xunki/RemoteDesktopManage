using System.Data;
using System.Data.SQLite;

namespace 远程桌面管理器
{
    static partial class SqlMapper
    {
        public static DataTable GetDataTable(this SQLiteConnection conn, string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                var adapter = new SQLiteDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
}
