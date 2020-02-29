using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
    public class PlasmaBeam : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arm Cannon (Plasma Beam)");
			Tooltip.SetDefault("Pierces through enemies");
		}

		public override void SetDefaults()
		{
			item.damage = 220;
			item.ranged = true;
			item.width = 26;
			item.height = 12;
			item.autoReuse = true;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.rare = 10;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PlasmaBeam");
			item.shoot = ProjectileType<Projectiles.PlasmaBeamProj>();
			item.shootSpeed = 18f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SpazerBeam>());
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileType<Tiles.BeamUpgrader>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(12, 6);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}