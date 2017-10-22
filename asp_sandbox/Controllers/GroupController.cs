using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace asp_sandbox.Controllers
{
    
    public class GroupController : Controller 
    {
        private List<Group> AllGroups;

        public GroupController() 
        {
            AllGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet]
        [Route("listgroups/{listall}")]
        public JsonResult ListGroups(bool listall)
        {
            if (listall)
            {
                return Json(this.AllGroups);
            }

            return Json(null); 
        }

        [HttpGet]
        [Route("group/name/{name}")]
        public JsonResult ByName(string name)
        {
            var group = AllGroups.Where(el => el.GroupName.ToLower().Contains(name));
            return Json(group);
        }

        [HttpGet]
        [Route("group/id/{id}")]
        public JsonResult ById(int id)
        {
            var group = AllGroups.Where(el => el.Id == id);
            return Json(group);
        }

    }
}