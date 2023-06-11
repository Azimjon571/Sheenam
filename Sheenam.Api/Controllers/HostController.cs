using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Models.Foundations.Hosts.Exceptions;
using Sheenam.Api.Services.Foundations.Hosts;

namespace Sheenam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostController : RESTFulController
    {
        
        private readonly IHostService hostService;

        public HostController(IHostService hostService)=>
            this.hostService = hostService;
        [HttpPost]
        public async ValueTask<ActionResult<HoSt>> PostHostAsync(HoSt hoSt)
        {
            try
            {
                HoSt postedHost = await this.hostService.AddHostAsync(hoSt);

                return Created(postedHost);
            }
            catch (HostValidationException hostValidationException)
            {
                return BadRequest(hostValidationException.InnerException);
            }
            catch(HostDependencyValidationException hostDependencyValidationException)
                when (hostDependencyValidationException.InnerException is AlreadyExistHostException)
            {
                return Conflict(hostDependencyValidationException.InnerException);
            }
            catch(HostDependencyValidationException hostDependencyValidationException)
            {
                return BadRequest(hostDependencyValidationException.InnerException);
            }
            catch(HostDependencyException hostDependencyException)
            {
                return InternalServerError(hostDependencyException.InnerException);
            }
            catch(HostServiceException hostServiceException)
            {
                return InternalServerError(hostServiceException.InnerException);
            }
        }
    }
}
