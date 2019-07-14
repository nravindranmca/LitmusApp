using DataAccess;
using System.Web.Mvc;

namespace Litmus.Controllers
{
    public class HomeController : Controller
    {
        LitmusRepository litmusRepository = new LitmusRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection loginForm)
        {
            //string code = loginForm["txtCode"];
            //string password = loginForm["txtPassword"];

            string code = "101";
            string password = "test123";

            MasterUser masterUser = litmusRepository.ValidateUser(code, password);

            if (masterUser == null)
            {
                ViewBag.ErrorMsg = "Invalid credentials, please try again";
                return View("Index");
            }
            else
            {
                Session["UserCode"] = masterUser.Code;
                Session["UnitCode"] = masterUser.UnitCode;
                Session["name"] = masterUser.FirstName;
                Session["UnitName"] = masterUser.FirstName;

                return RedirectToAction("Index", "Unit");
            }
        }
    }
}