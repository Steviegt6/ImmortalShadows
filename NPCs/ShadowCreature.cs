using System;
using ImmortalShadows.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ImmortalShadows.NPCs
{
	[AutoloadHead]
	public class ShadowCreature : ModNPC
	{
		public override string Texture => "ImmortalShadows/NPCs/ShadowCreature";
		
		public override string[] AltTextures => new[] { "ImmortalShadows/NPCs/ShadowCreature_Alt_1" };

		public override bool Autoload(ref string name) 
		{
			name = "Shadow Creature";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Creature");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 60;
			NPCID.Sets.AttackAverageChance[npc.type] = 66;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() 
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 50;
			npc.defense = 35;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) 
		{		
			for (int k = 0; k < 255; k++) 
			{
				Player player = Main.player[k];
				if (!player.active) 
				{
					continue;
				}

				foreach (Item item in player.inventory) 
				{
					if (item.type == mod.ItemType("ShadowChunk")) 
					{
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName() 
		{
			switch (WorldGen.genRand.Next(4)) 
			{
				case 0:
					return "Dave";
				case 1:
					return "Dan";
				case 2:
					return "Max";
				default:
					return "Robert";
			}
		}

		public override void FindFrame(int frameHeight) 
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() 
		{
			int Guide = NPC.FindFirstNPC(NPCID.Guide);
			if (Guide >= 0 && Main.rand.NextBool(4)) 
			{
				return "Damn it, " + Main.npc[Guide].GivenName + " keeps asking questions about what I am! It's none of his business.";
			} 
			switch (Main.rand.Next(4)) 
			{
				case 0:
					return "Something isn't right in this world.";
				case 1:
					return "What do you want?";
				case 2:
					return "You've killed a lot of monsters. It's pretty scary.";
				default:
					return "Why don't I have arms or legs? None of your business.";
			}
		}
		
		public override void SetChatButtons(ref string button, ref string button2) 
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}
		
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if(firstButton)
			{
				shop = true;
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot) 
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowChunk"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadeStone"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowMask"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowBody"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowFeet"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.LunarOre);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentSolar);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentNebula);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentVortex);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentStardust);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowHealPotion"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ShadowBullet"));
			nextSlot++;
		}

		public override void NPCLoot() 
		{
			Item.NewItem(npc.getRect(), mod.ItemType<Items.ShadowChunk>());
		}

		public override bool CanGoToStatue(bool toKingStatue) 
		{
			return true;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) 
		{
			damage = 50;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) 
		{
			cooldown = 20;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) 
		{			
			projType = mod.ProjectileType("ShadowBullet");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) 
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
