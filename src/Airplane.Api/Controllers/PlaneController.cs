using System;
using System.Threading.Tasks;
using Airplane.Infrastructure.Commands.Events;
using Airplane.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airplane.Api.Controllers
{
    [Route("plane")]
    [Authorize(Policy = "HasAdminRole")]
    public class PlaneController : ApiControllerBase
    {
        private readonly IPlaneService _planeService;

        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpGet]
        [AllowAnonymous] //nie dotyczy [Authorize]
        public async Task<IActionResult> Get(string brandname)
        {
            var planes = await _planeService.BrowseAsync(brandname);

            return Json(planes);
        }

        [HttpGet("{planeId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid planeId)
        {
            var plane = await _planeService.GetAsync(planeId);
            if (plane == null)
            {
                return NotFound();
            }

            return Json(plane);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePlane command)
        {
            command.PlaneId = Guid.NewGuid();
            await _planeService.CreateAsync(command.PlaneId, command.BrandName, command.FlyingFrom,
                                            command.FlyingTo, command.StartFlight, command.EndFlight);
            await _planeService.AddTicketsAsync(command.PlaneId, command.Tickets, command.Price);

            return Created($"/plane/{command.PlaneId}", null);
        }

        [HttpPut("{planeId}")]
        public async Task<IActionResult> Put(Guid planeId, [FromBody]UpdatePlane command)
        {
            await _planeService.UpdateAsync(planeId, command.BrandName, command.FlyingFrom, command.FlyingTo);

            return NoContent(); //204
        }

        [HttpDelete("{planeId}")]
        public async Task<IActionResult> Delete(Guid planeId)
        {
            await _planeService.DeleteAsync(planeId);

            return NoContent(); //204
        }
    }
}