using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
    public class ShadowBeam : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arm Cannon (Shadow Beam)");
			Tooltip.SetDefault("Inflicts Venom and Poisoned");
		}

		public override void SetDefaults()
		{
			item.damage = 298;
			item.ranged = true;
			item.width = 26;
			item.height = 12;
			item.autoReuse = true;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 14, 0, 0);
			item.rare = 11;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/ShadowBeam");
			item.shoot = ProjectileType<Projectiles.ShadowBeamProj>();
			item.shootSpeed = 18f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<PlasmaBeam>());
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 12);
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