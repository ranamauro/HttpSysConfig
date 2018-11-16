namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.Collections.Generic;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using CodePlex.Tools.HttpSysConfig.Interop;

    public class HttpConfigUrlAclEntry
    {
        string host;
        RawSecurityDescriptor securityDescriptor;
        Uri uri;
        string uriPrefix;

        public HttpConfigUrlAclEntry(string uriPrefix, string securityDescriptor)
        {
            this.uriPrefix = uriPrefix;
            this.securityDescriptor = new RawSecurityDescriptor(securityDescriptor);
            if (uriPrefix.StartsWith("http://+:") || uriPrefix.StartsWith("https://+:"))
            {
                this.host = "+";
                this.uri = new Uri(uriPrefix.Replace("://+:", "://__STRONG_WILDCARD:"));
            }
            else if (uriPrefix.StartsWith("http://*:") || uriPrefix.StartsWith("https://*:"))
            {
                this.host = "*";
                this.uri = new Uri(uriPrefix.Replace("://*:", "://__WEAK_WILDCARD:"));
            }
            else
            {
                this.uri = new Uri(uriPrefix);
                this.host = this.uri.Host;
            }
        }

        public List < NTAccount > Accounts
        {
            get
            {
                List < NTAccount > accounts = new List < NTAccount >();
                foreach (CommonAce ace in SecurityDescriptor.DiscretionaryAcl)
                {
                    accounts.Add((NTAccount)ace.SecurityIdentifier.Translate(typeof(NTAccount)));
                }
                return accounts;
            }
        }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public RawSecurityDescriptor SecurityDescriptor
        {
            get { return securityDescriptor; }
            set { securityDescriptor = value; }
        }

        public Uri Uri
        {
            get { return uri; }
            set { uri = value; }
        }

        public string UriPrefix
        {
            get { return uriPrefix; }
            set { uriPrefix = value; }
        }

        public void Create()
        {
            HttpApi.CreateUrlAcl(this);
        }

        public void Delete()
        {
            HttpApi.DeleteUrlAcl(this.UriPrefix);
        }

        public override string ToString()
        {
            return uriPrefix;
        }
    }
}
