using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ImmortalShadows.Items.Armor;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowHelmet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadesteel Helmet");
			Tooltip.SetDefault("10% increased damage"
			    + "\n+4 max minions"
				+ "\n+4 max sentries"
				+ "\n7% increased critical strike chance");
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 24;
			item.value = Item.sellPrice(gold: 10);
			item.rare = 11;
			item.defense = 25;
			item.glowMask = 28;
		}

		public override bool DrawHead()
		{
			return false;
		}

		public override void UpdateEquip(Player player) 
		{
			player.allDamage += 0.15f;
			player.maxMinions += 4;
			player.maxTurrets += 4;
			player.meleeCrit += 7;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ItemType<ShadowBreastplate>() && legs.type == ItemType<ShadowLeggings>();
		}

		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "Immunity to Moon Bite \nSet bonuses of Nebula and Valhalla Knight armors";
			player.buffImmune[BuffID.MoonLeech] = true;

			player.setSquireT3 = true;
			player.setSquireT2 = true;

			if (player.nebulaCD > 0)
			{
				player.nebulaCD--;
			}
			player.setNebula = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SolarFlareHelmet);
			recipe.AddIngredient(ItemID.ChlorophyteHelmet);
			recipe.AddIngredient(ItemID.StardustHelmet);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}