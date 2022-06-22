using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        private string name;
        private int capacity;

        public List<Player> Roster { get => roster; set => roster = value; }

        public string Name { get => name; set => name = value; }

        public int Capacity { get => capacity; set => capacity = value; }
        public int Count => Roster.Count;

        public Guild(string name, int capacity)
        {
            this.Roster = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Roster.Any(p => p.Name == name))
            {
                Player player = Roster.FirstOrDefault(p => p.Name == name);

                return Roster.Remove(player);
            }
            return false;
        }

        public void PromotePlayer(string name) => Roster.First(p => p.Name == name).Rank = "Member";

        public void DemotePlayer(string name) => Roster.First(p => p.Name == name).Rank = "Trial";

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] arr = Roster.Where(p => p.Class == @class).ToArray();

            Roster.RemoveAll(p => p.Class == @class);

            return arr;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in Roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
