

using System;
using System.Windows.Forms;

namespace 远程桌面管理器
{
    public class Common
    {
        public static readonly string ConnectionString = string.Format("Data Source={0}{1};Pooling=true;FailIfMissing=false",
           Environment.CurrentDirectory, @"\config.wdb");
    }
}
