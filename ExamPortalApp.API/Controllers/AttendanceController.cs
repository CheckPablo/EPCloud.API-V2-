using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ExamPortalApp.Api.Controllers
{
    public class AttendanceController : ControllerBase
    {
        /*public async Task <IActionResult> Index()
        {
            return Ok();
        }

        public async Task<IActionResult> Change(int StudentID, int TestID)
        {
            return Ok();
        }

        public async Task<IActionResult> English(int StudentID, int TestID, string Decs)
        {
            return Ok(); ;
        }

        public async Task<ActionResult> Absent(int StudentID, int TestID)
        {
            return Ok();
        }

        public async Task<ActionResult> Present(int StudentID, int TestID)
        {
            return Ok();
        }

        public async Task<ActionResult> ResetTest(int StudentID, int TestID)
        {
            return Ok();
        }

        public async Task<ActionResult> ChangeLanguage()
        {
            return Ok(); 
        }
    

       

        private static void DelayResponse()
        {
            System.Threading.Thread.Sleep(100);
        }

        public async Task<ActionResult> _AsyncSector(int? CenterID)
        {
            DelayResponse();
            //List<SelectListItem> Result = DDRep.GetSectorList(((int)CenterID));
            return Ok();
        }

        public async Task<ActionResult> _AsyncSubject(int? SectorID)
        {
            return Ok();
        }

        public async Task<ActionResult> _AsyncTest(int? SubjectID)
        {
            //DelayResponse();
            //List<SelectListItem> Result = DDRep.GetTestList(((int)SubjectID));
            return Ok();
        }
     
        // GET: /ATest/
       
        public async Task<ActionResult> _ListAttendance(string CenterID = "", string SectorID = "", string SubjectID = "", string TestID = "")
        {

            return Ok();
        }

        //INSERT/UPDATE: Records 
        [HttpPost]
      
        public async Task<ActionResult> _InsertAttendance(string TestInfoID, string languageid, string studentid, bool abs, bool res, string testid)
        {
            return Ok(); 
        }
        //
        // GET: /AttendanceRegister/

        [Authorize(Roles = "admin, invigilator")]
        public ActionResult AttendanceRegister(string TestID = "")
        {
            return Ok(); 
        }



        public void ExportExcel(string CenterID, string SectorID, string SubjectID, string TestID)
        {
      
        }


        public async Task<ActionResult> _AttendenceListExport2(string CenterID, string SectorID, string SubjectID, string TestID)

        {
            return Ok(); 
        }

        public async Task<ActionResult> _AttendenceListExport(string CenterID, string SectorID, string SubjectID, string TestID)
        {

            return Ok();
        }

        private void ExporttoExcel(DataTable table)
        {
            
        }

        public async Task<ActionResult> GetCenter()
        {
            return Ok();
        }

        public async Task<ActionResult> GetSectors()
        {
            return Ok(); ;
        }

        public async Task<ActionResult> GetSubjectList(int SectorID)
        {
            return Ok();
        }

        //public JsonResult GetTestList(int SubjectID)
        //{
        //    DropDownRepository objAdmin = new DropDownRepository();
        //    return Json(objAdmin.GetCenterTestList(SubjectID), JsonRequestBehavior.AllowGet);
        //}
        public async Task<ActionResult> GetTestList(int SubjectID)
        {
            return Ok();
        }

        public async Task<ActionResult> AttendanceRegisterList(string CenterID, string SectorID, string SubjectID, string TestID)
        {
            return Ok();
        }

        public async Task<ActionResult> newResetTest(string TestID, string StudentID)
        {
            return Ok();
        }

        public async Task<ActionResult> newMarkAsAbsent(string TestID, string StudentID)
        {
            return Ok();
        }

        public async Task<ActionResult> newMarkAsPresent(string TestID, string StudentID)
        {
            return Ok();
        }

        public async Task<ActionResult> GetExportPasswordList()
        {
            return Ok();
        }*/
    }
}
