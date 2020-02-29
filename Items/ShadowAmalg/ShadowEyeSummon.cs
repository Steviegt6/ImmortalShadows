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
	public class ShadowEyeSummon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Very Suspicious Looking Eye");
			Tooltip.SetDefault("Summons a Dark Eye \nCan only be used at night");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 34;
			item.height = 20;
			item.maxStack = 20;
			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player) 
		{
			return !Main.dayTime && !NPC.AnyNPCs(NPCType<ShadowEye>());
		}

		public override bool UseItem(Player player) 
		{

			NPC.SpawnOnPlayer(player.whoAmI, NPCType<ShadowEye>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Lens, 4);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}