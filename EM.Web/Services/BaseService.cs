using EM.Web.Service.IService;
using Newtonsoft.Json;
using System.Text;
using EM.Core.Models.Dto;

namespace EM.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("EMClient");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.Url);

            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            switch (requestDto.ApiMethod)
            {
                case ApiMethod.POST:
                    message.Method = HttpMethod.Post; break;
                case ApiMethod.PUT:
                    message.Method = HttpMethod.Put; break;
                case ApiMethod.DELETE:
                    message.Method = HttpMethod.Delete; break;
                default:
                    message.Method = HttpMethod.Get; break;
            }

            HttpResponseMessage response = await client.SendAsync(message);

            var apiContent = await response.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            return apiResponseDto;
        }
    }
}
