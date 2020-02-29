using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
    public class Paralyzer : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paralyzer");
			Tooltip.SetDefault("Has a chance to cause confusion");
		}

		public override void SetDefaults()
		{
			item.damage = 24;
			item.ranged = true;
			item.width = 26;
			item.height = 12;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 1;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Paralyzer");
			item.shoot = ProjectileType<Projectiles.ParalyzerBeamProj>();
			item.shootSpeed = 14f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddIngredient(ItemID.Diamond, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 6);
			recipe.AddIngredient(ItemID.Diamond, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
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