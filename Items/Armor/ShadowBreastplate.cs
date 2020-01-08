using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShadowBreastplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Shadesteel Breastplate");
			Tooltip.SetDefault("+50 max mana"
				+ "\n20% increased damage"
				+ "\n15% reduced mana usage and massively increased life regen");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 20);
			item.rare = 11;
			item.defense = 30;
			item.glowMask = 29;
		}

		public override bool DrawBody()
		{
			return false;
		}

		public override void UpdateEquip(Player player) 
		{
			player.statManaMax2 += 35;
			player.allDamage += 0.20f;
			player.manaCost -= 0.15f;
			player.lifeRegen += 16;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarFlareBreastplate);
			recipe.AddIngredient(ItemID.NebulaBreastplate);
			recipe.AddIngredient(ItemID.VortexBreastplate);
			recipe.AddIngredient(ItemID.StardustBreastplate);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}