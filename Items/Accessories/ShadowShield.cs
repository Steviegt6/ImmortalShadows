using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShadowShield : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dark Ankh Shield");
			Tooltip.SetDefault("Ah! Wow! Whoa! It's a 'shield'."
				+ "\n" + Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 20)
				+ "\nGrants immunity to knockback and fire blocks"
				+ "\nGrants immunity to most debuffs"
				+ "\n+50 max mana"
				+ "\n+1 max minions");
		}

		public override void SetDefaults() 
		{
			sbyte temp = item.shieldSlot;
			item.CloneDefaults(ItemID.AnkhShield);
			item.shieldSlot = temp;
			item.width = 30;
			item.height = 34;
			item.value = Item.sellPrice(gold: 45);
			item.rare = 11;
			item.accessory = true;
			item.defense = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
				player.allDamage += 0.2f;
				player.statManaMax2 += 50;
				player.maxMinions++;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddIngredient(ItemID.AvengerEmblem);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 25);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}