using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ShadowLeggings : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadesteel Leggings");
			Tooltip.SetDefault("15% increased melee speed"
				+ "\n25% chance not to consume ammo"
			    + "\n30% increased movement speed");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 10);;
			item.rare = 11;
			item.defense = 20;
			item.glowMask = 30;
		}

		public override bool DrawLegs()
		{
			return false;
		}

		public override void UpdateEquip(Player player) 
		{
			player.moveSpeed += 0.30f;
			player.ammoCost75 = true;
			player.meleeSpeed += 0.15f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarFlareLeggings);
			recipe.AddIngredient(ItemID.NebulaLeggings);
			recipe.AddIngredient(ItemID.VortexLeggings);
			recipe.AddIngredient(ItemID.StardustLeggings);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}