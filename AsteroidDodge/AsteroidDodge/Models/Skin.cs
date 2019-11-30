using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsteroidDodge.Models
{
    public class ShipSkin
    { 
        public string SkinName { get; set; }

        /// <summary>
        /// Image path for skin (inside wwwrooot folder)
        /// </summary>
        public string SkinImgLocation { get; set; }
        /// <summary>
        /// Cost to purchase skin
        /// </summary>
        public int SkinCost { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShipSkinId { get; set; }

    }
    public class BackgroundSkin
    { 
        public string SkinName { get; set; }

        /// <summary>
        /// Image path for skin (inside wwwrooot folder)
        /// </summary>
        public string SkinImgLocation { get; set; }
        /// <summary>
        /// Cost to purchase skin
        /// </summary>
        public int SkinCost { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BackgroundSkinId { get; set; }
    }

}
