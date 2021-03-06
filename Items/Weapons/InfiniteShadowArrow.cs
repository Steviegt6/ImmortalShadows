using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Weapons
{
	public class InfiniteShadowArrow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Infinite Shadesteel Arrow");
			Tooltip.SetDefault("Slighty weaker, but you'll never run out!");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 18;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(gold: 2);
			item.rare = 11;
			item.shoot = ProjectileType<Projectiles.ShadowArrow>();   
			item.shootSpeed = 20f;                  
			item.ammo = AmmoID.Arrow;              
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoonlordArrow, 3996);
			recipe.AddIngredient(ItemType<ShadowArrow>(), 3996);
			recipe.AddIngredient(ItemID.SoulofMight, 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
