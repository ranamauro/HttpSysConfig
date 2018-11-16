namespace CodePlex.Tools.HttpSysConfig
{
    using System.Collections.Generic;
    using CodePlex.Tools.HttpSysConfig.Interop;

    public class HttpConfigSsl : List < HttpConfigSslEntry >
    {
        public HttpConfigSsl()
            : base()
        {
        }

        public static HttpConfigSsl GetHttpSslConfig()
        {
            return HttpApi.GetHttpSslConfig();
        }

        public void Add(HttpApi.HTTP_SERVICE_CONFIG_SSL_KEY key, HttpApi.HTTP_SERVICE_CONFIG_SSL_PARAM param)
        {
            base.Add(new HttpConfigSslEntry(key, param));
        }
    }
}
