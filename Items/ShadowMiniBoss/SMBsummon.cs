using ImmortalShadows.NPCs.ShadowMiniBoss;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items.ShadowMiniBoss
{
	public class SMBsummon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Relic");
			Tooltip.SetDefault("Summons a Shadow Wraith.");
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
			return NPC.downedMoonlord && !NPC.AnyNPCs(NPCType<NPCs.ShadowMiniBoss.ShadowMiniBoss>());
		}

		public override bool UseItem(Player player) 
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.ShadowMiniBoss.ShadowMiniBoss>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
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