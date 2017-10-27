using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Example
{
    public class Player
    {
        Guid _id;  // Guid is Global unique indentifier
        string _name;
        int _xp;

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public override string ToString()
        {
            return Id.ToString() + " " + Name.ToString() + " " + Xp.ToString();
        }
    }
    class Program
    {
        static List<Player> players = new List<Player>()
        {
            new Player { Id = Guid.NewGuid(), Name = "Pete Volga", Xp = 100 },
            new Player { Id = Guid.NewGuid(), Name = "Steve Lang", Xp = 90 },
            new Player { Id = Guid.NewGuid(), Name = "Dustin Martin", Xp = 122 },
            new Player { Id = Guid.NewGuid(), Name = "Johnny Henry", Xp = 200 }
        };

        static void Main(string[] args)
        {
            // FirstOrDefault returns the first occurance of the match, or else null
            Console.WriteLine("Find Steve Lang");
            Player found = players.FirstOrDefault(p => p.Name == "Steve Lang");
            if (found != null)
            {
                Console.WriteLine(found.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("First Name containing E");
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("e"));
            if (found1 != null)
            {
                Console.WriteLine(found1.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            Console.ReadKey();
            Console.WriteLine();

            // Return all players with an XP value over 100
            Console.WriteLine("Players over XP of 100");
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();

            if (topPlayers.Count > 0)
            {
                foreach (var item in topPlayers)
                {
                    Console.WriteLine(item.ToString());
                } 
            }
            else
            {
                Console.WriteLine("No Match Found");
            }

            Console.ReadKey();
            Console.WriteLine();

            // Ordering by the highest XP first
            Console.WriteLine("Score Board");
            var scoreBoard = players.OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp }); // the new part is an Anonymous Object

            foreach (var item in scoreBoard)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Xp);
            }


            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
