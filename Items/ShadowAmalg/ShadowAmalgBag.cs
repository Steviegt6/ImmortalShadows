using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.ShadowAmalg;
using ImmortalShadows.Items.Armor.Masks;
using ImmortalShadows.NPCs.ShadowAmalg;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.ShadowAmalg
{
    public class ShadowAmalgBag : ModItem
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
            item.rare = 11;
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
                player.QuickSpawnItem(ItemType<ShadowAmalgMask>());
            }
            player.QuickSpawnItem(ItemType<SAexpertItem>());
            player.QuickSpawnItem(ItemType<ShadowChunk>(), 27 + Main.rand.Next(16));
        }

        public override int BossBagNPC => NPCType<NPCs.ShadowAmalg.ShadowAmalg>();
    }
}
