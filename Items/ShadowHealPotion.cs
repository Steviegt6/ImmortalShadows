using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items
{
	public class ShadowHealPotion : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Shadow Healing Brew");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 99;
			item.consumable = true;
			item.rare = 11;
			item.healLife = 230;
			item.potion = true;
			item.value = Item.sellPrice(silver: 65);
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SuperHealingPotion);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 5);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
