using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ImmortalShadows.Items.ShadowAmalg
{
    public class SEexpertItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Darkness");
            Tooltip.SetDefault("Grants Shadow Dodge");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.expert = true;
            item.value = Item.buyPrice(0, 2, 50, 0);
            item.rare = 4;
            item.accessory = true;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.onHitDodge = true;
        }
    }
}
 