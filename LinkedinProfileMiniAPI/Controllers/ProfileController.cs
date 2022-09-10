    using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Entities.SubModel;
using ServiceInterface.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkedinProfileMiniAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profile profile)
        {
            var result = await profileService.Create(profile);
            return Ok(result);
        }
        [HttpGet]
        public async Task<List<GetProfile>> Get(int page)
        {
            List<GetProfile> result = await profileService.Get(page);
            return result;
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Profile profile)
        {
            var result = await profileService.Update(profile);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await profileService.Delete(id);
            return Ok(result);
        }

    }
    [Route("api/[controller]")]
    public class FilterController : Controller
    {
        private readonly IProfileService profileService;
        public FilterController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public async Task<List<GetProfile>> GetFilter(string skill)
        {
            List<GetProfile> result = await profileService.GetFilter(skill);
            return result;
        }
    }
}
