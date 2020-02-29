using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace ImmortalShadows.Items
{
    public class VanillaItemChanges : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.EnchantedSword)
            {
                item.useTime = 20;
            }

            if (item.type == ItemID.TerraBlade)
            {
                item.shootSpeed = 13f;
                item.damage = 105;
            }

            if (item.type == ItemID.DD2SquireBetsySword)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.shootSpeed = 13f;
                item.damage = 110;
            }

            if (item.type == ItemID.InfluxWaver)
            {
                item.shootSpeed = 13f;
            }

            if (item.type == ItemID.Meowmere)
            {
                item.useTime = 14;
                item.useAnimation = 14;
            }
        }
    }
}
