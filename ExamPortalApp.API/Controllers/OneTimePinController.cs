using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamPortalApp.Api.Controllers
{
    public class OneTimePinController : ControllerBase
    {
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
        //public async Task<ActionResult> Index()
        //{
        //    //ViewData["CenterID"] = DDRep.GetCenter();
        //    return View();
        //}
 //       [Authorize(Roles = "invigilator,admin")]
 //       public async Task<ActionResult> OneTimePin()
 //       {
 //           return Ok();
 //       }

 //       public async Task<ActionResult> _ListOtpTest(string CenterID = "", string SectorID = "", string SubjectID = "", string TestID = "")
 //       {

 //           return Ok();
 //       }

 //       public async Task<ActionResult> CreateOneTimePine(int TestId, int SubjectId, int SectorId, int OneTimePin, int CenterId)
 //       {
 //;
 //           return Ok();
 //       }
 //       #region Ajax

 //       /*private async static void DelayResponse()
 //       {
 //           System.Threading.Thread.Sleep(100);
 //       }*/

 //       public async Task<ActionResult> _AsyncSector(int? CenterID)
 //       {
 //           return Ok();
       
 //       }

 //       public async Task<ActionResult> _AsyncSubject(int? SectorID)
 //       {
 //           //List<SelectListItem> Result = DDRep.GetSubjectList(((int)SectorID));
 //           return Ok();
 //       }

 //       public ActionResult _AsyncTest(int? SubjectID)
 //       {

 //           //List<SelectListItem> Result = DDRep.GetTestList(((int)SubjectID));
 //           return Ok();
 //       }
 //       #endregion

 //       public async Task<ActionResult> NewOTPlist(string CenterID, string SectorID, string SubjectID, string TestID)
 //       {
 //           //TestOTPRepository objAdmin = new TestOTPRepository();
 //           return Ok();

 //       }

 //       public async Task<ActionResult> NewOTPinsert(string Code, string TestID, string CenterID, string SectorID, string SubjectID)
 //       {
 //           //TestOTPRepository objAdmin = new TestOTPRepository();
 //           return Ok(); ;
 //       }
 //       public async Task<ActionResult> NewOTPEmailList(string TestID)
 //       {
 //           //TestOTPRepository objAdmin = new TestOTPRepository();
 //           return Ok();
 //       }
 //       public async Task<ActionResult> SendEmail(string EmailAddress, string TestName, string otp)
 //       {
 //           return Ok();
 //       }
    }
}
