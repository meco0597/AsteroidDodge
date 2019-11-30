using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Models.Store
{
    public class StoreModel
    {
        public class StoreShip
        { 
            public ShipSkin ShipSkin { get; set; }

            public bool IsPurchased { get; set; }
        }
        public class StoreBackground
        { 
            public BackgroundSkin BackgroundSkin { get; set; }

            public bool IsPurchased { get; set; }
        }

        public AsteroidUser User { get; set; }

        public List<StoreShip> StoreShips { get; set; }

        public List<StoreBackground> StoreBackgrounds { get; set; }
    }


}
