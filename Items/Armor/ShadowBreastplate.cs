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
			DisplayName.SetDefault("Shadowflare Breastplate");
			Tooltip.SetDefault("Immunity to 'Ichor'"
				+ "\n+35 max mana and +1 max minions"
				+ "\n20% increased damage");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 20);
			item.rare = 11;
			item.defense = 35;
		}

		public override void UpdateEquip(Player player) 
		{
			player.buffImmune[BuffID.Ichor] = true;
			player.statManaMax2 += 35;
			player.maxMinions++;
			player.allDamage += 0.20f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarFlareBreastplate);
			recipe.AddIngredient(ItemID.NebulaBreastplate);
			recipe.AddIngredient(ItemID.VortexBreastplate);
			recipe.AddIngredient(ItemID.StardustBreastplate);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}