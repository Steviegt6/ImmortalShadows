using Terraria;
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
			Tooltip.SetDefault("One shield to rule them all."
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
			item.value = Item.sellPrice(gold: 35);
			item.rare = 11;
			item.accessory = true;
			item.defense = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.statManaMax2 += 50;
			player.maxMinions++;
			player.buffImmune[46] = true;
			player.noKnockback = true;
			player.fireWalk = true;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[30] = true;
			player.buffImmune[20] = true;
			player.buffImmune[32] = true;
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[22] = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 40);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}