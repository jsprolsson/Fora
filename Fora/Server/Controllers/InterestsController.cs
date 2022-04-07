using Fora.Server.Services.InterestService;
using Microsoft.AspNetCore.Mvc;

namespace Fora.Server.Controllers
{
    [Route("api/interests")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class InterestsController : ControllerBase
    {
        private readonly IInterestService _interestService;

        public InterestsController(IInterestService interestService)
        {
            _interestService = interestService ?? throw new ArgumentNullException(nameof(interestService));
        }

        [HttpGet]
        public async Task<List<InterestModel>> GetInterests()
        {
            return await _interestService.GetInterests();
        }

        [HttpGet("{id}")]
        public async Task<InterestModel> GetInterest(int id)
        {
            return await _interestService.GetInterest(id);
        }

        [HttpPost]
        public async Task Post([FromBody] InterestCreateDto interest)
        {
            await _interestService.CreateInterest(interest);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] InterestUpdateDto interestToUpdate)
        {
            var interestEntity = await _interestService.GetInterest(interestToUpdate.Id);
            if (interestEntity == null)
            {
                return NotFound();
            }

            InterestModel interest = new()
            {
                Id = interestToUpdate.Id,
                Name = interestToUpdate.Name,
                UserId = interestEntity.UserId,
                DateTimeCreated = interestEntity.DateTimeCreated,
                DateTimeModified = DateTime.Now,

            };

            await _interestService.UpdateInterest(interest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _interestService.DeleteInterest(id);
            return Ok();
        }
    }
}
