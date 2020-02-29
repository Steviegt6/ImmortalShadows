using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ImmortalShadows.Items.ShadowAmalg
{
    public class SAexpertItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amalgamated Core");
            Tooltip.SetDefault("Minor increases all stats\nIncreases armor penetration by 8");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 8));
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.expert = true;
            item.value = Item.buyPrice(gold: 10);
            item.rare = 11;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 8;
            
            player.lifeRegen += 2;
            player.statDefense += 4;
            player.meleeSpeed += 0.1f;
            player.allDamage += 0.1f;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.pickSpeed -= 0.15f;
            player.minionKB += 0.5f;
        }
    }
}
 