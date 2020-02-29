using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items
{
	public class DiamondPickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Diamond Pickaxe");
			Tooltip.SetDefault("I swear I've seen this before...");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 14;
			item.useAnimation = 20;
			item.pick = 100;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 60);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.5f;
			item.tileBoost += 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}