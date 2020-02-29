using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items
{
	public class ShadowPickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadesteel Pickaxe");
		}

		public override void SetDefaults() 
		{
			item.damage = 90;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 4;
			item.useAnimation = 12;
			item.pick = 235;
			item.useStyle = 1;
			item.knockBack = 5;
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
			recipe.AddIngredient(ItemID.SolarFlarePickaxe);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}