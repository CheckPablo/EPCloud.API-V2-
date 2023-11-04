using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ExamPortalApp.Api.Controllers
{
    /**/public class QuestionsController : ControllerBase
    {
        /*public IActionResult Index()
        {
            return Ok();
        }
        

        public async Task<ActionResult> Question(int StudentID, int TestID)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> _InserttQuestion(int StudentID, int TestID, string Decs)
        {

            return Ok();
        }

        public async Task<ActionResult> _UpdatetQuestion(int StudentID, int TestID)
        {

            return Ok();
        }

        public async Task<ActionResult> _DeteletQuestion(int StudentID, int TestID)
        {
            return Ok();
        }

        public async Task <ActionResult> ChangeLanguage()
        {
            return Ok();
        }
    

        
        private static void DelayResponse()
        {
            System.Threading.Thread.Sleep(100);
        }

        public async Task<ActionResult> _AsyncSector(int? CenterID)
        {
            //List<SelectListItem> Result = DDRep.GetSectorList(((int)CenterID));
            return Ok();
        }

        public async Task<ActionResult> _AsyncSubject(int? SectorID)
        {
            //List<SelectListItem> Result = DDRep.GetSubjectList(((int)SectorID));
            return Ok();
         
        }

        public async Task<ActionResult> _AsyncTest(int? SubjectID)
        {
         
            return Ok();
        }
 
        public async Task<ActionResult> _ListAttendance(string CenterID = "", string SectorID = "", string SubjectID = "", string TestID = "")
        {

            return Ok(); 
        }

      
        public async Task<ActionResult> _InsertAttendance(string TestInfoID, string languageid, string studentid, bool abs, bool res, string testid)
        {
            return Ok();
        }
   

        [Authorize(Roles = "admin, invigilator")]
        public async Task<ActionResult> AttendanceRegister(string TestID = "")
        {         
                return Ok();

        }
        //  public void async Task<ActionResult>(string CenterID, string SectorID, string SubjectID, string TestID)
        // {
        // return Ok();
        //}
        public async Task<ActionResult> _AttendenceListExport2(string CenterID, string SectorID, string SubjectID, string TestID)
        {
          return Ok();
        }

        public async Task<ActionResult> _AttendenceListExport(string CenterID, string SectorID, string SubjectID, string TestID)
        {
            return Ok();
        }

        //private  async void Task<ActionResult>   ExporttoExcel(DataTable table)
        //{
        //    return Ok(); 
        //}

        public async  Task<ActionResult> GetCenter()
        {
           return Ok();
        }

        public async Task<ActionResult> GetSectors()
        {
             return Ok(); 
        }

        public async Task<ActionResult> GetSubjectList(int SectorID)
        {
            return Ok(); 
        }

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

        public async  Task<ActionResult> newMarkAsAbsent(string TestID, string StudentID)
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

