using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ImmortalShadows.Projectiles;

namespace ImmortalShadows.Items.Weapons
{
	public class MagicMissileStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Glowy Staff");
			Tooltip.SetDefault("Creates a controllable sparkle");
		}

		public override void SetDefaults() 
		{
			item.damage = 32;
			item.magic = true;
			item.mana = 11;
			item.width = 26;
			item.height = 26;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.noMelee = true;
			item.channel = true;
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 25);
			item.rare = 3;
			item.UseSound = SoundID.Item9;
			item.shoot = mod.ProjectileType<Projectiles.MagicSparkle>();
			item.shootSpeed = 10f;
			item.crit = 4;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}