using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class HallowedBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Blade");
			Tooltip.SetDefault("Shoots a beam of pure light"
				+ "\nMelee hits inflict Ichor and Cursed Inferno");
		}

		public override void SetDefaults()
		{
			item.damage = 84;
			item.melee = true;
			item.width = 46;
			item.height = 50;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 14);
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.LightBeam;
			item.shootSpeed = 13f;
			item.useTurn = true;
			item.crit = 4;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)

		{

			target.AddBuff(BuffID.Ichor, 600);
			target.AddBuff(BuffID.CursedInferno, 300);

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CrystalBlade"));
			recipe.AddIngredient(ItemID.HallowedBar, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}