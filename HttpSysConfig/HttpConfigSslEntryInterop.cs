namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.Net;
    using System.Runtime.InteropServices;
    using CodePlex.Tools.HttpSysConfig.Interop;

    public class HttpConfigSslEntryInterop : IDisposable
    {
        HttpConfigSslEntry entry;
        HttpApi.HTTP_SERVICE_CONFIG_SSL_SET interop;
        IPEndPoint iPEndPoint;

        public HttpConfigSslEntryInterop(HttpConfigSslEntry entry)
            : this(entry.EndPoint)
        {
            this.entry = entry;
        }

        public HttpConfigSslEntryInterop(IPEndPoint iPEndPoint)
        {
            this.iPEndPoint = iPEndPoint;
        }

        public void Dispose()
        {
            if (interop.KeyDesc.pIpPort != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(interop.KeyDesc.pIpPort);
            }
            if (interop.ParamDesc.pSslHash != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(interop.ParamDesc.pSslHash);
            }
        }

        public HttpApi.HTTP_SERVICE_CONFIG_SSL_SET GetConfigInformation()
        {
            this.interop = new HttpApi.HTTP_SERVICE_CONFIG_SSL_SET();
            SocketAddress sa = this.iPEndPoint.Serialize();
            this.interop.KeyDesc.pIpPort = Marshal.AllocHGlobal(sa.Size);
            for (int i = 0; i < sa.Size; i++)
            {
                Marshal.WriteByte(this.interop.KeyDesc.pIpPort, i, sa[i]);
            }
            if (this.entry != null)
            {
                this.interop.ParamDesc.AppId = entry.AppId;
                this.interop.ParamDesc.DefaultCertCheckMode = entry.DefaultCertCheckMode;
                this.interop.ParamDesc.DefaultFlags = entry.DefaultFlags;
                this.interop.ParamDesc.DefaultRevocationFreshnessTime = (uint)entry.DefaultRevocationFreshnessTime.Seconds;
                this.interop.ParamDesc.DefaultRevocationUrlRetrievalTimeout = (uint)entry.DefaultRevocationUrlRetrievalTimeout.Milliseconds;
                this.interop.ParamDesc.pDefaultSslCtlIdentifier = entry.DefaultSslCtlIdentifier;
                this.interop.ParamDesc.pDefaultSslCtlStoreName = entry.DefaultSslCtlStoreName;
                this.interop.ParamDesc.pSslCertStoreName = null;
                if (entry.SslHash != null)
                {
                    this.interop.ParamDesc.pSslHash = Marshal.AllocHGlobal(entry.SslHash.Length);
                    Marshal.Copy(entry.SslHash, 0, this.interop.ParamDesc.pSslHash, entry.SslHash.Length);
                    this.interop.ParamDesc.SslHashLength = (uint)entry.SslHash.Length;
                    if (!string.IsNullOrEmpty(entry.SslCertStoreName) && string.Compare(entry.SslCertStoreName, "my", true) != 0)
                    {
                        this.interop.ParamDesc.pSslCertStoreName = entry.SslCertStoreName;
                    }
                }
                else
                {
                    this.interop.ParamDesc.pSslHash = IntPtr.Zero;
                    this.interop.ParamDesc.SslHashLength = 0;
                }
            }
            return this.interop;
        }
    }
}
