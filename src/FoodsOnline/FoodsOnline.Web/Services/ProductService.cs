using System.Text;
using System.Text.Json;
using FoodsOnline.Web.ViewModels;
using FoodsOnline.Web.Services.Contracts;

namespace FoodsOnline.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndpoint = "/api/Product/";
        private readonly JsonSerializerOptions _options;

        private ProductViewModel productViewModel;
        private IEnumerable<ProductViewModel> listProductViewModel;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; 
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var client = _clientFactory.CreateClient("UrlApi");

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    listProductViewModel = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }

            return listProductViewModel;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var client = _clientFactory.CreateClient("UrlApi");

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    productViewModel = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }

            return productViewModel;
        }

        public async Task<ProductViewModel> Create(ProductViewModel productViewModel)
        {
            var client = _clientFactory.CreateClient("UrlApi");

            StringContent content = new StringContent(JsonSerializer.Serialize(productViewModel), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    productViewModel = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }

            return productViewModel;

        }

        public async Task<ProductViewModel> Update(ProductViewModel productViewModel)
        {
            var client = _clientFactory.CreateClient("UrlApi");

            ProductViewModel product = new ProductViewModel();

            using (var response = await client.PutAsJsonAsync(apiEndpoint, productViewModel))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    product = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }

            return product;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _clientFactory.CreateClient("UrlApi");

            using (var response = await client.DeleteAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode) return true;
            }

            return false;
        }
    }
}
