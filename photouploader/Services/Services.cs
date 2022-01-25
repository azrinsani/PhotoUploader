using System.Net.Http;

namespace photouploader
{
    public static class Services
    {
        //public static MainVM MainVM;
        //public static IAppService AppService; 
        public static IDeviceService DeviceService; 
        public static HttpClient HttpClient => _httpClient ??= new HttpClient();
        private static HttpClient _httpClient;
    }
}