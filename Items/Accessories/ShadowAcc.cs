using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Accessories
{
    public class ShadowAcc : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Tablet");
            Tooltip.SetDefault("Trades your soul for power"
                +"\n50% increased damage"
                +"\nReduces max life by 300");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 20;
            item.value = Item.sellPrice(gold: 15);
            item.rare = 11;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.50f;
            player.statLifeMax2 -= 300;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 100);
            recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 18);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
