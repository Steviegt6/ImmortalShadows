using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Accessories
{
	public class BoulderMagic : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Boulder Magic");
			Tooltip.SetDefault("Grants a double jump"
				+ "\n+20 mana");
		}

		public override void SetDefaults() 
		{
			item.value = Item.sellPrice(silver: 35);
			item.width = 20;
			item.height = 20;
			item.rare = 1;
			item.accessory = true;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.doubleJumpBlizzard = true;
			player.statManaMax2 += 20;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BoulderBoss.BoulderMaterial>(), 12);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}