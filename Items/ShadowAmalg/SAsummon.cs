using System;
using Microsoft.Xna.Framework;
using ImmortalShadows.NPCs.ShadowAmalg;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.ShadowAmalg
{
	public class SAsummon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Relic");
			Tooltip.SetDefault("Summons the shadow amalgamation");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.maxStack = 20;
			item.rare = 10;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player) 
		{
			return NPC.downedMoonlord && !Main.dayTime && !NPC.AnyNPCs(NPCType<NPCs.ShadowAmalg.ShadowAmalg>());
		}

		public override bool UseItem(Player player) 
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.ShadowAmalg.ShadowAmalg>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void OnConsumeItem(Player player)
		{
			if (ShadowWorld.downedShadowAmalg)
			{
				Main.NewText("...", 191, 0, 0);
			}
			else
			{
				Main.NewText("You are the one i've been looking for...", 191, 0, 0);
			}
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarOre, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}