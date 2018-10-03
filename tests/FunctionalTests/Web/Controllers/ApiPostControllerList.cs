using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Core.Entities;
using Application.Core.Enums;
using Newtonsoft.Json;
using Web;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class ApiPostControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public ApiPostControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task FeaturedArticle()
        {
            var response = await Client.GetAsync("/api/Post/FeaturedArticle");
            string jsonResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<Post>(stringResponse);
            Assert.Equal(PostType.FeaturedArticle, model.Type);
        }

        [Fact]
        public async Task FeaturedNews()
        {
            var response = await Client.GetAsync("/api/Post/FeaturedNews");
            string jsonResult = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<Post>(stringResponse);
            Assert.Equal(PostType.FeaturedNews, model.Type);
        }

    }
}