using System;

namespace 远程桌面管理器
{
    public class IpAddress
    {
        public int FId { get; set; }
        public string FIpAddress { get; set; }
        public string FIpPort { get; set; }
        public string FLoginUser { get; set; }
        public string FPassword { get; set; }
        public string FFullUrl { get; set; }

        public int Port
        {
            get { return Convert.ToInt32(FIpPort); }
        }
    }
}
