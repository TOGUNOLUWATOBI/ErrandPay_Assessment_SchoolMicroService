using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Serilog;
using Services.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.SuperAdmin)]


    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        
        [Authorize(Roles = UserRoles.Staff + "," + UserRoles.SuperAdmin)]
        [HttpPost("")]

        public async Task<IActionResult> CreateCourse(CourseDTO model)
        {
            var response = await _courseService.CreateCourse(model);
            Log.Warning("UserIntegrationResponse : {@Response}", response);
            var finalResp = await GetNameAndRole(HttpContext.User.Identity as ClaimsIdentity);

            return Ok(finalResp);
        }

        
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Staff + "," + UserRoles.SuperAdmin)]
        [HttpGet("{courseCode}")]

        public async Task<IActionResult> GetCourse(string courseCode)
        {
            var response = await _courseService.GetCourse(courseCode);
            Log.Warning("UserIntegrationResponse : {@Response}", response);

            var finalResp = await GetNameAndRole(HttpContext.User.Identity as ClaimsIdentity);

            return Ok(finalResp);
        }

        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpDelete("DeleteCourse/{courseCode}")]
        public async Task<IActionResult> DeleteCourse(string courseCode)
        {
            var response = await _courseService.DeleteCourse(courseCode);
            Log.Warning("UserIntegrationResponse : {@Response}", response);

            var finalResp = await GetNameAndRole(HttpContext.User.Identity as ClaimsIdentity);

            return Ok(finalResp);
        }

               

        private async Task<FinalResponseDTO> GetNameAndRole(ClaimsIdentity identity)
        {
            var finaleResponse = new FinalResponseDTO();

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;

            // Gets name from claims. Generally it's an email address.
            finaleResponse.Name = claim
                .Where(x => x.Type == ClaimTypes.Name)
                .FirstOrDefault().Value;
            finaleResponse.Role = claim
                .Where(x => x.Type == ClaimTypes.Role)
                .FirstOrDefault().Value;
            return finaleResponse;
        }
    }
}
