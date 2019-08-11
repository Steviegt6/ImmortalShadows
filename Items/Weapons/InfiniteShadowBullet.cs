using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class InfiniteShadowBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Infinite Shadow Bullet");
			Tooltip.SetDefault("Slighty weaker, but you'll never run out!");
		}

		public override void SetDefaults() 
		{
			item.damage = 21;
			item.ranged = true;
			item.width = 10;
			item.height = 10;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 1.5f;
			item.value = Item.sellPrice(gold: 10);
			item.rare = 11;
			item.shoot = mod.ProjectileType("ShadowBullet");  
			item.shootSpeed = 20f;                
			item.ammo = AmmoID.Bullet;              
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowBullet"), 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
