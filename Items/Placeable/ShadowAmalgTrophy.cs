using ImmortalShadows.Tiles;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Placeable
{
	public class ShadowAmalgTrophy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Amalgamation Trophy");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = 1;
			item.createTile = TileType<BossTrophy>();
			item.placeStyle = 0;
		}
	}
}