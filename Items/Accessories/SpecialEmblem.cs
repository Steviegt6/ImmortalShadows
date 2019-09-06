using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Accessories
{
	public class SpecialEmblem : ModItem 
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Celebration Emblem");
			Tooltip.SetDefault("Made to commemorate 1000 downloads"
			    + "\n20% increased damage"
				+ "\n20% increased critical strike chance");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 20);
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.allDamage += 0.20f;
			player.meleeCrit += 20;
			player.rangedCrit += 20;
			player.magicCrit += 20;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DestroyerEmblem);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}