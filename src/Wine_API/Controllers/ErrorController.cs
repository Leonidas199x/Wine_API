using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WineAPI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var validationResult = new ValidationResult("Sorry, something went wrong.");

            return StatusCode(500, validationResult);
        }
    }
}
