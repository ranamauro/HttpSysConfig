namespace CodePlex.Tools.HttpSysConfig
{
    using System;

    [Flags]
    public enum HTTP_SERVICE_CONFIG_SSL_FLAG : uint
    {
        /// <summary>
        /// Client certificates are mapped where possible to corresponding operating-system user accounts based on the certificate mapping rules stored in Active Directory. 
        /// If this flag is set and the mapping is successful, the Token member of the HTTP_SSL_CLIENT_CERT_INFO structure is a handle to an access token. Release this token explicitly by closing the handle when the HTTP_SSL_CLIENT_CERT_INFO structure is no longer required.
        /// ~SCH_CRED_NO_SYSTEM_MAPPER
        /// </summary>
        UseDsMapper = 0x1,
        /// <summary>
        /// Enables a client certificate to be cached locally for subsequent use.
        /// </summary>
        NegotiateClientCert = 0x2,
        /// <summary>
        /// Prevents SSL requests from being passed to low-level ISAPI filters.
        /// </summary>
        NoRawFilter = 0x4,
    }
}
