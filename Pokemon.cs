using System;
using System.Text;

namespace pokesharp {
    class Pokemon {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string[] Types { get; set; }
        public string Description { get; set; }

        public Pokemon(string name, decimal weight, decimal height, string[] types, string description) {
            Name = name;
            Weight = weight;
            Height = height;
            Types = types;
            Description = description;
        }

        public void printPokedexEntry() {
            Console.WriteLine("\n~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~\n");
            Console.WriteLine(this);
            Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~**~*~*~*~*~*~*~*~\n");
        }

        public override string ToString() {
            var builder = new StringBuilder();
            builder.AppendFormat("{0}\n", Name);
            builder.AppendFormat("WT: {0} kg\tHT: {1} m\n", Weight, Height);
            builder.AppendFormat("Type(s): {0}\n", String.Join(", ", Types));
            builder.Append("--------------------------------------------\n");
            builder.AppendFormat("{0}\n", Description);

            return builder.ToString();
        }
    }
}