using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ImmortalShadows.Items.BoulderBoss
{
    public class BoulderMaterial : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boulder Essence");
            Tooltip.SetDefault("The essence of boulders"
                + "\nDrops from sentient boulders");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 8));
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.value = Item.sellPrice(silver: 2);
            item.rare = 1;
        }
    }
}