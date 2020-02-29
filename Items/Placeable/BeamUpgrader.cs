using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Placeable
{
	public class BeamUpgrader : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Arm Cannon Modifier");
			Tooltip.SetDefault("Used for upgrading your arm cannon");
		}

		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.createTile = TileType<Tiles.BeamUpgrader>();
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddIngredient(ItemID.Obsidian, 8);
			recipe.AddIngredient(ItemID.Meteorite, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 10);
			recipe.AddIngredient(ItemID.Obsidian, 8);
			recipe.AddIngredient(ItemID.Meteorite, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}