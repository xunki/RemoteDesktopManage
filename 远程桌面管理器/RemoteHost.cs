namespace 远程桌面管理器
{
    public class RemoteHost
    {
        public int FId { get; set; }
        public string FName { get; set; }
        public int FParentId { get; set; }
        public int FSort { get; set; }

        public IpAddress IpAddress { get; set; }
    }
}
