using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items
{
	public class EndgameBag : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Endgame Bonus Bag");
			Tooltip.SetDefault("<right> for 10 hard to get items and some money!");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 18;
			item.rare = -12;
		}

		public override bool CanRightClick() 
		{
			return true;
		}

		public override void RightClick(Player player) 
		{
			player.QuickSpawnItem(ItemID.AnkhShield);
			player.QuickSpawnItem(ItemID.FrostsparkBoots);
			player.QuickSpawnItem(ItemID.LavaWaders);
			player.QuickSpawnItem(ItemID.CellPhone);
			player.QuickSpawnItem(ItemID.PlatinumCoin, 10);
			player.QuickSpawnItem(ItemID.FireGauntlet);
			player.QuickSpawnItem(ItemID.SniperScope);
			player.QuickSpawnItem(ItemID.CelestialStone);
			player.QuickSpawnItem(ItemID.GreedyRing);
			player.QuickSpawnItem(ItemID.RodofDiscord);
			player.QuickSpawnItem(ItemID.GoldBunny);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 50);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 100);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}