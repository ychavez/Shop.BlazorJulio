using Microsoft.AspNetCore.Mvc;


namespace Shop.Blazor.Controllers
{
    public class AuthentecateController : Controller
    {
        [Route("/TestController")]
        public async Task<ActionResult> TestController([FromQuery] string saludo) 
        {
            return Redirect("/Login");
        }
    }
}
