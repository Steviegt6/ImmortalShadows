using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class BoulderBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Boulder Blade");
			Tooltip.SetDefault("Shoots a boulder-powered enchanted beam");
		}

		public override void SetDefaults() 
		{
			item.damage = 21;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = Item.sellPrice(silver: 20);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.EnchantedBeam;
			item.shootSpeed = 9f;
			item.useTurn = true;
			item.scale = 1.5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BoulderBoss.BoulderMaterial>(), 8);
			recipe.AddIngredient(ItemType<BasicBlade>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}