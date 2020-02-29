using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.ShadowAmalg;
using ImmortalShadows.Items.Armor.Masks;
using ImmortalShadows.NPCs.ShadowAmalg;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.ShadowAmalg
{
    public class ShadowEyeBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 5;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor();
            if (Main.rand.NextBool(7))
            {
                player.QuickSpawnItem(ItemType<ShadowEyeMask>());
            }
            player.QuickSpawnItem(ItemType<SEexpertItem>());
            player.QuickSpawnItem(ItemID.SoulofNight, 21 + Main.rand.Next(15));
        }

        public override int BossBagNPC => NPCType<NPCs.ShadowAmalg.ShadowEye>();
    }
}
