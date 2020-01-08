using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowArrow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadesteel Arrow");
			Tooltip.SetDefault("Pierces, bounces and inflicts Shadowflame on enemies");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.ranged = true;
			item.width = 14;
			item.height = 34;
			item.maxStack = 999;
			item.consumable = true;             
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(silver: 2);
			item.rare = 11;
			item.shoot = mod.ProjectileType("ShadowArrow");   
			item.shootSpeed = 20f;                  
			item.ammo = AmmoID.Arrow;              
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordArrow, 5);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}
