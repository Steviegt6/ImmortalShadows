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
			    + "\n15% increased damage"
				+ "\n15% increased critical strike chance");
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
			player.allDamage += 0.15f;
			player.meleeCrit += 15;
			player.rangedCrit += 15;
			player.magicCrit += 15;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DestroyerEmblem, 1);
			recipe.AddIngredient(ItemID.LunarBar, 14);
			recipe.AddIngredient(ItemID.SoulofLight, 14);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 14);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}