using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ImmortalShadows.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ShadowScarf : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Shadescarf");
			Tooltip.SetDefault("Reduces damage taken by 20%\nIncreases to all stats\nIncreases armor penetration by 10\nTurns the holder into a werewolf at night and a merfolk when entering water");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
		}

		public override void SetDefaults()
		{
			sbyte temp = item.neckSlot;
			item.CloneDefaults(ItemID.WormScarf);
			item.neckSlot = temp;
			item.value = Item.sellPrice(gold: 40);
			item.rare = 11;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance += 0.20f;

			player.armorPenetration += 10;

			player.lifeRegen += 4;
			player.statDefense += 8;
			player.meleeSpeed += 0.2f;
			player.allDamage += 0.2f;
			player.meleeCrit += 4;
			player.rangedCrit += 4;
			player.magicCrit += 4;
			player.pickSpeed -= 0.30f;
			player.minionKB += 1.0f;

			player.accMerman = true;
			player.wolfAcc = true;
			if (hideVisual)
			{
				player.hideMerman = true;
				player.hideWolf = true;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SAexpertItem"));
			recipe.AddIngredient(ItemID.WormScarf);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.CelestialShell);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 30);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}