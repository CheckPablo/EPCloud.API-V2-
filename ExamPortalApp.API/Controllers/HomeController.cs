using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamPortalApp.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        /*public async Task <IActionResult> Index()
        {
            return Ok();
        }
        public async Task<ActionResult> About()
        {
            return Ok();
        }

        public async Task<ActionResult> Contact()
        {
            return Ok();
        }

        public ActionResult Services()
        {
            return Ok();
        }

        [Authorize(Roles = "admin, student, invigilator")]
        
        public async Task<ActionResult> Home()
        {
            /*AccountFunctions ac = new AccountFunctions();

            string[] role = Roles.GetRolesForUser(ac.GetUserLoggedIn());

            if (role[0] != null)
            {
                if (role[0].Equals("admin"))
                {
                    return RedirectToAction("AttendanceRegister", "AttendanceRegister");
                }
                else
                    if (role[0].Equals("student"))
                {
                    return RedirectToAction("ABetterTest", "ATest");
                }
                else if (role[0].Equals("invigilator"))
                {
                    return RedirectToAction("AttendanceRegister", "AttendanceRegister");
                }
                else { return RedirectToAction("index"); }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }*/

           /* return Ok(); 

        }

        [Authorize(Roles = "admin, student, invigilator")]
        
        public async Task<ActionResult> Homepage()
        {
            return Ok();
        }*/

    }
}
