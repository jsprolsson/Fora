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
        public async Task CreateThread(ThreadCreateDto threadToCreate)
        {
            var result = await _http.PostAsJsonAsync($"api/interests/{threadToCreate.InterestId}/threads", threadToCreate);
        }

        public async Task DeleteThread(ThreadDeleteDto threadToDelete)
        {
            var result = await _http.DeleteAsync($"api/interests/{threadToDelete.InterestId}/threads/{threadToDelete.Id}");
        }

        public async Task<ThreadModel> GetThread(ThreadDto thread)
        {
            var result = await _http.GetFromJsonAsync<ThreadModel>($"api/interests/{thread.InterestId}/threads/{thread.Id}");
            if (result != null)
            {
                return result;
            }
            else return null;
        }

        public async Task<List<ThreadModel>> GetThreads(int interestId)
        {
            var result = await _http.GetFromJsonAsync<List<ThreadModel>>($"api/interests/{interestId}/threads");

            if (result != null)
            {
                return result;
            }
            else return null;
        }

        public async Task<List<ThreadModel>> GetUserCreatedThreads(int userId)
        {
            var result = await _http.GetFromJsonAsync<List<ThreadModel>>($"api/interests/1/threads/usercreated/{userId}");

            if (result != null)
            {
                return result;
            }
            else return null;
        }

        public async Task UpdateThread(ThreadUpdateDto threadToUpdate)
        {
            var result = await _http.PutAsJsonAsync($"api/interests/{threadToUpdate.InterestId}/threads/{threadToUpdate.Id}", threadToUpdate);
        }
    }
}
