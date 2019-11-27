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
        public uint Coins { get; set; }

        /// <summary>
        /// Last selected ship
        /// </summary>
        [NotMapped]
        public Skin CurrentShip { get; set; }

        /// <summary>
        /// Last selected background
        /// </summary>
        [NotMapped]
        public Skin CurrentBackground { get; set; } 

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
