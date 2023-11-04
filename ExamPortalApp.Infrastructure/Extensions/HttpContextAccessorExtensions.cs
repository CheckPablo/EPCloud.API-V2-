using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Entities;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpContextAccessorExtensions
    {
        public static DecodedUser? GetLoggedInUser(this IHttpContextAccessor accessor)
        {
            if (accessor != null)
            {
                var identity = accessor?.HttpContext?.User?.Identity as ClaimsIdentity;

                if (identity == null) return null;

                IList<Claim> claim = identity.Claims.ToList();

                if (claim == null || claim.Count == 0) return null;

                var result = new DecodedUser
                {
                    Id = int.Parse(claim[0].Value),
                    Username = claim[1].Value,
                    RoleId = int.Parse(claim[2].Value),
                    FullName = claim[3].Value,
                    CenterId = int.Parse(claim[4].Value)
                };

                return result;
            }
            else
            {
                return null;
            }
        }

        public static bool LoggedOutUser(this IHttpContextAccessor accessor, int centerId, int role = 2)
        {

           
            if (accessor != null)
            {  
                var identity = accessor?.HttpContext?.User?.Identity as ClaimsIdentity;
                //identity.Claims;

                // Find the claim you want to update
                //identity.Claims.
                var claimToUpdate = identity.Claims.FirstOrDefault(c => c.Type == "CenterId");
                identity.RemoveClaim(claimToUpdate); 
                if (claimToUpdate != null)
                {
                    // Remove the old claim
                    var newClaim = new Claim("CenterId", centerId.ToString());

                    // Add the new claim to the user
                  identity.AddClaim(newClaim);
                   
                }
                //accessor.HttpContext.Session.Clear();

                ////identity.Claims.
                //IList<Claim> claims = identity.Claims.ToList();
                //foreach(var claim in claims)
                //{
                //    identity.RemoveClaim(claim);
                //}       

                ////claim.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
