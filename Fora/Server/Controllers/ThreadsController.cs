using Fora.Server.Services.ThreadService;
using Microsoft.AspNetCore.Mvc;

namespace Fora.Server.Controllers
{
    [Route("api/interests/{interestId}/threads")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private readonly IThreadService _threadService;

        public ThreadsController(IThreadService threadService)
        {
            _threadService = threadService ?? throw new ArgumentNullException(nameof(threadService));
        }
        [HttpGet]
        public async Task<List<ThreadModel>> GetThreads(int interestId)
        {
            return await _threadService.GetThreads(interestId);
        }

        [HttpGet("{id}")]
        public async Task<ThreadModel> GetThread(int id)
        {
            return await _threadService.GetThread(id);
        }

        [HttpPost]
        public async Task<ThreadModel> Post([FromBody] ThreadModel thread)
        {
            await _threadService.CreateThread(thread);
            return thread;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Put(int interestId, int id, [FromBody] string name)
        {
            var threadEntity = await _threadService.GetThread(id);
            if (threadEntity == null)
            {
                return NotFound();
            }

            ThreadDto thread = new()
            {
                Id = id,
                Name = name,
                DateTimeModified = DateTime.Now,
                InterestId = interestId
            };

            await _threadService.UpdateThread(thread);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _threadService.DeleteThread(id);
            return Ok();
        }
    }
}
