using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using ImmortalShadows.NPCs.ShadowAmalg;
using ImmortalShadows.Items.ShadowAmalg;
using ImmortalShadows.NPCs.BoulderBoss;
using ImmortalShadows.Items.BoulderBoss;
using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.Armor.Masks;
using ImmortalShadows.Items;
using ImmortalShadows.Items.Weapons;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows
{
	public class ImmortalShadows : Mod
	{
		public static ImmortalShadows Instance;

		public override void Load()
		{
			Instance = this;
		}

		public override void Unload()
		{
			Instance = null;
		}

		public ImmortalShadows()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		
        public override void PostSetupContent()
        {
			#region Cenus support

			Mod censusMod = ModLoader.GetMod("Census");
            if(censusMod != null)
            {
                 censusMod.Call("TownNPCCondition", NPCType("Shadow Amalgamation"), "Defeat the Shadow Amalgamation");
            }

			#endregion

			#region Boss Checklist support

			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					14.1f,
					ModContent.NPCType<ShadowAmalg>(),
					this,
					"Shadow Amalgamation",
					(Func<bool>)(() => ImmortalWorld.downedShadowAmalg),
					ModContent.ItemType<SAsummon>(),
					new List<int> { ModContent.ItemType<ShadowAmalgTrophy>(), ModContent.ItemType<ShadowAmalgMask>() },
					new List<int> { ModContent.ItemType<ShadowChunk>() },
					"Use a Shadow Relic at night after beating the Moon Lord",
					"The Shadow Amalgamation flees",
					"ImmortalShadows/NPCs/ShadowAmalg/ShadowAmalgLog",
					"ImmortalShadows/NPCs/ShadowAmalg/ShadowAmalgLogIcon");

				bossChecklist.Call(
					"AddBoss",
					0.1f,
					ModContent.NPCType<BoulderBoss>(),
					this,
					"Sentient Boulder",
					(Func<bool>)(() => ImmortalWorld.downedBoulderBoss),
					ModContent.ItemType<BBsummon>(),
					new List<int> { ModContent.ItemType<BoulderBossTrophy>(), ModContent.ItemType<BoulderBossMask>() },
					new List<int> { ItemID.StoneBlock, ModContent.ItemType<BoulderMaterial>() },
					"Use a Boulder Charm, preferably on a large flat area on the surface",
					"The Sentient Boulder flees",
					"ImmortalShadows/NPCs/BoulderBoss/BoulderBoss",
					"ImmortalShadows/NPCs/BoulderBoss/BoulderBoss_Head_Boss");

				bossChecklist.Call(
					"AddBoss",
					6.5f,
					ModContent.NPCType<ShadowEye>(),
					this,
					"Dark Eye",
					(Func<bool>)(() => ImmortalWorld.downedShadowEye),
					ModContent.ItemType<ShadowEyeSummon>(),
					new List<int> { ModContent.ItemType<ShadowEyeTrophy>(), ModContent.ItemType<ShadowEyeMask>() },
					new List<int> { ItemID.SoulofNight },
					"Use a Very Suspicious Looking Eye at night",
					"The Dark Eye flees",
					"ImmortalShadows/NPCs/ShadowAmalg/ShadowEyeLog",
					"ImmortalShadows/NPCs/ShadowAmalg/ShadowEye_Head_Boss");
			}

			#endregion
		}

        public override void AddRecipes()
		{
			#region Vanilla item recipes

			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<HallowedBlade>());
			recipe.AddIngredient(ItemID.BrokenHeroSword, 2);
			recipe.AddIngredient(ItemID.SpectreBar, 4);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(ItemID.TerraBlade);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 18);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(ItemID.InfluxWaver);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.BeetleHusk, 10);
			recipe.AddIngredient(ItemID.DefenderMedal, 4);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(ItemID.DD2SquireBetsySword);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<SolarBlade>());
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.Meowmere);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<BoulderBlade>());
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<BoulderBlade>());
			recipe.AddIngredient(ItemID.CrimtaneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();

			#endregion
		}
    }
}