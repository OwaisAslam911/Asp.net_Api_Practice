using Asp.net_Api_Practice.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Api_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly AspApiPracticeContext context;

        public UserApiController(AspApiPracticeContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public JsonResult GetApiData()
        {
            var user = context.UserInfos.ToList();
            return new JsonResult(Ok(user));
        }
        [HttpPost]
        public JsonResult PostApiData(UserInfo newUser)
        {
            
           var newuser =  context.UserInfos.Add(newUser);
            context.SaveChanges();

            return new JsonResult(Ok(newUser));
           
        }
    }
}
