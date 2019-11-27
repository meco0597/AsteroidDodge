using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Models
{
    /// <summary>
    /// Represents a skin
    /// </summary>
    public class Skin
    {

        public string SkinName { get; set; }

        /// <summary>
        /// Image path for skin (inside wwwrooot folder)
        /// </summary>
        public string SkinImgLocation { get; set; }
        /// <summary>
        /// Cost to purchase skin
        /// </summary>
        public uint SkinCost { get; set; }
    }
    public class ShipSkin : Skin
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShipSkinId { get; set; }
        public ICollection<OwnedShip> OwnedShips { get; set; }
    }
    public class BackgroundSkin : Skin
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BackgroundSkinId { get; set; }
        public ICollection<OwnedBackground> OwnedBackgrounds { get; set; }
    }

}
