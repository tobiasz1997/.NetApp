using System.Threading.Tasks;
using Airplane.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airplane.Api.Controllers
{
    [Route("plane")]
    public class PlaneController : Controller
    {
        private readonly IPlaneService _planeService;

        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string brandname)
        {
            var planes = await _planeService.BrowseAsync(brandname);

            return Json(planes);
        }
    }
}