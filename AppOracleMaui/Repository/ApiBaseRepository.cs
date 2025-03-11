
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppOracleMaui.Repository
{
    public class ApiBaseRepository<T> : IBaseRepository<T> where T : class, new()
    {

        private readonly HttpClient _client = new HttpClient();

        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        private const String _url = "http://10.0.2.2:5173/Transactions";


        public void Dispose()
        {
            
        }

        public async Task<List<T>> GetAll()
        {
            return await _client!.GetFromJsonAsync<List<T>>(_url);
        }

        public void Save(T item)
        {
            _client.PostAsJsonAsync(_url, item);
        }

       
    }
}
