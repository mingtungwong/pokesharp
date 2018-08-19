using System;

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
            Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"WT: {Weight} kg\tHT: {Height} m");
            Console.WriteLine($"Type(s): {String.Join(", ", Types)}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"{Description}");
            Console.WriteLine();
            Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~**~*~*~*~*~*~*~*~");
        }
    }
}