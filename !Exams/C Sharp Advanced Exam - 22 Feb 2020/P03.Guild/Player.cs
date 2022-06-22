using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private string name;
        private string _class;
        private string rank;
        private string description;

        public string Name { get => name; set => name = value; }

        public string Class { get => _class; set => _class = value; }

        public string Rank { get => rank; set => rank = value; }

        public string Description { get => description; set => description = value; }

        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.Append($"Description: {Description}");

            return sb.ToString();
        }
    }
}
