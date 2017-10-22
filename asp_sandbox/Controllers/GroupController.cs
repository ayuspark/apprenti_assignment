using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;
using System.Diagnostics.Contracts;

namespace asp_sandbox.Controllers
{
    
    public class GroupController : Controller 
    {
        private List<Group> AllGroups;
        private List<Artist> AllArtists;

        public GroupController() 
        {
            AllGroups = JsonToFile<Group>.ReadJson();
            AllArtists = JsonToFile<Artist>.ReadJson();
        }

        [HttpGet]
        [Route("listgroups")]
        public JsonResult ListGroups()
        {
            return Json(this.AllGroups);
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
        [Route("group/id/{id}/{display_artist}")]
        public JsonResult ById(int id, bool display_artist)
        {
            Contract.Ensures(Contract.Result<JsonResult>() != null);
            var group = AllGroups.Where(el => el.Id == id);
            if (display_artist)
            {
                group = group.GroupJoin(AllArtists, el_group => el_group.Id, el_art => el_art.GroupId,
                                   (el_group, el_art) =>
                                        {
                                            el_group.Members = el_art.ToList();
                                            return el_group;
                                        }
                                  );
            }
            return Json(group);
        }
    }
}