using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Placeable
{
	public class ShadeStone : ModItem
	{	
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("ShadeStone");
			item.value = Item.sellPrice(silver: 10);
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 2);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"));
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}