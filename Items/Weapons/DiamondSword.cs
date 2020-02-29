using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class DiamondSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Diamond Sword");
			Tooltip.SetDefault("I swear I've seen this before...\nTrue melee weapon");
		}

		public override void SetDefaults() 
		{
			item.damage = 39;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 70);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddIngredient(ItemID.Diamond, 2);
			recipe.AddIngredient(ItemID.ShadowScale, 6);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddIngredient(ItemID.Diamond, 2);
			recipe.AddIngredient(ItemID.TissueSample, 6);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}