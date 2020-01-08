using System;
using Microsoft.Xna.Framework;
using ImmortalShadows.NPCs.ShadowAmalg;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.BoulderBoss
{
    public class BBsummon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boulder Charm");
			Tooltip.SetDefault("Summons a sentient boulder");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(NPCType<NPCs.BoulderBoss.BoulderBoss>());
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.BoulderBoss.BoulderBoss>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
