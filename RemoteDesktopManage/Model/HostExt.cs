using System.Collections.Generic;

namespace RdpTest.Model
{
    public class HostExt
    {
        /// <summary>
        /// 共享剪切板
        /// </summary>
        public bool ConnectSession0 { get; set; } 

        /// <summary>
        /// 共享所有磁盘
        /// </summary>
        public bool ShareAllDisk { get; set; } 

        /// <summary>
        /// 共享磁盘列表，当 ShareAllDisk = false 时使用
        /// </summary>
        public List<string> ShareDiskList { get; set; } = new List<string>();
    }
}
