using System.Text.Json;
using FoodsOnline.Web.ViewModels;
using FoodsOnline.Web.Services.Contracts;

namespace FoodsOnline.Web.Services
{
    public class CategoryService : ICategoryService
    {

        private const string apiEndpoint = "/api/Category/";
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var client = _clientFactory.CreateClient("UrlApi");

            IEnumerable<CategoryViewModel> category;

            var response = await client.GetAsync(apiEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                category = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }

            return category;
        }
    }
}
