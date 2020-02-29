using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items
{
	public class ShadowHamaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadesteel Hamaxe");
		}

		public override void SetDefaults() 
		{
			item.damage = 70;
			item.melee = true;
			item.width = 56;
			item.height = 54;
			item.useTime = 6;
			item.useAnimation = 20;
			item.axe = 30;          //The axe power displayed in-game is this value multiplied by 5
			item.hammer = 180;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(gold: 8);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.tileBoost += 5;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarHamaxeSolar);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
