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
			Tooltip.SetDefault("Summons the Shadow Amalgamation \nIf the Shadow Amalgamation has already been defeated, it will summon a replacment \nCan only be used at night and after killing the Moon Lord");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 10;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player) 
		{
			return NPC.downedMoonlord && !Main.dayTime && !NPC.AnyNPCs(NPCType<NPCs.ShadowAmalg.ShadowAmalg>()) && !NPC.AnyNPCs(NPCType<NPCs.ShadowAmalg.ShadowAmalg2>()) && !NPC.AnyNPCs(NPCType<NPCs.ShadowAmalg.DarkAmalg.DarkAmalg>()) && !NPC.AnyNPCs(NPCType<NPCs.ShadowAmalg.DarkAmalg.DarkAmalg2>());
		}

		public override bool UseItem(Player player) 
		{
			if (ImmortalWorld.downedShadowAmalg)
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.ShadowAmalg.DarkAmalg.DarkAmalg>());
				Main.PlaySound(SoundID.Roar, player.position, 0);
				return true;
			}
			else
			{
				NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.ShadowAmalg.ShadowAmalg>());
				Main.PlaySound(SoundID.Roar, player.position, 0);
				return true;
			}
		}

		public override void OnConsumeItem(Player player)
		{
			if (ImmortalWorld.downedShadowAmalg)
			{
				Main.NewText("...", 191, 0, 0);
			}
			else
			{
				Main.NewText("You are the one i've been looking for...", 255, 0, 0);
			}
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}