namespace CodePlex.Tools.HttpSysConfig.Interop
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;

    public static unsafe class HttpApi
    {
        const int HTTP_INITIALIZE_CONFIG = 2;
        const string httpapi = "httpapi.dll";

        static HttpApi()
        {
            // Given the scope and lifetime of the tool, just rely on HTTP.SYS to clean this up on process exit
            HTTPAPI_VERSION version = new HTTPAPI_VERSION(1, 0);
            ErrorCode errorCode = HttpInitialize(version, HTTP_INITIALIZE_CONFIG, IntPtr.Zero);
            if (errorCode != ErrorCode.ERROR_SUCCESS)
            {
                throw new Win32Exception((int)errorCode);
            }
        }

        enum ErrorCode
        {
            ERROR_SUCCESS = 0,
            ERROR_FILE_NOT_FOUND = 2,
            ERROR_INSUFFICIENT_BUFFER = 122,
            ERROR_ALREADY_EXISTS = 183,
            ERROR_NO_MORE_ITEMS = 259,
        }

        enum HTTP_SERVICE_CONFIG_ID
        {
            HttpServiceConfigIPListenList = 0,
            HttpServiceConfigSSLCertInfo,
            HttpServiceConfigUrlAclInfo,
            HttpServiceConfigMax
        }

        enum HTTP_SERVICE_CONFIG_QUERY_TYPE
        {
            HttpServiceConfigQueryExact = 0,
            HttpServiceConfigQueryNext,
            HttpServiceConfigQueryMax
        }

        public static void CreateSsl(HttpConfigSslEntry entry)
        {
            if (entry == null)
            {
                return;
            }
            using (HttpConfigSslEntryInterop interop = new HttpConfigSslEntryInterop(entry))
            {
                HTTP_SERVICE_CONFIG_SSL_SET configInformation = interop.GetConfigInformation();
                ErrorCode errorCode = HttpSetServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigSSLCertInfo, ref configInformation, Marshal.SizeOf(configInformation), IntPtr.Zero);
                if (errorCode != ErrorCode.ERROR_SUCCESS)
                {
                    throw new Win32Exception((int)errorCode);
                }
            }
        }

        public static void CreateUrlAcl(HttpConfigUrlAclEntry entry)
        {
            if (entry == null)
            {
                return;
            }
            HTTP_SERVICE_CONFIG_URLACL_SET configInformation = new HTTP_SERVICE_CONFIG_URLACL_SET();
            configInformation.KeyDesc = new HTTP_SERVICE_CONFIG_URLACL_KEY(entry.UriPrefix);
            configInformation.ParamDesc = new HTTP_SERVICE_CONFIG_URLACL_PARAM(entry.SecurityDescriptor.GetSddlForm(AccessControlSections.All));
            ErrorCode errorCode = HttpSetServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, ref configInformation, Marshal.SizeOf(configInformation), IntPtr.Zero);
            if (errorCode != ErrorCode.ERROR_SUCCESS)
            {
                throw new Win32Exception((int)errorCode);
            }
        }

        public static void DeleteSsl(IPEndPoint iPEndPoint)
        {
            if (iPEndPoint == null)
            {
                return;
            }
            using (HttpConfigSslEntryInterop interop = new HttpConfigSslEntryInterop(iPEndPoint))
            {
                HTTP_SERVICE_CONFIG_SSL_SET configInformation = interop.GetConfigInformation();
                ErrorCode errorCode = HttpDeleteServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigSSLCertInfo, ref configInformation, Marshal.SizeOf(configInformation), IntPtr.Zero);
                if (errorCode != ErrorCode.ERROR_FILE_NOT_FOUND && errorCode != ErrorCode.ERROR_SUCCESS)
                {
                    throw new Win32Exception((int)errorCode);
                }
            }
        }

        public static void DeleteUrlAcl(string uriPrefix)
        {
            if (uriPrefix == null)
            {
                return;
            }
            HTTP_SERVICE_CONFIG_URLACL_SET configInformation = new HTTP_SERVICE_CONFIG_URLACL_SET();
            configInformation.KeyDesc = new HTTP_SERVICE_CONFIG_URLACL_KEY(uriPrefix);
            int configInformationSize = Marshal.SizeOf(configInformation);
            ErrorCode errorCode = HttpDeleteServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, ref configInformation, configInformationSize, IntPtr.Zero);
            if (errorCode != ErrorCode.ERROR_FILE_NOT_FOUND && errorCode != ErrorCode.ERROR_SUCCESS)
            {
                throw new Win32Exception((int)errorCode);
            }
        }

        public static HttpConfigUrlAcl GetHttpReservations()
        {
            HttpConfigUrlAcl result = new HttpConfigUrlAcl();
            int size;
            for (int count = 0;; count++)
            {
                HTTP_SERVICE_CONFIG_URLACL_QUERY query = new HTTP_SERVICE_CONFIG_URLACL_QUERY(HTTP_SERVICE_CONFIG_QUERY_TYPE.HttpServiceConfigQueryNext, new HTTP_SERVICE_CONFIG_URLACL_KEY(null), count);
                ErrorCode errorCode = HttpQueryServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, ref query, Marshal.SizeOf(query), null, 0, out size, IntPtr.Zero);
                if (errorCode != ErrorCode.ERROR_SUCCESS)
                {
                    if (errorCode == ErrorCode.ERROR_NO_MORE_ITEMS)
                    {
                        break;
                    }
                    if (errorCode != ErrorCode.ERROR_INSUFFICIENT_BUFFER)
                    {
                        throw new Win32Exception((int)errorCode);
                    }
                    byte[] buffer = new byte[size];
                    fixed (byte *b = buffer)
                    {
                        errorCode = HttpQueryServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigUrlAclInfo, ref query, Marshal.SizeOf(query), b, size, out size, IntPtr.Zero);
                        if (errorCode != ErrorCode.ERROR_SUCCESS)
                        {
                            throw new Win32Exception((int)errorCode);
                        }
                        HTTP_SERVICE_CONFIG_URLACL_SET output = (HTTP_SERVICE_CONFIG_URLACL_SET)Marshal.PtrToStructure((IntPtr)b, typeof(HTTP_SERVICE_CONFIG_URLACL_SET));
                        result.Add(output.KeyDesc.pUrlPrefix, output.ParamDesc.pStringSecurityDescriptor);
                    }
                }
            }
            return result;
        }

        public static HttpConfigSsl GetHttpSslConfig()
        {
            HttpConfigSsl result = new HttpConfigSsl();
            int size;
            for (int count = 0;; count++)
            {
                HTTP_SERVICE_CONFIG_SSL_QUERY query = new HTTP_SERVICE_CONFIG_SSL_QUERY(HTTP_SERVICE_CONFIG_QUERY_TYPE.HttpServiceConfigQueryNext, new HTTP_SERVICE_CONFIG_SSL_KEY(), count);
                ErrorCode errorCode = HttpQueryServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigSSLCertInfo, ref query, Marshal.SizeOf(query), null, 0, out size, IntPtr.Zero);
                if (errorCode != ErrorCode.ERROR_SUCCESS)
                {
                    if (errorCode == ErrorCode.ERROR_NO_MORE_ITEMS)
                    {
                        break;
                    }
                    if (errorCode != ErrorCode.ERROR_INSUFFICIENT_BUFFER)
                    {
                        throw new Win32Exception((int)errorCode);
                    }
                    byte[] buffer = new byte[size];
                    fixed (byte *b = buffer)
                    {
                        errorCode = HttpQueryServiceConfiguration(IntPtr.Zero, HTTP_SERVICE_CONFIG_ID.HttpServiceConfigSSLCertInfo, ref query, Marshal.SizeOf(query), b, size, out size, IntPtr.Zero);
                        if (errorCode != ErrorCode.ERROR_SUCCESS)
                        {
                            throw new Win32Exception((int)errorCode);
                        }
                        HTTP_SERVICE_CONFIG_SSL_SET output = (HTTP_SERVICE_CONFIG_SSL_SET)Marshal.PtrToStructure((IntPtr)b, typeof(HTTP_SERVICE_CONFIG_SSL_SET));
                        result.Add(output.KeyDesc, output.ParamDesc);
                    }
                }
            }
            return result;
        }

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpDeleteServiceConfiguration(IntPtr serviceIntPtr, HTTP_SERVICE_CONFIG_ID configId, ref HTTP_SERVICE_CONFIG_URLACL_SET configInformation, int configInformationLength, IntPtr pOverlapped);

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpDeleteServiceConfiguration(IntPtr serviceIntPtr, HTTP_SERVICE_CONFIG_ID configId, ref HTTP_SERVICE_CONFIG_SSL_SET configInformation, int configInformationLength, IntPtr pOverlapped);

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpInitialize(HTTPAPI_VERSION version, int flags, IntPtr pReserved);

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpQueryServiceConfiguration(IntPtr nullHandle, HTTP_SERVICE_CONFIG_ID ConfigId, ref HTTP_SERVICE_CONFIG_URLACL_QUERY pInputConfigInfo, int InputConfigInfoLength, byte* pOutputConfigInfo, int OutputConfigInfoLength, out int pReturnLength, IntPtr pOverlapped);

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpQueryServiceConfiguration(IntPtr nullHandle, HTTP_SERVICE_CONFIG_ID ConfigId, ref HTTP_SERVICE_CONFIG_SSL_QUERY pInputConfigInfo, int InputConfigInfoLength, byte* pOutputConfigInfo, int OutputConfigInfoLength, out int pReturnLength, IntPtr pOverlapped);

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpSetServiceConfiguration(IntPtr nullHandle, HTTP_SERVICE_CONFIG_ID configId, ref HTTP_SERVICE_CONFIG_URLACL_SET configInformation, int configInformationLength, IntPtr pOverlapped);

        [DllImport(httpapi, SetLastError = true)]
        static extern ErrorCode HttpSetServiceConfiguration(IntPtr nullHandle, HTTP_SERVICE_CONFIG_ID configId, ref HTTP_SERVICE_CONFIG_SSL_SET configInformation, int configInformationLength, IntPtr pOverlapped);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_SSL_KEY
        {
            public IntPtr pIpPort; // PSOCKADDR

            public HTTP_SERVICE_CONFIG_SSL_KEY(IntPtr pIpPort)
            {
                this.pIpPort = pIpPort;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_SSL_PARAM
        {
            public uint SslHashLength;
            public IntPtr pSslHash;
            public Guid AppId;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pSslCertStoreName;
            public HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK DefaultCertCheckMode;
            public uint DefaultRevocationFreshnessTime;
            public uint DefaultRevocationUrlRetrievalTimeout;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDefaultSslCtlIdentifier;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDefaultSslCtlStoreName;
            public HTTP_SERVICE_CONFIG_SSL_FLAG DefaultFlags;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_SSL_SET
        {
            public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;
            public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_URLACL_KEY
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pUrlPrefix;

            public HTTP_SERVICE_CONFIG_URLACL_KEY(string urlPrefix)
            {
                pUrlPrefix = urlPrefix;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct HTTP_SERVICE_CONFIG_URLACL_PARAM
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pStringSecurityDescriptor;

            public HTTP_SERVICE_CONFIG_URLACL_PARAM(string securityDescriptor)
            {
                pStringSecurityDescriptor = securityDescriptor;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HTTP_SERVICE_CONFIG_URLACL_SET
        {
            public HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;
            public HTTP_SERVICE_CONFIG_URLACL_PARAM ParamDesc;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct HTTP_SERVICE_CONFIG_SSL_QUERY
        {
            HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
            HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;
            int dwToken;

            public HTTP_SERVICE_CONFIG_SSL_QUERY(HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc, HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc, int dwToken)
            {
                this.QueryDesc = QueryDesc;
                this.KeyDesc = KeyDesc;
                this.dwToken = dwToken;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HTTP_SERVICE_CONFIG_URLACL_QUERY
        {
            HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
            HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;
            int dwToken;

            public HTTP_SERVICE_CONFIG_URLACL_QUERY(HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc, HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc, int dwToken)
            {
                this.QueryDesc = QueryDesc;
                this.KeyDesc = KeyDesc;
                this.dwToken = dwToken;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        struct HTTPAPI_VERSION
        {
            ushort HttpApiMajorVersion;
            ushort HttpApiMinorVersion;

            public HTTPAPI_VERSION(ushort majorVersion, ushort minorVersion)
            {
                HttpApiMajorVersion = majorVersion;
                HttpApiMinorVersion = minorVersion;
            }
        }
    }
}
