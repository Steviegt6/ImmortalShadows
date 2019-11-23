using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Staff");
			Tooltip.SetDefault("Shoots a ball of energy");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 240;
			item.magic = true;
			item.mana = 18;
			item.width = 44;
			item.height = 48;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = Item.sellPrice(gold: 40);
			item.rare = 11;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ProjectileID.NebulaBlaze2;
			item.shootSpeed = 16f;
			item.crit = 14;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NebulaBlaze);
			recipe.AddIngredient(ItemID.SpectreStaff);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 32);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}