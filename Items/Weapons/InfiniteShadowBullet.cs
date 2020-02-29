using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class InfiniteShadowBullet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Infinite Shadesteel Bullet");
			Tooltip.SetDefault("Slighty weaker, but you'll never run out!");
		}

		public override void SetDefaults() 
		{
			item.damage = 19;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 1.5f;
			item.value = Item.sellPrice(gold: 2);
			item.rare = 11;
			item.shoot = ProjectileType<Projectiles.ShadowBullet>();  
			item.shootSpeed = 20f;                
			item.ammo = AmmoID.Bullet;              
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordBullet, 3996);
			recipe.AddIngredient(ItemType<ShadowBullet>(), 3996);
			recipe.AddIngredient(ItemID.SoulofMight, 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
