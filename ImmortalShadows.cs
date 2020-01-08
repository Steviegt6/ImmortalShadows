using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
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
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows
{
	public class ImmortalShadows : Mod
	{
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
            //Cenus support
            Mod censusMod = ModLoader.GetMod("Census");
            if(censusMod != null)
            {
                 censusMod.Call("TownNPCCondition", NPCType("Shadow Creature"), "Have a Shadow Chunk in your inventory");
            }

			//Boss checklist support
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddMiniBoss",
					14.1f,
					ModContent.NPCType<ShadowAmalg>(),
					this, // Mod
					"Shadow Amalgamation",
					(Func<bool>)(() => ShadowWorld.downedShadowAmalg),
					ModContent.ItemType<SAsummon>(),
					new List<int> { ModContent.ItemType<ShadowAmalgTrophy>(), ModContent.ItemType<ShadowAmalgMask>() },
					new List<int> { ModContent.ItemType<ShadowChunk>() },
					"Use a Shadow Relic at night after beating the Moon Lord",
					"The Shadow Amalgamation flees",
					"ImmortalShadows/NPCs/ShadowAmalg/ShadowAmalg",
					"ImmortalShadows/NPCs/ShadowAmalg/ShadowAmalg_Head_Boss");

				bossChecklist.Call(
					"AddMiniBoss",
					0.1f,
					ModContent.NPCType<BoulderBoss>(),
					this, // Mod
					"Sentient Boulder",
					(Func<bool>)(() => ShadowWorld.downedBoulderBoss),
					ModContent.ItemType<BBsummon>(),
					new List<int> { ModContent.ItemType<BoulderBossTrophy>(), ModContent.ItemType<BoulderBossMask>() },
					new List<int> { ItemID.StoneBlock, ModContent.ItemType<BoulderMaterial>() },
					"Use a Boulder Charm, preferably on a large flat area on the surface",
					"The Sentient Boulder flees",
					"ImmortalShadows/NPCs/BoulderBoss/BoulderBoss",
					"ImmortalShadows/NPCs/BoulderBoss/BoulderBoss_Head_Boss");
			}
		}

		public override void AddRecipes()
		{
			//New vanilla item recipes, that make a sword-only playthrough more straight-foward.
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(this.ItemType("HallowedBlade"));
			recipe.AddIngredient(ItemID.BrokenHeroSword, 3);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(ItemID.TerraBlade);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.InfluxWaver);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.LihzahrdBrick, 10);
			recipe.AddIngredient(ItemID.DefenderMedal, 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.DD2SquireBetsySword);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.ItemType("SolarBlade"));
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.Meowmere);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.ItemType("BoulderBlade"));
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.ItemType("BoulderBlade"));
			recipe.AddIngredient(ItemID.CrimtaneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();
		}
	}
}