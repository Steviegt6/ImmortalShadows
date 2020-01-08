using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class CrystalBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Blade");
			Tooltip.SetDefault("Shoots a beam of light"
				+ "\nMelee hits inflict Ichor and Cursed Inferno");
		}

		public override void SetDefaults()
		{
			item.damage = 62;
			item.melee = true;
			item.width = 46;
			item.height = 50;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 10);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.SwordBeam;
			item.shootSpeed = 12f;
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
			recipe.AddIngredient(mod.ItemType("RustyBlade"));
			recipe.AddIngredient(ItemID.CrystalShard, 18);
			recipe.AddIngredient(ItemID.AdamantiteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RustyBlade"));
			recipe.AddIngredient(ItemID.CrystalShard, 18);
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}