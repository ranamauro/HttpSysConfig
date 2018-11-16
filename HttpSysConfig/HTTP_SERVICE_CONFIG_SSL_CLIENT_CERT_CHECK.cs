namespace CodePlex.Tools.HttpSysConfig
{
    using System;

    [Flags]
    public enum HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK : uint
    {
        /// <summary>
        /// Client certificate is not to be verified for revocation
        /// Revocation checking is done on all certificates in all of the chains except the root certificate
        /// ~CERT_CHAIN_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT
        /// </summary>
        NoCheck = 0x1,
        /// <summary>
        /// Only cached certificate revocation is to be used: CERT_CHAIN_REVOCATION_CHECK_CACHE_ONLY
        /// </summary>
        CachedOnly = 0x2,
        /// <summary>
        /// The DefaultRevocationFreshnessTime setting is enabled.
        /// fCheckRevocationFreshnessTime AND dwRevocationFreshnessTime
        /// </summary>
        UseDefaultRevocationFreshnessTime = 0x4,
        /// <summary>
        /// No usage check is to be performed.
        /// fOmitUsageCheck
        /// </summary>
        NoUsage = 0x10000,
    }
}
