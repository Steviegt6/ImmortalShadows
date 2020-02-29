using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
    public class PowerBeam : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arm Cannon (Long Beam)");
			Tooltip.SetDefault("Shoots farther than the Power Beam");
		}

		public override void SetDefaults()
		{
			item.damage = 54;
			item.ranged = true;
			item.width = 26;
			item.height = 12;
			item.autoReuse = true;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PowerBeam");
			item.shoot = ProjectileType<Projectiles.PowerBeamProj>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ShortPowerBeam>());
			recipe.AddIngredient(ItemID.PhoenixBlaster);
			recipe.AddTile(TileType<Tiles.BeamUpgrader>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(12, 6);
		}
	}
}