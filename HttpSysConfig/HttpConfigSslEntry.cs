namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using CodePlex.Tools.HttpSysConfig.Interop;
    using System.Globalization;

    public class HttpConfigSslEntry
    {
        Guid appId;
        HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK defaultCertCheckMode;
        HTTP_SERVICE_CONFIG_SSL_FLAG defaultFlags;
        TimeSpan defaultRevocationFreshnessTime;
        TimeSpan defaultRevocationUrlRetrievalTimeout;
        string defaultSslCtlIdentifier;
        string defaultSslCtlStoreName;
        IPEndPoint endPoint;
        string sslCertStoreName;
        byte[] sslHash;

        public HttpConfigSslEntry(IPEndPoint endPoint, string sslHash, Guid appId, string sslCertStoreName, HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK defaultCertCheckMode, TimeSpan defaultRevocationFreshnessTime, TimeSpan defaultRevocationUrlRetrievalTimeout, string defaultSslCtlIdentifier, string defaultSslCtlStoreName, HTTP_SERVICE_CONFIG_SSL_FLAG defaultFlags)
        {
            this.appId = appId;
            this.defaultCertCheckMode = defaultCertCheckMode;
            this.defaultFlags = defaultFlags;
            this.defaultRevocationFreshnessTime = defaultRevocationFreshnessTime;
            this.defaultRevocationUrlRetrievalTimeout = defaultRevocationUrlRetrievalTimeout;
            this.defaultSslCtlIdentifier = defaultSslCtlIdentifier;
            this.defaultSslCtlStoreName = defaultSslCtlStoreName;
            this.endPoint = endPoint;
            this.sslCertStoreName = sslCertStoreName;
            this.sslHash = HttpConfigSslEntry.CertHashFromString(sslHash);
        }

        public unsafe HttpConfigSslEntry(HttpApi.HTTP_SERVICE_CONFIG_SSL_KEY key, HttpApi.HTTP_SERVICE_CONFIG_SSL_PARAM param)
        {
            byte *p = (byte *)key.pIpPort;
            SocketAddress sa = new SocketAddress(0, 48);
            for (int i = 0; i < sa.Size; i++)
            {
                sa[i] = *(p++);
            }
            IPEndPoint ep;
            if (sa.Family == AddressFamily.InterNetwork)
            {
                ep = (IPEndPoint)new IPEndPoint(IPAddress.Any, 0).Create(sa);
            }
            else
            {
                ep = (IPEndPoint)new IPEndPoint(IPAddress.IPv6Any, 0).Create(sa);
            }
            this.endPoint = ep;
            if (param.SslHashLength > 0 && param.pSslHash != IntPtr.Zero)
            {
                this.sslHash = new byte[param.SslHashLength];
                Marshal.Copy(param.pSslHash, this.sslHash, 0, (int)param.SslHashLength);
            }
            this.appId = param.AppId;
            if (!string.IsNullOrEmpty(param.pSslCertStoreName))
            {
                this.sslCertStoreName = param.pSslCertStoreName;
            }
            else
            {
                this.sslCertStoreName = StoreName.My.ToString();
            }
            this.defaultCertCheckMode = param.DefaultCertCheckMode;
            this.defaultRevocationFreshnessTime = TimeSpan.FromSeconds(param.DefaultRevocationFreshnessTime);
            this.defaultRevocationUrlRetrievalTimeout = TimeSpan.FromMilliseconds(param.DefaultRevocationUrlRetrievalTimeout);
            this.defaultSslCtlIdentifier = param.pDefaultSslCtlIdentifier;
            this.defaultSslCtlStoreName = param.pDefaultSslCtlStoreName;
            this.defaultFlags = param.DefaultFlags;
        }

        public Guid AppId
        {
            get { return appId; }
            set { appId = value; }
        }

        public HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK DefaultCertCheckMode
        {
            get { return defaultCertCheckMode; }
            set { defaultCertCheckMode = value; }
        }

        public HTTP_SERVICE_CONFIG_SSL_FLAG DefaultFlags
        {
            get { return defaultFlags; }
            set { defaultFlags = value; }
        }

        public TimeSpan DefaultRevocationFreshnessTime
        {
            get { return defaultRevocationFreshnessTime; }
            set { defaultRevocationFreshnessTime = value; }
        }

        public TimeSpan DefaultRevocationUrlRetrievalTimeout
        {
            get { return defaultRevocationUrlRetrievalTimeout; }
            set { defaultRevocationUrlRetrievalTimeout = value; }
        }

        public string DefaultSslCtlIdentifier
        {
            get { return defaultSslCtlIdentifier; }
            set { defaultSslCtlIdentifier = value; }
        }

        public string DefaultSslCtlStoreName
        {
            get { return defaultSslCtlStoreName; }
            set { defaultSslCtlStoreName = value; }
        }

        public IPEndPoint EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public string SslCertStoreName
        {
            get { return sslCertStoreName; }
            set { sslCertStoreName = value; }
        }

        public byte[] SslHash
        {
            get { return sslHash; }
            set { sslHash = value; }
        }

        public static byte[] CertHashFromString(string hash)
        {
            if (hash == null || hash.Length == 0)
            {
                return null;
            }
            byte[] result = new byte[hash.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = byte.Parse(hash.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            return result;
        }

        public static string CertHashToString(byte[] hash)
        {
            if (hash == null || hash.Length == 0)
            {
                return null;
            }
            StringBuilder result = new StringBuilder();
            foreach (byte b in hash)
            {
                result.Append(string.Format("{0:X}", b));
            }
            return result.ToString();
        }

        public void Create()
        {
            HttpApi.CreateSsl(this);
        }

        public void Delete()
        {
            HttpApi.DeleteSsl(this.EndPoint);
        }

        public override string ToString()
        {
            return endPoint.ToString();
        }
    }
}
