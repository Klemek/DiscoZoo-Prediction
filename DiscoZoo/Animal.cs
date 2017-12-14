using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoZoo_Prediction
{
    /// <summary>
    /// The data of an animal found in DiscoZoo
    /// </summary>
    public class Animal
    {
        #region Properties

        /// <summary>
        /// The biome where the animal can be found
        /// </summary>
        public Biome Biome { get; set; }

        /// <summary>
        /// A boolean map representing the pattern of the animal
        /// </summary>
        public bool[][] Pattern { get; set; }

        /// <summary>
        /// The animal's name
        /// </summary>
        public String Name { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// A biome found in DiscoZoo
    /// </summary>
    public enum Biome
    {
        Farm,
        Outback,
        Savanna,
        Northern,
        Polar,
        Jungle,
        Jurassic,
        Ice_Age,
        City,
        Mountain,
        Moon,
        Mars
    }
}
