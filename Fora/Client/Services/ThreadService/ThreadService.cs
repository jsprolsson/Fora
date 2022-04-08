using System.Net.Http.Json;

namespace Fora.Client.Services.ThreadService
{
    public class ThreadService : IThreadService
    {
        private readonly HttpClient _http;

        public ThreadService(HttpClient http)
        {
            _http = http;
        }
        public async Task CreateThread(ThreadCreateDto thread)
        {
            var result = await _http.PostAsJsonAsync($"api/interests/{thread.InterestId}/threads", thread);
        }
    }
}
