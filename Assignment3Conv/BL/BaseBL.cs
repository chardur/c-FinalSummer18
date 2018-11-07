using Assignment3Conv.Services;

namespace Assignment3Conv.BL
{
    public class BaseBL
    {
        public static string ApiCall(string url, string requestType, string data = null)
        {
            var apiService = new ApiService();
            apiService.PrimeRequest(url, requestType, data);
            return apiService.GetResponse(url, data);
        }
    }
}