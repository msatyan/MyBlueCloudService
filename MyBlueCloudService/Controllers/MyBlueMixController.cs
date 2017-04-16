using Microsoft.AspNetCore.Mvc;


//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace MyBlueCloudService.Controllers
{
    [Route("/")]
    public class MyBlueMixController : Controller
    {

        [Route("v2/catalog")]
        [HttpGet]
        [Consumes("application/json")]
        public string Get()
        {
            string json = MyCatalog.Catalog;
            return (json);
        }
    }
}
