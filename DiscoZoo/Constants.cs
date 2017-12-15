using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace DiscoZoo_Prediction
{
    /// <summary>
    /// Store many useful constants
    /// </summary>
    public static class Constants
    {
        #region Strings

        public const string VERSION = "1.1";
        public const string WINDOW_TITLE = "DiscoZoo Prediction - v" + VERSION;

        #endregion

        #region Numeric

        public const int SQ_SIZE = 60;
        public const int SQ_MARGIN = 10;
        public const int SQ_THICKNESS = 1;
        public const int SQ_FONT = 10;

        #endregion


        #region Colors

        public static Color ColorRed { get; } = (Color)ColorConverter.ConvertFromString("#F44336");
        public static Color ColorOrange { get; } = (Color)ColorConverter.ConvertFromString("#FFC107");
        public static Color ColorGreen { get; } = (Color)ColorConverter.ConvertFromString("#4CAF50");
        public static Color ColorBlank { get; } = (Color)ColorConverter.ConvertFromString("#9E9E9E");
        public static Color ColorAnimal1 { get; } = (Color)ColorConverter.ConvertFromString("#B2FF59");
        public static Color ColorAnimal2 { get; } = (Color)ColorConverter.ConvertFromString("#18FFFF");
        public static Color ColorAnimal3 { get; } = (Color)ColorConverter.ConvertFromString("#FF4081");

        #endregion

        /// <summary>
        /// The total list of all animals
        /// </summary>
        public static List<Animal> All { get; } = new List<Animal>
        {
            new Animal()
            {
                Name = "Sheep",
                Biome = Biome.Farm,
                Pattern = Utils.StringToMap("1111")
            },
            new Animal()
            {
                Name = "Pig",
                Biome = Biome.Farm,
                Pattern = Utils.StringToMap("11;11")
            },
            new Animal()
            {
                Name = "Rabbit",
                Biome = Biome.Farm,
                Pattern = Utils.StringToMap("1;1;1;1")
            },
            new Animal()
            {
                Name = "Horse",
                Biome = Biome.Farm,
                Pattern = Utils.StringToMap("1;1;1")
            },
            new Animal()
            {
                Name = "Cow",
                Biome = Biome.Farm,
                Pattern = Utils.StringToMap("111")
            },
            new Animal()
            {
                Name = "Unicorn",
                Biome = Biome.Farm,
                Pattern = Utils.StringToMap("100;011")
            },
            new Animal()
            {
                Name = "Kangaroo",
                Biome = Biome.Outback,
                Pattern = Utils.StringToMap("1000;0100;0010;0001")
            },
            new Animal()
            {
                Name = "Platypus",
                Biome = Biome.Outback,
                Pattern = Utils.StringToMap("110;011")
            },
            new Animal()
            {
                Name = "Crocodile",
                Biome = Biome.Outback,
                Pattern = Utils.StringToMap("1111")
            },
            new Animal()
            {
                Name = "Koala",
                Biome = Biome.Outback,
                Pattern = Utils.StringToMap("11;01")
            },
            new Animal()
            {
                Name = "Cockatoo",
                Biome = Biome.Outback,
                Pattern = Utils.StringToMap("10;01;01")
            },
            new Animal()
            {
                Name = "Tiddalik",
                Biome = Biome.Outback,
                Pattern = Utils.StringToMap("010;101")
            },
            new Animal()
            {
                Name = "Zebra",
                Biome = Biome.Savanna,
                Pattern = Utils.StringToMap("010;101;010")
            },
            new Animal()
            {
                Name = "Hippo",
                Biome = Biome.Savanna,
                Pattern = Utils.StringToMap("101;000;101")
            },
            new Animal()
            {
                Name = "Giraffe",
                Biome = Biome.Savanna,
                Pattern = Utils.StringToMap("1;1;1;1")
            },
            new Animal()
            {
                Name = "Lion",
                Biome = Biome.Savanna,
                Pattern = Utils.StringToMap("111")
            },
            new Animal()
            {
                Name = "Elephant",
                Biome = Biome.Savanna,
                Pattern = Utils.StringToMap("11;10")
            },
            new Animal()
            {
                Name = "Gryphon",
                Biome = Biome.Savanna,
                Pattern = Utils.StringToMap("101;010")
            },
            new Animal()
            {
                Name = "Bear",
                Biome = Biome.Northern,
                Pattern = Utils.StringToMap("11;01;01")
            },
            new Animal()
            {
                Name = "Skunk",
                Biome = Biome.Northern,
                Pattern = Utils.StringToMap("011;110")
            },
            new Animal()
            {
                Name = "Beaver",
                Biome = Biome.Northern,
                Pattern = Utils.StringToMap("001;110;001")
            },
            new Animal()
            {
                Name = "Moose",
                Biome = Biome.Northern,
                Pattern = Utils.StringToMap("101;010")
            },
            new Animal()
            {
                Name = "Fox",
                Biome = Biome.Northern,
                Pattern = Utils.StringToMap("110;001")
            },
            new Animal()
            {
                Name = "Sasquatch",
                Biome = Biome.Northern,
                Pattern = Utils.StringToMap("1;1")
            },
            new Animal()
            {
                Name = "Penguin",
                Biome = Biome.Polar,
                Pattern = Utils.StringToMap("010;010;101")
            },
            new Animal()
            {
                Name = "Seal",
                Biome = Biome.Polar,
                Pattern = Utils.StringToMap("1000;0101;0010")
            },
            new Animal()
            {
                Name = "Muskox",
                Biome = Biome.Polar,
                Pattern = Utils.StringToMap("110;101")
            },
            new Animal()
            {
                Name = "Polar Bear",
                Biome = Biome.Polar,
                Pattern = Utils.StringToMap("101;001")
            },
            new Animal()
            {
                Name = "Walrus",
                Biome = Biome.Polar,
                Pattern = Utils.StringToMap("100;011")
            },
            new Animal()
            {
                Name = "Yeti",
                Biome = Biome.Polar,
                Pattern = Utils.StringToMap("1;0;1")
            },
            new Animal()
            {
                Name = "Monkey",
                Biome = Biome.Jungle,
                Pattern = Utils.StringToMap("1010;0101")
            },
            new Animal()
            {
                Name = "Toucan",
                Biome = Biome.Jungle,
                Pattern = Utils.StringToMap("01;10;01;01")
            },
            new Animal()
            {
                Name = "Gorilla",
                Biome = Biome.Jungle,
                Pattern = Utils.StringToMap("101;101")
            },
            new Animal()
            {
                Name = "Panda",
                Biome = Biome.Jungle,
                Pattern = Utils.StringToMap("001;100;001")
            },
            new Animal()
            {
                Name = "Tiger",
                Biome = Biome.Jungle,
                Pattern = Utils.StringToMap("1011")
            },
            new Animal()
            {
                Name = "Phoenix",
                Biome = Biome.Jungle,
                Pattern = Utils.StringToMap("100;000;001")
            },
            new Animal()
            {
                Name = "Diplodocus",
                Biome = Biome.Jurassic,
                Pattern = Utils.StringToMap("100;011;010")
            },
            new Animal()
            {
                Name = "Stegosaurus",
                Biome = Biome.Jurassic,
                Pattern = Utils.StringToMap("0110;1001")
            },
            new Animal()
            {
                Name = "Raptor",
                Biome = Biome.Jurassic,
                Pattern = Utils.StringToMap("110;010;001")
            },
            new Animal()
            {
                Name = "T-Rex",
                Biome = Biome.Jurassic,
                Pattern = Utils.StringToMap("10;00;11")
            },
            new Animal()
            {
                Name = "Triceratops",
                Biome = Biome.Jurassic,
                Pattern = Utils.StringToMap("100;001;100")
            },
            new Animal()
            {
                Name = "Dragon",
                Biome = Biome.Jurassic,
                Pattern = Utils.StringToMap("100;001")
            },
            new Animal()
            {
                Name = "Wooly Rhino",
                Biome = Biome.Ice_Age,
                Pattern = Utils.StringToMap("0010;1001;0100")
            },
            new Animal()
            {
                Name = "Giant Sloth",
                Biome = Biome.Ice_Age,
                Pattern = Utils.StringToMap("100;001;101")
            },
            new Animal()
            {
                Name = "Dire Wolf",
                Biome = Biome.Ice_Age,
                Pattern = Utils.StringToMap("0100;1001;0100")
            },
            new Animal()
            {
                Name = "Saber Tooth",
                Biome = Biome.Ice_Age,
                Pattern = Utils.StringToMap("100;001;010")
            },
            new Animal()
            {
                Name = "Mammoth",
                Biome = Biome.Ice_Age,
                Pattern = Utils.StringToMap("010;100;001")
            },
            new Animal()
            {
                Name = "Akhlut",
                Biome = Biome.Ice_Age,
                Pattern = Utils.StringToMap("001;100;001")
            },
            new Animal()
            {
                Name = "Raccoon",
                Biome = Biome.City,
                Pattern = Utils.StringToMap("1010;1001")
            },
            new Animal()
            {
                Name = "Pigeon",
                Biome = Biome.City,
                Pattern = Utils.StringToMap("100;010;011")
            },
            new Animal()
            {
                Name = "Rat",
                Biome = Biome.City,
                Pattern = Utils.StringToMap("1100;0101")
            },
            new Animal()
            {
                Name = "Squirrel",
                Biome = Biome.City,
                Pattern = Utils.StringToMap("001;100;010")
            },
            new Animal()
            {
                Name = "Opossum",
                Biome = Biome.City,
                Pattern = Utils.StringToMap("100;101")
            },
            new Animal()
            {
                Name = "Sewer Turtle",
                Biome = Biome.City,
                Pattern = Utils.StringToMap("11")
            },
            new Animal()
            {
                Name = "Goat",
                Biome = Biome.Mountain,
                Pattern = Utils.StringToMap("100;111")
            },
            new Animal()
            {
                Name = "Cougar",
                Biome = Biome.Mountain,
                Pattern = Utils.StringToMap("100;010;101")
            },
            new Animal()
            {
                Name = "Elk",
                Biome = Biome.Mountain,
                Pattern = Utils.StringToMap("101;011")
            },
            new Animal()
            {
                Name = "Eagle",
                Biome = Biome.Mountain,
                Pattern = Utils.StringToMap("10;10;01")
            },
            new Animal()
            {
                Name = "Coyote",
                Biome = Biome.Mountain,
                Pattern = Utils.StringToMap("110;001")
            },
            new Animal()
            {
                Name = "Aatxe",
                Biome = Biome.Mountain,
                Pattern = Utils.StringToMap("001;100")
            },
            new Animal()
            {
                Name = "Moonkey",
                Biome = Biome.Moon,
                Pattern = Utils.StringToMap("100;101;001")
            },
            new Animal()
            {
                Name = "Lunar Tick",
                Biome = Biome.Moon,
                Pattern = Utils.StringToMap("010;000;010;101")
            },
            new Animal()
            {
                Name = "Tribble",
                Biome = Biome.Moon,
                Pattern = Utils.StringToMap("010;111")
            },
            new Animal()
            {
                Name = "Moonicorn",
                Biome = Biome.Moon,
                Pattern = Utils.StringToMap("10;11")
            },
            new Animal()
            {
                Name = "Luna Moth",
                Biome = Biome.Moon,
                Pattern = Utils.StringToMap("101;000;010")
            },
            new Animal()
            {
                Name = "Jade Rabbit",
                Biome = Biome.Moon,
                Pattern = Utils.StringToMap("10;00;01")
            },
            new Animal()
            {
                Name = "Rock",
                Biome = Biome.Mars,
                Pattern = Utils.StringToMap("11;11")
            },
            new Animal()
            {
                Name = "Marsmot",
                Biome = Biome.Mars,
                Pattern = Utils.StringToMap("01;01;11")
            },
            new Animal()
            {
                Name = "Marsmoset",
                Biome = Biome.Mars,
                Pattern = Utils.StringToMap("101;001;010")
            },
            new Animal()
            {
                Name = "Rover",
                Biome = Biome.Mars,
                Pattern = Utils.StringToMap("010;101")
            },
            new Animal()
            {
                Name = "Martian",
                Biome = Biome.Mars,
                Pattern = Utils.StringToMap("101;010")
            },
            new Animal()
            {
                Name = "Marsmallow",
                Biome = Biome.Mars,
                Pattern = Utils.StringToMap("1;0;1")
            },
        };
    }
}
