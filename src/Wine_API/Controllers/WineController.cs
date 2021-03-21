using Microsoft.AspNetCore.Mvc;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class WineController : Controller
    {
        [Route("{Id}")]
        [HttpGet]
        public ActionResult GetWine(int wineId)
        {
            return NotFound();
        }
    }
}