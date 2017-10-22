using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace asp_sandbox.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions

        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API in asp_sandbox\n====================================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [HttpGet]
        [Route("ListArtists")]
        public JsonResult ListArtists()
        {
            return Json(this.allArtists);   
        }

        [HttpGet]
        [Route("artists/name/{artname}")]
        public JsonResult ByName(string artname)
        {
            string name = artname;
            IEnumerable<Artist> artist = allArtists.Where( el => el.ArtistName.ToLower().Contains(name));
            return Json(artist);
        }

        [HttpGet]
        [Route("artists/realname/{realname}")]
        public JsonResult ByRealName(string realname)
        {
            string name = realname;
            IEnumerable<Artist> artist = allArtists.Where(el => el.RealName.ToLower().Contains(name));
            return Json(artist);
        }

        [HttpGet]
        [Route("artists/groupid/{id}")]
        public JsonResult ByGroupId(int id)
        {
            int groupid = id;
            var artist = allArtists.Where(el => el.GroupId == groupid);
            return Json(artist);
        }
    }
}