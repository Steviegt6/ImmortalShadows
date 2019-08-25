using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ImmortalShadows.Projectiles;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowMagicMissile : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadespark Staff");
			Tooltip.SetDefault("Creates a controllable sparkle");
		}

		public override void SetDefaults() 
		{
			item.damage = 305;
			item.magic = true;
			item.mana = 12;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.noMelee = true;
			item.channel = true;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 70);
			item.rare = 11;
			item.UseSound = SoundID.Item9;
			item.shoot = mod.ProjectileType<Projectiles.ShadowSparkle>();
			item.shootSpeed = 10f;
			item.crit = 14;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 10);
			recipe.AddIngredient(mod.ItemType("MagicMissileStaff"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}