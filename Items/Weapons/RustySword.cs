using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class RustySword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Rusty Greatsword");
			Tooltip.SetDefault("Shoots an enchanted beam");
		}

		public override void SetDefaults() 
		{
			item.damage = 36;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 80);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.EnchantedBeam;
			item.shootSpeed = 10f;
			item.useTurn = true;
			item.crit = 4;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.Obsidian, 8);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}