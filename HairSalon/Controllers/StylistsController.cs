namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      return View();
    }
    
  }
}