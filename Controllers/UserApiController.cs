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
        [HttpGet("{id}")]
        public JsonResult getuser(int id)
        {
            var userData = context.UserInfos.FirstOrDefault(Options => Options.UserId == id);
            return new JsonResult (Ok(userData));

        }
        [HttpDelete("{id}")]
        public JsonResult DeleteApiData(int id)
        {
            var userdata = context.UserInfos.Find(id);
            context.UserInfos.Remove(userdata);
            context.SaveChanges();
            return new JsonResult(Ok(userdata));
        }
        //[HttpGet("{id}")]
        //public JsonResult getupdate (int id)
        //{
        //    var userData = context.UserInfos.FirstOrDefault(option => option.UserId == id);
        //    return new JsonResult(Ok(userData));

        //}
        [HttpPut("{id}")]
        public JsonResult UpdateUser(UserInfo newUser ,int id)
        {
            var userdata = context.UserInfos.FirstOrDefault(option => option.UserId == id);
            userdata.UserId = newUser.UserId;
            userdata.UserName = newUser.UserName;
            userdata.Email = newUser.Email;
            userdata.Phone = newUser.Phone;

            context.UserInfos.Update(newUser);
            context.SaveChanges();
            return new JsonResult(Ok(userdata));
        }
    }
}
