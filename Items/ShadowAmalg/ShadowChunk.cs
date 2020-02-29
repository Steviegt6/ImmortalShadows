using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ImmortalShadows.Items.ShadowAmalg
{
    public class ShadowChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Shadow Chunk");
            Tooltip.SetDefault("What the heck is this?");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.sellPrice(silver: 50);
            item.rare = 10;
        }
    }
}