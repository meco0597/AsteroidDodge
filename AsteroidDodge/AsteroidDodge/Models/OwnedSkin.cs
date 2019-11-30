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
        [Key]
        public int OwnedShipId { get; set; }


        public string AsteroidUserId { get; set; }

        [ForeignKey("AsteroidUserId")]
        public AsteroidUser AsteroidUser { get; set; }

        public int ShipSkinId { get; set; }

        [ForeignKey("ShipSkinId")]
        public ShipSkin ShipSkin { get; set; }
    }
    public class OwnedBackground
    {
        [Key]
        public int OwnedBackgroundId { get; set; }


        public string AsteroidUserId { get; set; }

        [ForeignKey("AsteroidUserId")]
        public AsteroidUser AsteroidUser { get; set; }

        public int BackgroundSkinId { get; set; }

        [ForeignKey("BackgroundSkinId")]
        public BackgroundSkin BackgroundSkin { get; set; }
    }
}
