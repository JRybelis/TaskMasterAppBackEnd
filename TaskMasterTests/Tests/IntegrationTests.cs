using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using TaskMasterApp;
using TaskmasterCore.Models;
using TaskMasterTests.Data;
using Xunit;

namespace TaskMasterTests.Tests
{
    public class IntegrationTests
    {
        private readonly CustomWebApplicationFactory<Startup> _factory = new CustomWebApplicationFactory<Startup>();

        [Fact]
        public async Task GetIntegrationTest()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("/TaskItem");

            var stringContent = await result.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<TaskItem>>(stringContent);

            result.EnsureSuccessStatusCode();
            tasks.Should().NotBeEmpty();
        }

        [Fact]
        public async Task DeleteIntegrationTest()
        {
            var client = _factory.CreateClient();
            await client.DeleteAsync("/TaskItem/1");

            var result = await client.GetAsync("/TaskItem");
            var stringContent = await result.Content.ReadAsStringAsync();

            var tasks = JsonConvert.DeserializeObject<List<TaskItem>>(stringContent);

            result.EnsureSuccessStatusCode();
            tasks.Should().BeEmpty();
        }
    }
}
