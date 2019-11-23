using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadowBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Bullet");
			Tooltip.SetDefault("Pierces AND bounces!");
		}

		public override void SetDefaults() 
		{
			item.damage = 23;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             
			item.knockBack = 1.5f;
			item.value = Item.sellPrice(silver: 10);
			item.rare = 11;
			item.shoot = mod.ProjectileType("ShadowBullet");   
			item.shootSpeed = 20f;                  
			item.ammo = AmmoID.Bullet;              
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordBullet, 70);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}
