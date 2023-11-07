using System.Threading.Tasks;

namespace KenesApi.Services
{
    public interface IHttpRequestService
    {
        public string GetToken();
        public string GetOrders(string token);
        public dynamic GetOrder(string token, string id);

    }
}
