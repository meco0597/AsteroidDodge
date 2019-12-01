using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Models
{
    /// <summary>
    /// Custom user class
    /// </summary>
    public class AsteroidUser : IdentityUser
    {
        /// <summary>
        /// Amount of coins owned by this player
        /// </summary>
        public int Coins { get; set; }


        public int CurrentShipId { get; set; }

        /// <summary>
        /// Last selected ship
        /// </summary>
        [NotMapped]
        [ForeignKey("CurrentShipId")]
        public ShipSkin CurrentShip { get; set; }

        public int CurrentBackgrounId { get; set; }

        /// <summary>
        /// Last selected background
        /// </summary>
        [NotMapped]
        [ForeignKey("CurrentBackgroundId")]
        public BackgroundSkin CurrentBackground { get; set; }

        /// <summary>
        /// List of all ships owned by the player
        /// </summary>
        public ICollection<OwnedShip> OwnedShips { get; set; }
        /// <summary>
        /// List of all backgrounds owned by the player 
        /// </summary>
        public ICollection<OwnedBackground> OwnedBackgrounds { get; set; }
    }
}
