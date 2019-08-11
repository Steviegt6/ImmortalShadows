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
			Tooltip.SetDefault("20% increased critical strike chance"
			    + "\n+1 max minions");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 15);;
			item.rare = 11;
			item.defense = 26;
		}

		public override void UpdateEquip(Player player) 
		{
			player.meleeCrit += 20;
			player.magicCrit += 20;
			player.rangedCrit += 20;
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
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}