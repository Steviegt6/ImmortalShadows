using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items
{
	public class ShadowBuffPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Power Potion");
			Tooltip.SetDefault("Buffs a lot of stuff");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 11;
            item.value = Item.sellPrice(gold: 1);
            item.buffType = BuffType<Buffs.ShadowBuff>();
            item.buffTime = 36000;
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WrathPotion);
			recipe.AddIngredient(ItemID.RagePotion);
			recipe.AddIngredient(ItemID.IronskinPotion);
			recipe.AddIngredient(ItemID.GillsPotion);
			recipe.AddIngredient(ItemID.RegenerationPotion);
			recipe.AddIngredient(ItemID.SwiftnessPotion);
			recipe.AddIngredient(ItemID.LifeforcePotion);
			recipe.AddIngredient(ItemID.SummoningPotion);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 50);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
    }
}
