using System.Net.Http.Json;

namespace Fora.Client.Services.InterestService
{
    public class InterestService : IInterestService
    {
        private readonly HttpClient _http;

        public InterestService(HttpClient http)
        {
            _http = http;
        }
        public List<InterestModel> Interests { get; set; }

        public async Task CreateInterest(InterestCreateDto interest)
        {
            var result = await _http.PostAsJsonAsync("api/interests", interest);
        }

        public async Task DeleteInterest(InterestDeleteDto interest)
        {
            var result = await _http.DeleteAsync($"api/interests/{interest.Id}");
        }

        public async Task GetInterests()
        {
            var result = await _http.GetFromJsonAsync<List<InterestModel>>("api/interests");

            if(result != null)
            {
                Interests = result;
            }
        }

        public async Task UpdateInterest(InterestUpdateDto interest)
        {
            var result = await _http.PutAsJsonAsync($"api/interests/{interest.Id}", interest);
        }
    }
}
