using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist query = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine(query.Age);
            Console.WriteLine(query.ArtistName);

            //Who is the youngest artist in our collection of artists?
            IEnumerable<Artist> query2 = Artists.OrderBy(el => el.Age);
            Console.WriteLine(query2.First().Age + " " + query2.First().ArtistName);

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> query3 = Artists.Where(el => el.RealName.Contains("William"));
            for (int i = 0; i < query3.Count(); i++){
                Console.WriteLine(query3.ToList()[i].RealName);
            }

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> query4 = Artists.OrderByDescending(el => el.Age).Where(el => el.Hometown.ToLower() == "atlanta");
            for (int i = 0; i < query4.Count(); i++)
            {
                Console.WriteLine(query4.ToList()[i].RealName + " is from " + query4.ToList()[i].Hometown);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            var query5 = Artists.Join(Groups, art => art.GroupId, group => group.Id, (art, group) => new { 
                    art = art.Hometown,
                    group = group.GroupName
            }).Where(el => el.art.ToLower() != "new york city").Distinct();
            foreach (var el in query5) {
                Console.WriteLine(el.art + " " + el.group);  
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var query6 = Groups.Where(el => el.GroupName == "Wu-Tang Clan").Single();
            Console.WriteLine(query6.Members.Count());
            foreach (var el in query6.Members) {
                Console.WriteLine(el.GroupId);
            }

            var query7 = Artists.Join(Groups, art => art.GroupId, group => group.Id, (art, group) => new {
                    art = art.ArtistName,
                    group = group.GroupName,
            }).Where(el => el.group == "Wu-Tang Clan");
            foreach (var el in query7) {
                Console.WriteLine(el.art);
            }
        }
    }
}