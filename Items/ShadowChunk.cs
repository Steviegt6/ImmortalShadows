using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items
{
    public class ShadowChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Shadow Chunk");
            Tooltip.SetDefault("What the heck is this?"
			    + "\nDrops from the Moon Lord");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.sellPrice(silver: 40);
            item.rare = 10;
        }
    }
}