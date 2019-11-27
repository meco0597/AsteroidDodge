using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Models
{
    /// <summary>
    /// Skin owned by a player
    /// </summary>
    public class OwnedShip 
    {
        public int OwnedShipId { get; set; }

        public virtual AsteroidUser AsteroidUser { get; set; }
        public virtual ShipSkin ShipSkin { get; set; }
    }
    public class OwnedBackground
    {
        public int OwnedBackgroundId { get; set; }

        public virtual AsteroidUser AsteroidUser { get; set; }
        public virtual BackgroundSkin BackgroundSkin { get; set; }
    }
}
