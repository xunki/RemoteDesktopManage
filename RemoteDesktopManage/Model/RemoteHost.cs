using Newtonsoft.Json;

namespace RdpTest.Model
{
    public class RemoteHost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }

        private string _fullAddress;
        public string FullAddress => _fullAddress ?? (_fullAddress = Port == 3389 ? Address : $"{Address}:{Port}");

        public string User { get; set; }
        public string Pwd { get; set; }
        public int Sort { get; set; }
        public int ParentId { get; set; }

        public string RemoteProgram { get; set; }

        public string ExtJson { get; set; } = "";

        private HostExt _ext;
        public HostExt Ext => _ext ?? (_ext = JsonConvert.DeserializeObject<HostExt>(ExtJson) ?? new HostExt());

    }
}
