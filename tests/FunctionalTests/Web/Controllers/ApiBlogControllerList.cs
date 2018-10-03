using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Core.Entities;
using Newtonsoft.Json;
using Web;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class ApiBlogControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public ApiBlogControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsAllBlogs()
        {
            var response = await Client.GetAsync("/api/Blog");
            string jsonResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<Blog>>(stringResponse);
            Assert.Equal(5, model.Count());
        }

        [Fact]
        public async Task ReturnsEmptyJson()
        {
            var response = await Client.GetAsync("/api/Blog/0");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Equal("[]", stringResponse);
        }

        [Fact]
        public async Task ReturnsBlogById()
        {
            var response = await Client.GetAsync("/api/Blog/1");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<Blog>>(stringResponse);
            Assert.Single(model);
        }

        [Fact]
        public async Task ReturnsAllBlogCategories()
        {
            var response = await Client.GetAsync("/api/Blog/Categories");
            string jsonResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<Blog>>(stringResponse);
            Assert.Equal(5, model.Count());
        }

    }
}