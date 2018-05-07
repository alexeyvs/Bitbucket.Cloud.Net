using System.IO;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.v2.Repositories;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests
{
    public class BitbucketCloudClientShould
    {
        private readonly IConfigurationRoot _configuration;
        protected readonly BitbucketCloudClient Client;

        protected BitbucketCloudClientShould()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Client = new BitbucketCloudClient(_configuration["url"], _configuration["username"], _configuration["password"]);
        }

        [Fact]
        public async Task AuthenticateWithOAuth()
        {
            var client = new BitbucketCloudClient(_configuration["url"], "2KytPTfjwjkR5khuyp", "NqtjTkPEDTWMWTM4Ax68MCFd87F4JQDk", "oauth");
            var results = await client.GetRepositoriesAsync(1);
            Assert.NotEmpty(results);
        }
    }
}
