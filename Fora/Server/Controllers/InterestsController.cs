using Fora.Server.Services.InterestService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fora.Server.Controllers
{
    [Route("api/interests")]
    [ApiController]
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
        public async Task<InterestModel> Post([FromBody] InterestModel interest)
        {
            await _interestService.CreateInterest(interest);
            return interest;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _interestService.DeleteInterest(id);
        }
    }
}
