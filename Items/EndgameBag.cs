using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items
{
	public class EndgameBag : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Endgame Bonus Bag");
			Tooltip.SetDefault("<right> for 10 hard to get items!");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.rare = -12;
			item.expert = true;
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
			recipe.AddIngredient(ItemID.LunarBar, 999);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 999);
			recipe.AddIngredient(ItemID.MoonLordBossBag, 2);
			recipe.AddIngredient(ItemID.GoldCoin, 99);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}