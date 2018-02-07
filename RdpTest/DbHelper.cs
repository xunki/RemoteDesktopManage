using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using RdpTest.Properties;

namespace RdpTest
{
    public class Db
    {
        static Db()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "config.wdb";

            //检查数据库是否存在，不在则新建
            if (!File.Exists(path))
                File.WriteAllBytes(path, Resources.Db);

            //初始化数据库连接串
            Connection = new SQLiteConnection($"Data Source={path};Pooling=true;FailIfMissing=false");
            Connection.Open();
        }

        public static readonly IDbConnection Connection;

    }
}
