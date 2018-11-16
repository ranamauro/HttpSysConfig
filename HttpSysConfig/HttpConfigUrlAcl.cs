namespace CodePlex.Tools.HttpSysConfig
{
    using System.Collections.Generic;
    using CodePlex.Tools.HttpSysConfig.Interop;

    public class HttpConfigUrlAcl : Dictionary < string, HttpConfigUrlAclEntry >
    {
        Dictionary < KeyValuePair < int, string >, List < HttpConfigUrlAclEntry > > dEntries;
        Dictionary < int, List < string > > dHosts;
        List < int > dPorts;

        public HttpConfigUrlAcl()
        {
            dPorts = new List < int >();
            dHosts = new Dictionary < int, List < string > >();
            dEntries = new Dictionary < KeyValuePair < int, string >, List < HttpConfigUrlAclEntry > >();
        }

        public static HttpConfigUrlAcl GetHttpReservations()
        {
            return HttpApi.GetHttpReservations();
        }

        public void Add(string uriPrefix, string securityDescriptor)
        {
            HttpConfigUrlAclEntry entry = new HttpConfigUrlAclEntry(uriPrefix, securityDescriptor);
            base.Add(uriPrefix, entry);
            if (!dPorts.Contains(entry.Uri.Port))
            {
                dPorts.Add(entry.Uri.Port);
            }
            if (!dHosts.ContainsKey(entry.Uri.Port))
            {
                dHosts[entry.Uri.Port] = new List < string >();
            }
            if (!dHosts[entry.Uri.Port].Contains(entry.Host))
            {
                dHosts[entry.Uri.Port].Add(entry.Host);
            }
            KeyValuePair < int, string > kv = new KeyValuePair < int, string >(entry.Uri.Port, entry.Host);
            if (!dEntries.ContainsKey(kv))
            {
                dEntries[kv] = new List < HttpConfigUrlAclEntry >();
            }
            dEntries[kv].Add(entry);
        }

        public List < HttpConfigUrlAclEntry > GetEntries(int port, string host)
        {
            return dEntries[new KeyValuePair < int, string >(port, host)];
        }

        public List < string > GetHosts(int port)
        {
            dHosts[port].Sort();
            return dHosts[port];
        }

        public List < int > GetPorts()
        {
            dPorts.Sort();
            return dPorts;
        }
    }
}
