using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace ImmortalShadows.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowHelmet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadowflare Helmet");
			Tooltip.SetDefault("15% increased critical strike chance"
			    + "\n+1 max minions");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 15);;
			item.rare = 11;
			item.defense = 25;
		}

		public override void UpdateEquip(Player player) 
		{
			player.meleeCrit += 15;
			player.magicCrit += 15;
			player.rangedCrit += 15;
			player.maxMinions++;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == mod.ItemType("ShadowBreastplate") && legs.type == mod.ItemType("ShadowLeggings");
		}

		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "Immune to Moon Bite and +1 max minions";
			player.buffImmune[BuffID.MoonLeech] = true;
			player.maxMinions++;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarFlareHelmet);
			recipe.AddIngredient(ItemID.NebulaHelmet);
			recipe.AddIngredient(ItemID.VortexHelmet);
			recipe.AddIngredient(ItemID.StardustHelmet);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}