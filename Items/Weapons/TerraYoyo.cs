using ImmortalShadows.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class TerraYoyo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Terrarian");
			Tooltip.SetDefault("Charged with the power of Terraria");

			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.useStyle = 5;
			item.width = 30;
			item.height = 26;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 280;
			item.rare = 11;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 55);
			item.shoot = ProjectileType<TerraYoyoProjectile>();			
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 10);
			recipe.AddIngredient(ItemID.Terrarian);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
