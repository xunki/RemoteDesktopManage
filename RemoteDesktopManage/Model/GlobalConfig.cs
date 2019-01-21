using System.Collections.Generic;

namespace RdpTest.Model
{
    public class GlobalConfig
    {
        public static GlobalConfig Instance { get; set; }


        /// <summary>
        /// 用户名
        /// </summary>
        public string User { get; set; } = "Administrator";

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 共享剪切板
        /// </summary>
        public bool ConnectSession0 { get; set; } = false;

        /// <summary>
        /// 共享所有磁盘
        /// </summary>
        public bool ShareAllDisk { get; set; } = true;

        /// <summary>
        /// 共享磁盘列表，当 ShareAllDisk = false 时使用
        /// </summary>
        public List<string> ShareDiskList { get; set; } = new List<string>();
    }
}
