﻿using System.Net.Http.Json;

namespace Fora.Client.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _http;

        public MessageService(HttpClient http)
        {
            _http = http;
        }

        public async Task CreateMessage(MessageCreateDto messageToCreate)
        {
            var result = await _http.PostAsJsonAsync($"api/threads/{messageToCreate.ThreadId}/messages", messageToCreate);
        }

        public async Task DeleteMessage(MessageDeleteDto messageToDelete)
        {
            var result = await _http.DeleteAsync($"api/threads/{messageToDelete.ThreadId}/messages/{messageToDelete.Id}");
        }

        public async Task<List<MessageModel>> GetMessages(int threadId)
        {
            var result = await _http.GetFromJsonAsync<List<MessageModel>>($"api/threads/{threadId}/messages");
            if (result != null)
            {
                return result;
            }
            else return null;
        }

        public async Task UpdateMessage(MessageUpdateDto messageToUpdate)
        {
            var result = await _http.PutAsJsonAsync($"api/threads/{messageToUpdate.ThreadId}/messages", messageToUpdate);
        }

    }
}
