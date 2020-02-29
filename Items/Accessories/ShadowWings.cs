using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class ShadowWings : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dark Angel Wings");
		}

		public override void SetDefaults() 
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(gold: 14);
			item.rare = 11;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.wingTimeMax = 300;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) 
	    {
			ascentWhenFalling = 0.90f;
			ascentWhenRising = 0.20f;
			maxCanAscendMultiplier = 2f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.140f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) 
		{
			speed = 10f;
			acceleration *= 3.5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AngelWings);
			recipe.AddIngredient(ItemID.DemonWings);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 10);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}