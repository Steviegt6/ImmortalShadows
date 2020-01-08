using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class SolarBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Blade");
			Tooltip.SetDefault("Shoots a beam that passes through tiles and pierces"
				+ "\nMelee hits inflict Ichor and Daybroken");
		}

		public override void SetDefaults()
		{
			item.damage = 170;
			item.melee = true;
			item.width = 48;
			item.height = 52;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 16);
			item.rare = 10;
			item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
			item.autoReuse = true;
			item.shoot = ProjectileID.DD2SquireSonicBoom;
			item.shootSpeed = 14f;
			item.scale = 1.2f;
			item.useTurn = true;
			item.crit = 4;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)

		{

			target.AddBuff(BuffID.Ichor, 600);
			target.AddBuff(BuffID.Daybreak, 600);

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.InfluxWaver);
			recipe.AddIngredient(ItemID.FragmentSolar, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DD2SquireBetsySword);
			recipe.AddIngredient(ItemID.FragmentSolar, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}