using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZivverSharedModel;

namespace ZivverServiceProvider.JsonPostService
{
    public interface IJsonPlaceHolderService
    {
        Task<List<PostDto>> GetPostAsync();
    }
    public sealed class JsonPlaceHolderService : IJsonPlaceHolderService
    {
       
        public async Task<List<PostDto>> GetPostAsync()
        {
            return await CallJsonPlaceHolderAsync();
        }
        

        private async Task<List<PostDto>> CallJsonPlaceHolderAsync()
        {
            try
            {

                HttpClient clinet = new HttpClient();
                clinet.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                clinet.DefaultRequestHeaders.Accept.Clear();
                clinet.DefaultRequestHeaders.Add("Content-Type", "application/json");
                var response = await clinet.GetAsync("/posts");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<PostDto>>(jsonResponse);

                    return result;

                }

                return default;

            }
            catch (Exception ex)
            {
               
                return default;
            }
        }
    }
}
