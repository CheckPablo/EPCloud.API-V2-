using ExamPortalApp.Contracts.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace ExamPortalApp.Api.Controllers
{
    public class InvigilatorManageController : Controller
    {
        // GET: InvigilatorManage
   //     [Authorize(Roles = "admin")]
   //     public async Task <ActionResult> InvigilatorManage()
   //     {
   //         return Ok(); 
   //     }
   //     public async Task<ActionResult> InvigilatorDetail()
   //     {
   //         return Ok();
   //     }

   //     // GET: InvigilatorManage/Details/5
   //     public async Task<ActionResult> Details(int id)
   //     {
   //         return Ok(); ;
   //     }

   //     // GET: InvigilatorManage/Create
   //     public async Task<ActionResult> Create()
   //     {
   //         return Ok();
   //     }

   //     // POST: InvigilatorManage/Create
   //     [HttpPost]
   //     public async Task<ActionResult> Create(FormCollection collection)
   //     {

   //         return Ok();

   //     }

   //     // GET: InvigilatorManage/Edit/5
   //     public async Task<ActionResult> Edit(int id)
   //     {
   //         return Ok();
   //     }

   //     // POST: InvigilatorManage/Edit/5
   //     [HttpPost]
   //     public async Task<ActionResult> Edit(int id, FormCollection collection)
   //     {
   //         return Ok();
   //     }

   //     // GET: InvigilatorManage/Delete/5
   //     public async Task<ActionResult> Delete(int id)
   //     {
   //         return Ok(); 
   //     }

   //     // POST: InvigilatorManage/Delete/5
   //     [HttpPost]
   //     public async Task<ActionResult> Delete(int id, FormCollection collection)
   //     {
   //         return Ok();
   //     }

   //     public async Task<ActionResult> GetInvigilatorDetails(string approve, string active)
   //     {
   //         //InvigilatorScreenRepo objAdmin = new InvigilatorScreenRepo();

   //         return Ok(); 
   //     }
   //     public async Task<ActionResult> GetInvigilatorDetailById(string UserId, string CenterId)
   //     {
          

   //         return Ok();
   //     }
   //     public async Task<ActionResult> ResetInvigilatorPassword(string UserName, string Password, string Email)
   //     {

   //         return Ok();
   //     }


   //     public async Task<ActionResult> UpdateUserInfo(string UserID, string UserName, string Password, string plain_password, string email)
   //     {

   //         return Ok();
   //     }
   //     public async Task<ActionResult> ApproveUser(int UserID)
   //     {

   //         return Ok();
   //     }
   //     public async Task<ActionResult> ActivateUser(int UserID, string status)
   //     {
   //;
   //         return Ok();
   //     }
   //     public async Task<ActionResult> AdminUser(int UserID, string status)
   //     {

   //         return Ok();
   //     }
   //     public async Task<ActionResult> DisableUser(int UserID)
   //     {

   //         return Ok();
   //     }
    }
}

